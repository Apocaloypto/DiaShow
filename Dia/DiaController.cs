using System.Timers;

namespace Dia
{
   public class DiaController
   {
      private readonly string[] POSSIBLE_EXTENSIONS = new string[] { ".BMP", ".JPG", ".JPEG", ".EXIF", ".PNG", ".TIFF" };

      private string[]? _matchingFilesInDir;

      private string? __dir;
      private string? _dir
      {
         get => __dir;
         set
         {
            __dir = value;
            if (__dir == null)
            {
               _matchingFilesInDir = null;
            }
            else
            {
               try
               {
                  var di = new DirectoryInfo(__dir);
                  _matchingFilesInDir = di.GetFiles()
                     .Select(fi => fi.Name)
                     .Where(name => POSSIBLE_EXTENSIONS.Contains(Path.GetExtension(name).ToUpper()))
                     .ToArray();
               }
               catch
               {
               }
            }
         }
      }

      private int? _fileIndex;

      private System.Timers.Timer? _diaTimer;

      public event Action<string> LoadFile;
      public event Action<bool>? ContextChanged;

      public bool IsPlaying => _diaTimer != null;
      public bool HasValidContext { get; private set; }

      public DiaController(Action<string> loadFile, string? initialFile)
      {
         LoadFile = loadFile;

         if (!string.IsNullOrEmpty(initialFile))
         {
            SetContext_File(initialFile);
         }
      }

      private void TrySetFile()
      {
         if (!_fileIndex.HasValue && !string.IsNullOrEmpty(_dir))
         {
            try
            {
               if (_matchingFilesInDir?.Length >= 1)
               {
                  _fileIndex = 0;
               }
            }
            catch
            {
            }
         }
      }

      private bool LoadCurrentPicture()
      {
         if (_fileIndex.HasValue && !string.IsNullOrEmpty(_dir) && _matchingFilesInDir != null && _fileIndex.Value >= 0 && _fileIndex.Value < _matchingFilesInDir.Length)
         {
            try
            {
               LoadFile.Invoke(Path.Combine(_dir, _matchingFilesInDir[_fileIndex.Value]));
               return true;
            }
            catch
            {
            }
         }

         return false;
      }

      private void LoadFirstPicture()
      {
         bool validContext = false;

         if (!string.IsNullOrEmpty(_dir))
         {
            TrySetFile();
            if (_fileIndex.HasValue && _matchingFilesInDir != null)
            {
               if (LoadCurrentPicture())
               {
                  validContext = true;
               }
            }
         }

         HasValidContext = validContext;
         ContextChanged?.Invoke(validContext);
      }

      public void SetContext_File(string filepath)
      {
         StopDiaShow();
         _dir = Path.GetDirectoryName(filepath);

         int index = -1;
         if (_matchingFilesInDir != null)
         {
            index = Array.IndexOf(_matchingFilesInDir, Path.GetFileName(filepath));
         }

         _fileIndex = index >= 0 ? index : null;
         LoadFirstPicture();
      }

      public void SetContext_Dir(string dirpath)
      {
         StopDiaShow();
         _dir = dirpath;
         _fileIndex = null;
         LoadFirstPicture();
      }

      private void LoadNextImage()
      {
         if (_fileIndex.HasValue && _matchingFilesInDir != null)
         {
            _fileIndex++;
            _fileIndex = _fileIndex % _matchingFilesInDir.Length;

            LoadCurrentPicture();
         }
      }

      private void LoadPrevImage()
      {
         if (_fileIndex.HasValue && _matchingFilesInDir != null)
         {
            _fileIndex--;
            if (_fileIndex < 0)
            {
               _fileIndex = _matchingFilesInDir.Length - 1;
            }

            LoadCurrentPicture();
         }
      }

      private void OnDiaNextImage(object? sender, ElapsedEventArgs e)
      {
         LoadNextImage();
      }

      public void StartDiaShow()
      {
         StopDiaShow();

         _diaTimer = new System.Timers.Timer(DiaOptions.ImageShowMilliSecs);
         _diaTimer.Elapsed += OnDiaNextImage;
         _diaTimer.Enabled = true;
         _diaTimer.Start();
      }

      public bool StopDiaShow()
      {
         if (_diaTimer != null)
         {
            _diaTimer.Stop();
            _diaTimer.Elapsed -= OnDiaNextImage;
            _diaTimer.Enabled = false;
            _diaTimer = null;
            return true;
         }
         else
         {
            return false;
         }
      }

      private void WithRestartingDia(Action @do)
      {
         bool wasPlaying = IsPlaying;

         if (IsPlaying)
         {
            StopDiaShow();
         }

         @do();

         if (wasPlaying)
         {
            StartDiaShow();
         }
      }

      public void NextImage()
      {
         WithRestartingDia(LoadNextImage);
      }

      public void PrevImage()
      {
         WithRestartingDia(LoadPrevImage);
      }
   }
}
