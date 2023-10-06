using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GenshinWishCounter1._5.Core
{
    /// <summary>
    /// Base class for observable objects.
    /// This class inherit interfrace INotifyPropertyChanged.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
