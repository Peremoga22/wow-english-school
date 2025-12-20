using System.Globalization;

namespace WowApp.Services
{
    public class CultureStateService
    {
        public event Action? OnChange;

        public CultureInfo CurrentCulture { get; private set; } 
            = CultureInfo.CurrentUICulture;

        public void SetCulture(string culture)
        {
            CurrentCulture = new CultureInfo(culture);
            OnChange?.Invoke();
        }
    }
}
