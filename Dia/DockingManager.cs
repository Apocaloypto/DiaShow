namespace Dia
{
   internal class DockingManager : IDisposable
   {
      public enum DockToEnum
      {
         TopLeft,
         BottomRight,
      }

      private readonly Form _parent;
      private readonly Form _child;

      private readonly DockToEnum _dockTo;

      private int _offsetx;
      private int _offsety;

      private bool _childsPositionValid = true;

      public DockingManager(Form parent, Form child, DockToEnum dockTo)
      {
         _parent = parent;
         _child = child;
         _dockTo = dockTo;

         StoreChildsOffset();
         _parent.Move += OnParentMove;
         _parent.Resize += OnParentResize;
         _child.Move += OnChildMove;
      }

      public void Dispose()
      {
         _child.Move -= OnChildMove;
         _parent.Resize -= OnParentResize;
         _parent.Move -= OnParentMove;
      }

      private void StoreChildsOffset()
      {
         if (_childsPositionValid)
         {
            if (_dockTo == DockToEnum.BottomRight)
            {
               _offsetx = (_parent.Left + _parent.Width) - _child.Left;
               _offsety = (_parent.Top + _parent.Height) - _child.Top;
            }
            else if (_dockTo == DockToEnum.TopLeft)
            {
               _offsetx = _child.Left - _parent.Left;
               _offsety = _child.Top - _parent.Top;
            }
         }
      }

      private void OnChildMove(object? sender, EventArgs e)
      {
         StoreChildsOffset();
      }

      private void SetChildsPosition()
      {
         _childsPositionValid = false;

         if (_dockTo == DockToEnum.BottomRight)
         {
            _child.Left = (_parent.Left + _parent.Width) - _offsetx;
            _child.Top = (_parent.Top + _parent.Height) - _offsety;
         }
         else if (_dockTo == DockToEnum.TopLeft)
         {
            _child.Left = _parent.Left + _offsetx;
            _child.Top = _parent.Top + _offsety;
         }

         _childsPositionValid = true;
      }

      private void OnParentResize(object? sender, EventArgs e)
      {
         SetChildsPosition();
      }

      private void OnParentMove(object? sender, EventArgs e)
      {
         SetChildsPosition();
      }
   }
}
