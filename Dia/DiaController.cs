﻿using System.Diagnostics;
using System.Timers;

namespace Dia
{
   public class DiaController
   {
      public string[]? MatchingFilesInDir { get; private set; }

      private string? _dir;
      public string? Dir
      {
         get => _dir;
         private set
         {
            _dir = value;
            if (_dir == null)
            {
               MatchingFilesInDir = null;
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
         MatchingFilesInDir = null;

         try
         {
            if (!string.IsNullOrEmpty(_dir))
            {
               string? currentFile = GetCurrentImageFileName();

               MatchingFilesInDir = ImageLoader.GetMatchingFilesInDir(_dir);

               if (!string.IsNullOrEmpty(currentFile))
               {
                  FileIndex = Array.IndexOf(MatchingFilesInDir, currentFile);
               }
            }
         }
         catch
         {
         }
      }

      private int? _fileIndex;
      public int? FileIndex
      {
         get => _fileIndex;
         set
         {
            if (value != _fileIndex)
            {
               _fileIndex = value;

               if (_fileIndex.HasValue && MatchingFilesInDir != null)
               {
                  while (_fileIndex < 0)
                  {
                     _fileIndex = MatchingFilesInDir.Length + _fileIndex;
                  }

                  if (_fileIndex > MatchingFilesInDir.Length - 1)
                  {
                     _fileIndex = _fileIndex % MatchingFilesInDir.Length;
                  }
               }
            }
         }
      }

      private System.Timers.Timer? _diaTimer;

      public event Action<string> LoadFile;
      public event Action<bool>? ContextChanged;

      public bool IsPlaying => _diaTimer != null;
      public bool HasValidContext { get; private set; }

      private string DirStatus => !string.IsNullOrEmpty(Dir) ? $"Directory: {Dir}" : string.Empty;
      private string MatchingFileStatus
      {
         get
         {
            if (MatchingFilesInDir != null && MatchingFilesInDir.Any())
            {
               return $"{MatchingFilesInDir.Length:N0} matching files";
            }
            else if (!string.IsNullOrEmpty(Dir))
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
            if (FileIndex.HasValue)
            {
               return $"file {FileIndex.Value + 1}";
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
         if (!FileIndex.HasValue && !string.IsNullOrEmpty(Dir))
         {
            try
            {
               if (MatchingFilesInDir?.Length >= 1)
               {
                  FileIndex = 0;
               }
            }
            catch
            {
            }
         }
      }

      private string? GetCurrentImageFileName()
      {
         if (FileIndex.HasValue && !string.IsNullOrEmpty(Dir) && MatchingFilesInDir != null)
         {
            return MatchingFilesInDir[FileIndex.Value];
         }
         else
         {
            return null;
         }
      }

      private string? GetCurrentImageFilePath()
      {
         string? currentFileName = GetCurrentImageFileName();
         if (Dir != null && !string.IsNullOrEmpty(currentFileName))
         {
            return Path.Combine(Dir, currentFileName);
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

         if (!string.IsNullOrEmpty(Dir))
         {
            TrySetFile();
            if (FileIndex.HasValue && MatchingFilesInDir != null)
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
         Dir = Path.GetDirectoryName(filepath);

         int index = -1;
         if (MatchingFilesInDir != null)
         {
            index = Array.IndexOf(MatchingFilesInDir, Path.GetFileName(filepath));
         }

         FileIndex = index >= 0 ? index : null;
         LoadFirstPicture();
      }

      public void SetContext_Dir(string dirpath)
      {
         StopDiaShow();
         Dir = dirpath;
         FileIndex = null;
         LoadFirstPicture();
      }

      private void LoadNextImage()
      {
         if (FileIndex.HasValue && MatchingFilesInDir != null)
         {
            FileIndex++;
            LoadCurrentPicture();
         }
      }

      private void LoadFirstImage()
      {
         if (FileIndex.HasValue && MatchingFilesInDir != null)
         {
            FileIndex = 0;

            LoadCurrentPicture();
         }
      }

      private void LoadPrevImage()
      {
         if (FileIndex.HasValue && MatchingFilesInDir != null)
         {
            FileIndex--;
            LoadCurrentPicture();
         }
      }

      private void LoadLastImage()
      {
         if (FileIndex.HasValue && MatchingFilesInDir != null)
         {
            FileIndex = MatchingFilesInDir.Length - 1;

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

      public void FirstImage()
      {
         _sortingMode = DiaOptions.SortingMode.CurrentValue;
         WithRestartingDia(LoadFirstImage);
      }

      public void LastImage()
      {
         _sortingMode = DiaOptions.SortingMode.CurrentValue;
         WithRestartingDia(LoadLastImage);
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
               Process.Start(DiaOptions.ImageEditor.CurrentValue, $"\"{currentFile}\"");
            }
         }
      }
   }
}
