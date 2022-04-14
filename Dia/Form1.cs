namespace Dia
{
   public partial class Form1 : Form
   {
      private DiaController _diaController;
      private ToolDiaControl? _diaControl;

      public Form1(string? initialFile = null)
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
      }

      private void OnClickedOpenDir(object sender, EventArgs e)
      {
         FolderBrowserDialog fbd = new FolderBrowserDialog();
         if (fbd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
         {
            _diaController.SetContext_Dir(fbd.SelectedPath);
         }
      }

      private void OnClickedOpenFile(object sender, EventArgs e)
      {
         OpenFileDialog ofd = new OpenFileDialog();
         if (ofd.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(ofd.FileName))
         {
            _diaController.SetContext_File(ofd.FileName);
         }
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

      private void OnClickedDiaController(object sender, EventArgs e)
      {
         if (diaControllerToolStripMenuItem.Checked)
         {
            // Hide Dia-Control:
            if (_diaControl != null)
            {
               _diaControl.FormClosed -= _diaControl_FormClosed;
               _diaControl.Close();
               _diaControl = null;
            }

            diaControllerToolStripMenuItem.Checked = false;
         }
         else
         {
            if (_diaControl == null)
            {
               _diaControl = new ToolDiaControl(_diaController);
               _diaControl.FormClosed += _diaControl_FormClosed;
               _diaControl.Show(this);
            }

            diaControllerToolStripMenuItem.Checked = true;
         }
      }

      private void _diaControl_FormClosed(object? sender, FormClosedEventArgs e)
      {
         _diaControl = null;
         diaControllerToolStripMenuItem.Checked = false;
      }
   }
}