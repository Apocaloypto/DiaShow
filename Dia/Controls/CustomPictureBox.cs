namespace Dia.Controls
{
   public partial class CustomPictureBox : UserControl
   {
      private int _initialWidth;
      private int _initialHeight;

      private const double FACTOR_MOD = 0.2;
      private const int ZOOM_COOLDOWN_MS = 100;

      private double currentFactor = 1.0;

      public CustomPictureBox()
      {
         InitializeComponent();

         var menu = new MenuStrip();
         var item = new ToolStripMenuItem();
         item.ShortcutKeys = Keys.Control | Keys.NumPad0;
         item.Click += Where_InitialZoom;
         menu.Items.Add(item);
         menu.Visible = false;
         this.Controls.Add(menu);

         RegisterEvents(this);
         RegisterEvents(thePicture);
      }

      public void RegisterEvents(Control where)
      {
         where.MouseWheel += Where_MouseWheel;
      }

      public void UnregisterEvents(Control where)
      {
         where.MouseWheel -= Where_MouseWheel;
      }

      private void Where_InitialZoom(object? sender, EventArgs e)
      {
         InitialZoom();
      }

      private void Where_MouseWheel(object? sender, MouseEventArgs e)
      {
         if (ModifierKeys == Keys.Control)
         {
            int howMany = e.Delta * SystemInformation.MouseWheelScrollLines / 120;
            if (howMany > 0)
            {
               ZoomIn();
               ((HandledMouseEventArgs)e).Handled = true;
            }
            else if (howMany < 0)
            {
               ZoomOut();
               ((HandledMouseEventArgs)e).Handled = true;
            }
         }
      }

      public string CurrentImageDimensions
      {
         get
         {
            if (thePicture.Image != null)
            {
               return $"{thePicture.Image.Width} x {thePicture.Image.Height} px";
            }
            else
            {
               return string.Empty;
            }
         }
      }

      public void ClearImage()
      {
         if (thePicture.Image != null)
         {
            var img = thePicture.Image;
            thePicture.Image = null;
            img.Dispose();
         }
      }

      public void LoadImage(string filename)
      {
         Image? newImage = null;
         try
         {
            newImage = ImageLoader.Load(filename);
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
            InitialZoom();
         }

         if (oldImage != null)
         {
            oldImage.Dispose();
         }
      }

      private void ResizeImageTo(double newHeight)
      {
         double rel = (double)thePicture.Image.Width / thePicture.Image.Height;

         thePicture.Height = (int)newHeight;
         thePicture.Width = (int)(thePicture.Height * rel);

         thePicture.Left = (int)(Width / 2.0 - thePicture.Width / 2.0);
      }

      public void InitialZoom()
      {
         const int ABZUG = 20;

         if (thePicture.Image != null)
         {
            ResizeImageTo(panSize.ClientSize.Height - ABZUG);

            _initialWidth = thePicture.Width;
            _initialHeight = thePicture.Height;
         }

         currentFactor = 1.0;
      }

      private void Zoom(double factor)
      {
         if (thePicture.Image != null)
         {
            ResizeImageTo(_initialHeight * factor);
            currentFactor = factor;
         }
      }

      public void ZoomIn()
      {
         currentFactor += FACTOR_MOD;
         Zoom(currentFactor);
      }

      public void ZoomOut()
      {
         currentFactor -= FACTOR_MOD;
         if (currentFactor <= FACTOR_MOD)
         {
            currentFactor = FACTOR_MOD;
         }

         Zoom(currentFactor);
      }
   }
}
