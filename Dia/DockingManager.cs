namespace Dia
{
   internal class DockingManager : IDisposable
   {
      private readonly Form _parent;
      private readonly Form _child;

      private int _offsetx;
      private int _offsety;

      private bool _childsPositionValid = true;

      public DockingManager(Form parent, Form child)
      {
         _parent = parent;
         _child = child;

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
            _offsetx = (_parent.Left + _parent.Width) - _child.Left;
            _offsety = (_parent.Top + _parent.Height) - _child.Top;
         }
      }

      private void OnChildMove(object? sender, EventArgs e)
      {
         StoreChildsOffset();
      }

      private void SetChildsPosition()
      {
         _childsPositionValid = false;

         _child.Left = (_parent.Left + _parent.Width) - _offsetx;
         _child.Top = (_parent.Top + _parent.Height) - _offsety;

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
