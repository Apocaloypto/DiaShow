namespace Dia
{
   public class OptionValue<T>
   {
      private readonly T _defaultValue;
      
      public T CurrentValue { get; set; }

      public bool IsCustomized => !EqualityComparer<T>.Default.Equals(CurrentValue, _defaultValue);

      public OptionValue(T defaultValue)
      {
         _defaultValue = defaultValue;
         CurrentValue = defaultValue;
      }

      public void Reset()
      {
         CurrentValue = _defaultValue;
      }

      public string Serialize()
      {
         if (typeof(T).IsEnum)
         {
            if (CurrentValue != null)
            {
               return ((int)(object)CurrentValue).ToString();
            }
            else
            {
               return string.Empty;
            }
         }
         else
         {
            return CurrentValue?.ToString() ?? string.Empty;
         }
      }

      public void Deserialize(string? input)
      {
         if (!string.IsNullOrWhiteSpace(input))
         {
            try
            {
               if (typeof(T).IsEnum)
               {
                  int valAsInt = Convert.ToInt32(input);
                  CurrentValue = (T)(object)valAsInt;
               }
               else
               {
                  CurrentValue = (T)Convert.ChangeType(input, typeof(T));
               }
               return;
            }
            catch
            {
            }
         }

         CurrentValue = _defaultValue;
      }
   }
}
