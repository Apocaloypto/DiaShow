namespace Dia.Controls
{
   public partial class CustomPictureBox : UserControl
   {
      private int _initialWidth;
      private int _initialHeight;

      public CustomPictureBox()
      {
         InitializeComponent();
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

      private void ResizeImageTo(float newHeight)
      {
         float rel = (float)thePicture.Image.Width / thePicture.Image.Height;

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
      }

      public void Zoom(float factor)
      {
         if (thePicture.Image != null)
         {
            ResizeImageTo(_initialHeight * factor);
         }
      }
   }
}
