using WebP.Net;

namespace Dia
{
   internal static class ImageLoader
   {
      private static bool CheckHeader(FileStream file, string header)
      {
         try
         {
            int iHeader = 0;
            for (; iHeader < header.Length; iHeader++)
            {
               if (header[iHeader] != (char)file.ReadByte())
               {
                  return false;
               }
            }

            return iHeader == header.Length;
         }
         catch
         {
            return false;
         }
      }

      private static bool Pad(FileStream file, uint len)
      {
         try
         {
            for (int i = 0; i < len; i++)
            {
               _ = file.ReadByte();
            }

            return true;
         }
         catch
         {
            return false;
         }
      }

      private static bool CheckWebPHeader(string file)
      {
         using (var stream = File.OpenRead(file))
         {
            return CheckHeader(stream, "RIFF") && Pad(stream, 4) && CheckHeader(stream, "WEBP");
         }
      }

      private static bool IsWebP(string file)
      {
         if (Path.GetExtension(file).ToUpper() == ".WEBP")
         {
            return true;
         }
         else if (CheckWebPHeader(file))
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      private static Image LoadWebP(string file)
      {
         byte[] content = File.ReadAllBytes(file);
         using (var webp = new WebPObject(content))
         {
            return (Image)webp.GetImage().Clone();
         }
      }

      public static Image Load(string file)
      {
         if (IsWebP(file))
         {
            return LoadWebP(file);
         }
         else
         {
            return Image.FromFile(file);
         }
      }
   }
}
