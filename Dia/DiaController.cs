using System.Diagnostics;
using System.Timers;

namespace Dia
{
   public class DiaController
   {
      private readonly string[] POSSIBLE_EXTENSIONS = new string[] { ".BMP", ".JPG", ".JPEG", ".EXIF", ".PNG", ".TIFF", ".JFIF" };

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
               ReloadMatchingFiles();
            }
         }
      }

      private DiaOptions.SortingModeEnum __sortingMode;
      private DiaOptions.SortingModeEnum _sortingMode
      {
         get => __sortingMode;
         set
         {
            if (__sortingMode != value)
            {
               __sortingMode = value;
               ReloadMatchingFiles();
            }
         }
      }

      private void ReloadMatchingFiles()
      {
         try
         {
            if (!string.IsNullOrEmpty(__dir))
            {
               var di = new DirectoryInfo(__dir);
               _matchingFilesInDir = di.GetFiles()
                  .FilterFileExtension(POSSIBLE_EXTENSIONS)
                  .ConsiderSortMode(DiaOptions.SortingMode.CurrentValue)
                  .Select(fi => fi.Name)
                  .ToArray();
            }
         }
         catch
         {
         }
      }

      private int? _fileIndex;

      private System.Timers.Timer? _diaTimer;

      public event Action<string> LoadFile;
      public event Action<bool>? ContextChanged;

      public bool IsPlaying => _diaTimer != null;
      public bool HasValidContext { get; private set; }

      private string DirStatus => !string.IsNullOrEmpty(_dir) ? $"Directory: {_dir}" : string.Empty;
      private string MatchingFileStatus
      {
         get
         {
            if (_matchingFilesInDir != null && _matchingFilesInDir.Any())
            {
               return $"{_matchingFilesInDir.Length} matching files";
            }
            else if (!string.IsNullOrEmpty(_dir))
            {
               return "0 matching files";
            }
            else
            {
               return string.Empty;
            }
         }
      }

      private string FileStatus
      {
         get
         {
            string? currentFile = GetCurrentImageFileName();
            if (!string.IsNullOrEmpty(currentFile))
            {
               return $"\"{currentFile}\"";
            }
            else
            {
               return string.Empty;
            }
         }
      }
      private string FileNumberStatus
      {
         get
         {
            if (_fileIndex.HasValue)
            {
               return $"file {_fileIndex.Value + 1}";
            }
            else
            {
               return string.Empty;
            }
         }
      }

      public string StatusText => StringExtensions.JoinNotEmpty(", ", DirStatus, MatchingFileStatus, FileNumberStatus, FileStatus);

      public DiaController(Action<string> loadFile, string? initialFile)
      {
         LoadFile = loadFile;
         _sortingMode = DiaOptions.SortingMode.CurrentValue;

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

      private string? GetCurrentImageFileName()
      {
         if (_fileIndex.HasValue && !string.IsNullOrEmpty(_dir) && _matchingFilesInDir != null && _fileIndex.Value >= 0 && _fileIndex.Value < _matchingFilesInDir.Length)
         {
            return _matchingFilesInDir[_fileIndex.Value];
         }
         else
         {
            return null;
         }
      }

      private string? GetCurrentImageFilePath()
      {
         string? currentFileName = GetCurrentImageFileName();
         if (_dir != null && !string.IsNullOrEmpty(currentFileName))
         {
            return Path.Combine(_dir, currentFileName);
         }
         else
         {
            return null;
         }
      }

      private bool LoadCurrentPicture()
      {
         string? currentFilePath = GetCurrentImageFilePath();
         if (!string.IsNullOrEmpty(currentFilePath))
         {
            try
            {
               LoadFile.Invoke(currentFilePath);
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

         ReloadMatchingFiles();

         _diaTimer = new System.Timers.Timer(DiaOptions.ImageShowMilliSecs.CurrentValue);
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
         _sortingMode = DiaOptions.SortingMode.CurrentValue;
         WithRestartingDia(LoadNextImage);
      }

      public void PrevImage()
      {
         _sortingMode = DiaOptions.SortingMode.CurrentValue;
         WithRestartingDia(LoadPrevImage);
      }

      public void OpenCurrentImageInEditor()
      {
         if (!string.IsNullOrEmpty(DiaOptions.ImageEditor.CurrentValue))
         {
            string? currentFile = GetCurrentImageFilePath();
            if (!string.IsNullOrEmpty(currentFile))
            {
               Process.Start(DiaOptions.ImageEditor.CurrentValue, currentFile);
            }
         }
      }
   }
}
