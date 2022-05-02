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

         DiaOptions.LoadFromFile();
         if (DiaOptions.MainWindowState.IsCustomized)
         {
            WindowState = DiaOptions.MainWindowState.CurrentValue;
         }

         _diaController = new DiaController(OnLoadFile, initialFile);
         EnableStatusBarButtons(_diaController.HasValidContext);
         _diaController.ContextChanged += _diaController_ContextChanged;

         customPictureBox1.RegisterEvents(this);

         UpdateStatusBar();

         EnableNormalScreen();
      }

      private void _diaController_ContextChanged(bool validContext)
      {
         EnableStatusBarButtons(validContext);

         if (!validContext)
         {
            customPictureBox1.ClearImage();
         }
      }

      private void EnableStatusBarButtons(bool enable)
      {
         toolStripSplitButtonFirst.Enabled = enable;
         toolStripSplitButtonLast.Enabled = enable;
      }

      private void OnLoadFile(string filename)
      {
         customPictureBox1.LoadImage(filename);
         UpdateStatusBar();
      }

      private void UpdateStatusBar()
      {
         toolStripStatusLabel1.Text = StringExtensions.JoinNotEmpty(", ", _diaController?.StatusText, customPictureBox1.CurrentImageDimensions);
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
            _diaControl = new ToolDiaControl(_diaController, customPictureBox1);
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

      private void OnClosing(object sender, FormClosingEventArgs e)
      {
         DiaOptions.MainWindowState.CurrentValue = WindowState;
         if (DiaOptions.IsCustomized)
         {
            DiaOptions.SaveToFile();
         }
      }

      protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
      {
         if (!customPictureBox1.IsZoomed)
         {
            switch (keyData)
            {
               case Keys.Left:
                  _diaController.PrevImage();
                  return true;
               case Keys.Right:
                  _diaController.NextImage();
                  return true;
            }
         }

         return base.ProcessCmdKey(ref msg, keyData);
      }

      private void OnClickFirstImage(object sender, EventArgs e)
      {
         _diaController.FirstImage();
      }

      private void OnClickLastImage(object sender, EventArgs e)
      {
         _diaController.LastImage();
      }

      private void OnResize(object sender, EventArgs e)
      {
         customPictureBox1.InitialZoom();
      }
   }
}