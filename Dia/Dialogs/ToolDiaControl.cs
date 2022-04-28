namespace Dia.Dialogs
{
   public partial class ToolDiaControl : Form, IDisposable
   {
      private DiaController _diaController;

      public ToolDiaControl(DiaController diaController)
      {
         InitializeComponent();

         _diaController = diaController;
         btnPlayPause.IsPlaying = _diaController.IsPlaying;
         btnPlayPause.UpdateImage();

         EnableButtons(_diaController.HasValidContext);

         _diaController.ContextChanged += _diaController_ContextChanged;

         options1.DiaController = _diaController;
      }

      private void _diaController_ContextChanged(bool validContext)
      {
         EnableButtons(validContext);
      }

      private void EnableButtons(bool enable)
      {
         btnPlayPause.Enabled = enable;
         btnForward.Enabled = enable;
         btnBack.Enabled = enable;
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

      private void OnBtnClickedNext(object sender, EventArgs e)
      {
         _diaController.NextImage();
      }

      private void OnBtnClickedPrev(object sender, EventArgs e)
      {
         _diaController.PrevImage();
      }
   }
}
