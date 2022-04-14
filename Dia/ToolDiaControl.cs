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
   }
}
