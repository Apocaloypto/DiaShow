using System.Text;

namespace Dia
{
   internal static class StringExtensions
   {
      public static bool IsEmpty(this StringBuilder builder)
      {
         return builder.Length == 0;
      }

      public static string JoinNotEmpty(string sep, params string[] values)
      {
         StringBuilder retval = new StringBuilder();
         foreach (string value in values)
         {
            if (!string.IsNullOrEmpty(value))
            {
               if (!retval.IsEmpty())
               {
                  retval.Append(sep);
               }

               retval.Append(value);
            }
         }

         return retval.ToString();
      }
   }
}
