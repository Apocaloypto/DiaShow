namespace Dia.Dialogs
{
   public partial class MainWindow : Form
   {
      private DiaController _diaController;
      private ToolDiaControl? _diaControl;
      private DockingManager? _dockingManager;

      public MainWindow(string? initialFile = null)
      {
         InitializeComponent();

         _diaController = new DiaController(OnLoadFile, initialFile);
         UpdateStatusBar();

         EnableNormalScreen();
      }

      private void OnLoadFile(string filename)
      {
         Image? newImage = null;
         try
         {
            newImage = Image.FromFile(filename);
         }
         catch (Exception ex)
         {
            MessageBox.Show($"Failed to load image '{filename}': {ex.Message}");
            return;
         }

         Image? oldImage = thePicture.Image;

         if (newImage != null)
         {
            thePicture.Image = newImage;
         }

         if (oldImage != null)
         {
            oldImage.Dispose();
         }

         UpdateStatusBar();
      }

      private void UpdateStatusBar()
      {
         toolStripStatusLabel1.Text = _diaController?.StatusText;
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

      private void EnableFullScreen()
      {
         if (WindowState == FormWindowState.Maximized)
         {
            WindowState = FormWindowState.Normal;
         }

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
            _dockingManager?.Dispose();
            _dockingManager = null;
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
            _dockingManager = new DockingManager(this, _diaControl);
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

      private void OnClickedOpenInEditor(object sender, EventArgs e)
      {
         _diaController.OpenCurrentImageInEditor();
      }

      private void OnClickedOptions(object sender, EventArgs e)
      {
         using (var dlg = new GlobalOptions())
         {
            dlg.ShowDialog();
         }
      }
   }
}