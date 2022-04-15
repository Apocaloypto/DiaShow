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
         return CurrentValue?.ToString() ?? string.Empty;
      }

      public void Deserialize(string? input)
      {
         if (!string.IsNullOrWhiteSpace(input))
         {
            try
            {
               CurrentValue = (T)Convert.ChangeType(input, typeof(T));
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
