using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace zaraga.weather
{
    public class PropertyChangedViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged<T>(System.Linq.Expressions.Expression<Func<T>> propertyExpression)
        {
            var memberExpression = (System.Linq.Expressions.MemberExpression)propertyExpression.Body;
            OnPropertyChanged(memberExpression.Member.Name);
        }

    }
}
