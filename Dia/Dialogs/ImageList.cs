namespace Dia.Dialogs
{
   public partial class ImageList : Form
   {
      private DiaController _diaController;

      public ImageList(DiaController diaController)
      {
         InitializeComponent();

         _diaController = diaController;
         _diaController.MatchingFilesReloaded += _diaController_MatchingFilesReloaded;
         _diaController.LoadFile += _diaController_LoadFile;

         InitializeList();
      }

      private void _diaController_MatchingFilesReloaded()
      {
         InitializeList();
      }

      private void _diaController_LoadFile(string file)
      {
         SetListViewSelection();
      }

      private void InitializeList()
      {
         lstImages.Items.Clear();

         if (_diaController.MatchingFilesInDir != null)
         {
            foreach (var file in _diaController.MatchingFilesInDir)
            {
               lstImages.Items.Add(file);
            }

            SetListViewSelection();
         }
      }

      private void SetListViewSelection()
      {
         lstImages.SelectedIndices.Clear();

         ListViewItem lvi = lstImages.FindItemWithText(_diaController.CurrentImageFileName);
         if (lvi != null)
         {
            lvi.Selected = true;
            lvi.EnsureVisible();
            lstImages.Select();
         }
      }
   }
}
