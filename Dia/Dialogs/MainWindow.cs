namespace Dia.Dialogs
{
   public partial class MainWindow : Form
   {
      private DiaController _diaController;
      private ChildWindow<ToolDiaControl> _diaControl;
      private ChildWindow<ImageList> _imageList;

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

         _diaControl = new ChildWindow<ToolDiaControl>(
            diaControllerToolStripMenuItem, 
            this, 
            () => new ToolDiaControl(_diaController, customPictureBox1), 
            (diaControl) => { SetDiaControlPosition(diaControl); }
         );

         _imageList = new ChildWindow<ImageList>(
            imageQueueToolStripMenuItem,
            this,
            () => new ImageList(),
            (_) => { }
         );

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

      private void OnClickedImageQueue(object sender, EventArgs e)
      {
         ImageList imgList = new ImageList();
         imgList.ShowDialog();
      }

      private void _diaControl_FormClosed(object? sender, FormClosedEventArgs e)
      {
         _diaControl = null;
         diaControllerToolStripMenuItem.Checked = false;
      }

      private void OnWindowShown(object sender, EventArgs e)
      {
         _diaControl.ShowChildWindow();
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