namespace Dia
{
   internal static class HotKeyHelper
   {
      public static void AddHotkey(MenuStrip menustrip, Keys shortcut, EventHandler handler)
      {
         var item = new ToolStripMenuItem();
         item.ShortcutKeys = shortcut;
         item.Click += handler;
         menustrip.Items.Add(item);
      }
   }
}
