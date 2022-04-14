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

      public bool IsPlaying => _diaTimer != null;

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

      private void LoadCurrentPicture()
      {
         if (_fileIndex.HasValue && !string.IsNullOrEmpty(_dir) && _matchingFilesInDir != null && _fileIndex.Value >= 0 && _fileIndex.Value < _matchingFilesInDir.Length)
         {
            LoadFile.Invoke(Path.Combine(_dir, _matchingFilesInDir[_fileIndex.Value]));
         }
      }

      private void LoadFirstPicture()
      {
         if (!string.IsNullOrEmpty(_dir))
         {
            TrySetFile();
            if (_fileIndex.HasValue && _matchingFilesInDir != null)
            {
               LoadCurrentPicture();
            }
         }
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

      private void OnDiaNextImage(object? sender, ElapsedEventArgs e)
      {
         if (_fileIndex.HasValue && _matchingFilesInDir != null)
         {
            _fileIndex++;
            _fileIndex = _fileIndex % _matchingFilesInDir.Length;

            LoadCurrentPicture();
         }
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
   }
}
