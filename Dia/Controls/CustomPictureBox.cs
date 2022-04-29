namespace Dia.Controls
{
   public partial class CustomPictureBox : UserControl
   {
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
         }

         if (oldImage != null)
         {
            oldImage.Dispose();
         }
      }
   }
}
