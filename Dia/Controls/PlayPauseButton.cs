namespace Dia.Controls
{
   internal class PlayPauseButton : Button
   {
      public Image? PlayImage { get; set; }
      public Image? PauseImage { get; set; }

      private bool _isPlaying;
      public bool IsPlaying
      {
         get => _isPlaying;
         set
         {
            if (value != _isPlaying)
            {
               _isPlaying = value;
               UpdateImage();
            }
         }
      }

      public void UpdateImage()
      {
         Image = _isPlaying ? PauseImage : PlayImage;
      }
   }
}
