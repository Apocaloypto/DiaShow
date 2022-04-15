namespace Dia
{
   public partial class MainWindow : Form
   {
      private DiaController _diaController;
      private ToolDiaControl? _diaControl;

      public MainWindow(string? initialFile = null)
      {
         InitializeComponent();

         _diaController = new DiaController(OnLoadFile, initialFile);

         EnableNormalScreen();
      }

      private void OnLoadFile(string filename)
      {
         if (thePicture.Image != null)
         {
            thePicture.Image.Dispose();
            thePicture.Image = null;
         }

         thePicture.Image = Image.FromFile(filename);

         UpdateStatusBar();
      }

      private void UpdateStatusBar()
      {
         toolStripStatusLabel1.Text = _diaController.StatusText;
         statusStrip1.Refresh();
      }

      private void OnClickedOpenDir(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
         {
            _diaController.SetContext_Dir(fbd.SelectedPath);
         }

         UpdateStatusBar();
      }

      private void OnClickedOpenFile(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
         {
            _diaController.SetContext_File(ofd.FileName);
         }

         UpdateStatusBar();
      }

      private void OnClickedDiaOptions(object sender, EventArgs e)
      {
         bool hadToStop = _diaController.StopDiaShow();

         bool hadFullScreen = EnableNormalScreen();

         using (var optionDlg = new Options())
         {
            optionDlg.ShowDialog();
         }

         if (hadFullScreen)
         {
            EnableFullScreen();
         }

         if (hadToStop)
         {
            _diaController.StartDiaShow();
         }
      }

      private void EnableFullScreen()
      {
         TopMost = true;
         FormBorderStyle = FormBorderStyle.None;
         WindowState = FormWindowState.Maximized;
      }

      private bool EnableNormalScreen()
      {
         if (TopMost)
         {
            TopMost = false;
            FormBorderStyle = FormBorderStyle.Sizable;
            WindowState = FormWindowState.Normal;
            return true;
         }
         else
         {
            return false;
         }
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

      private void SetDiaControlPosition(ToolDiaControl control)
      {
         const int SAFE_SPACE = 20;

         control.Top = ((Top + Height) - control.Height) - SAFE_SPACE;
         control.Left = ((Left + Width) - control.Width) - SAFE_SPACE;
      }

      private void OnClickedDiaController(object sender, EventArgs e)
      {
         if (diaControllerToolStripMenuItem.Checked)
         {
            // Hide Dia-Control:
            CloseDiaControlToolWindow();
         }
         else
         {
            OpenDiaControlToolWindow();
         }
      }

      private void CloseDiaControlToolWindow()
      {
         if (_diaControl != null)
         {
            _diaControl.FormClosed -= _diaControl_FormClosed;
            _diaControl.Close();
            _diaControl = null;
         }

         diaControllerToolStripMenuItem.Checked = false;
      }

      private void OpenDiaControlToolWindow()
      {
         if (_diaControl == null)
         {
            _diaControl = new ToolDiaControl(_diaController);
            _diaControl.FormClosed += _diaControl_FormClosed;
            SetDiaControlPosition(_diaControl);
            _diaControl.Show(this);
         }

         diaControllerToolStripMenuItem.Checked = true;
      }

      private void _diaControl_FormClosed(object? sender, FormClosedEventArgs e)
      {
         _diaControl = null;
         diaControllerToolStripMenuItem.Checked = false;
      }

      private void OnWindowShown(object sender, EventArgs e)
      {
         OpenDiaControlToolWindow();
      }
   }
}