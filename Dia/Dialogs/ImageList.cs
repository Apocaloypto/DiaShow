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
         Invoke(() =>
         {
            InitializeList();
         });
      }

      private void _diaController_LoadFile(string file)
      {
         Invoke(() =>
         {
            SetListViewSelection();
         });
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

      private void OnClick(object sender, EventArgs e)
      {
         if (lstImages.SelectedItems.Count >= 1)
         {
            ListViewItem selected = lstImages.SelectedItems[0];
            if (selected != null && !string.IsNullOrEmpty(selected.Text))
            {
               _diaController.TrySetCurrentFile(selected.Text);
            }
         }
      }
   }
}
