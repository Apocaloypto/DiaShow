namespace Dia.Dialogs
{
   public partial class ImageList : Form
   {
      private DiaController _diaController;

      public ImageList(DiaController diaController)
      {
         InitializeComponent();

         _diaController = diaController;
         _diaController.ContextChanged += _diaController_ContextChanged;
         _diaController.LoadFile += _diaController_LoadFile;
      }

      private void _diaController_LoadFile(string obj)
      {
      }

      private void _diaController_ContextChanged(bool obj)
      {
      }
   }
}
