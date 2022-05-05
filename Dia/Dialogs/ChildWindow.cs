namespace Dia.Dialogs
{
   internal class ChildWindow<TChild> where TChild : Form
   {
      private readonly ToolStripMenuItem _toolStripOption;
      private readonly Form _parent;
      private readonly Func<TChild> _childFactory;
      private readonly Action<TChild>? _startPositionSetter;

      private TChild? _childWnd;
      private DockingManager? _childsDockingManager;
      private DockingManager.DockToEnum _dockTo;

      public ChildWindow(ToolStripMenuItem toolStripOption, Form parent, Func<TChild> childFactory, Action<TChild>? startPositionSetter, DockingManager.DockToEnum dockTo)
      {
         _toolStripOption = toolStripOption;
         _parent = parent;
         _childFactory = childFactory;
         _startPositionSetter = startPositionSetter;
         _dockTo = dockTo;

         _toolStripOption.Click += _toolStripOption_Click;
      }

      private void _toolStripOption_Click(object? sender, EventArgs e)
      {
         if (_toolStripOption.Checked)
         {
            CloseChildWindow();
         }
         else
         {
            ShowChildWindow();
         }
      }

      public void ShowChildWindow()
      {
         if (_childWnd == null)
         {
            _childWnd = _childFactory.Invoke();
            _childWnd.FormClosed += _childWnd_FormClosed;
            _startPositionSetter?.Invoke(_childWnd);
            _childsDockingManager = new DockingManager(_parent, _childWnd, _dockTo);
            _childWnd.Show(_parent);
         }

         _toolStripOption.Checked = true;
      }

      private void CloseChildWindow()
      {
         if (_childWnd != null)
         {
            _childWnd.FormClosed -= _childWnd_FormClosed;
            _childWnd.Close();
            _childWnd = null;
            _childsDockingManager?.Dispose();
            _childsDockingManager = null;
         }

         _toolStripOption.Checked = false;
      }

      private void _childWnd_FormClosed(object? sender, FormClosedEventArgs e)
      {
         _childWnd!.FormClosed -= _childWnd_FormClosed;
         _childWnd!.Close();
         _childWnd = null;
         _childsDockingManager?.Dispose();
         _childsDockingManager = null;

         _toolStripOption.Checked = false;
      }
   }
}
