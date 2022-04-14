using System.Timers;

namespace Dia
{
   public partial class Form1 : Form
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

      public Form1(string? initialFile = null)
      {
         InitializeComponent();

         if (!string.IsNullOrEmpty(initialFile))
         {
            SetFile(initialFile);
         }

         EnableNormalScreen();
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

      private void LoadCurrentPicture()
      {
         if (_fileIndex.HasValue && !string.IsNullOrEmpty(_dir) && _matchingFilesInDir != null && _fileIndex.Value >= 0 && _fileIndex.Value < _matchingFilesInDir.Length)
         {
            if (thePicture.Image != null)
            {
               thePicture.Image.Dispose();
               thePicture.Image = null;
            }

            thePicture.Image = Image.FromFile(Path.Combine(_dir, _matchingFilesInDir[_fileIndex.Value]));
         }
      }

      private void SetFile(string file)
      {
         StopCurrentDiaShow();
         _dir = Path.GetDirectoryName(file);

         int index = -1;
         if (_matchingFilesInDir != null)
         {
            index = Array.IndexOf(_matchingFilesInDir, Path.GetFileName(file));
         }

         _fileIndex = index >= 0 ? index : null;
         LoadFirstPicture();
      }

      private void OnClickedOpenDir(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
         {
            StopCurrentDiaShow();
            _dir = fbd.SelectedPath;
            _fileIndex = null;
            LoadFirstPicture();
         }
      }

      private void OnClickedOpenFile(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
         {
            SetFile(ofd.FileName);
         }
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

      private void StopCurrentDiaShow()
      {
         if (_diaTimer != null)
         {
            _diaTimer.Stop();
            _diaTimer.Elapsed -= OnDiaNextImage;
            _diaTimer.Enabled = false;
            _diaTimer = null;
         }
      }

      private void OnClickedDiaStart(object sender, EventArgs e)
      {
         StartDiaShow();
      }

      private void StartDiaShow()
      {
         StopCurrentDiaShow();

         _diaTimer = new System.Timers.Timer(DiaOptions.ImageShowMilliSecs);
         _diaTimer.Elapsed += OnDiaNextImage;
         _diaTimer.Enabled = true;
         _diaTimer.Start();
      }

      private void OnClickDiaStop(object sender, EventArgs e)
      {
         StopCurrentDiaShow();
      }

      private void OnClickedDiaOptions(object sender, EventArgs e)
      {
         bool hadToStop = _diaTimer != null;
         StopCurrentDiaShow();

         using (var optionDlg = new Options())
         {
            optionDlg.ShowDialog();
         }

         if (hadToStop)
         {
            StartDiaShow();
         }
      }

      private void EnableFullScreen()
      {
         TopMost = true;
         FormBorderStyle = FormBorderStyle.None;
         WindowState = FormWindowState.Maximized;
      }

      private void EnableNormalScreen()
      {
         TopMost = false;
         FormBorderStyle = FormBorderStyle.Sizable;
         WindowState = FormWindowState.Normal;
      }

      private void OnClickedFullScreen(object sender, EventArgs e)
      {
         if (fullScreenToolStripMenuItem.Checked)
         {
            // Disable Full screen:
            fullScreenToolStripMenuItem.Checked = false;
            EnableNormalScreen();
         }
         else
         {
            // enable full screen:
            fullScreenToolStripMenuItem.Checked = true;
            EnableFullScreen();
         }
      }
   }
}