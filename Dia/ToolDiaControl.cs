namespace Dia
{
   public partial class ToolDiaControl : Form
   {
      private DiaController _diaController;

      public ToolDiaControl(DiaController diaController)
      {
         InitializeComponent();

         _diaController = diaController;
         btnPlayPause.IsPlaying = _diaController.IsPlaying;
         btnPlayPause.UpdateImage();
      }

      private void OnClickedPlayPause(object sender, EventArgs e)
      {
         if (_diaController.IsPlaying)
         {
            _diaController.StopDiaShow();
            btnPlayPause.IsPlaying = false;
         }
         else
         {
            _diaController.StartDiaShow();
            btnPlayPause.IsPlaying = true;
         }
      }
   }
}
