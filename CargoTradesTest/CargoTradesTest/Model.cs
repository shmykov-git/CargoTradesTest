using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace CargoTradesTest
{
    public class Model : INotifyPropertyChanged
    {
        private string data;

        public string Data
        {
            get => data;
            set
            {
                data = value;
                OnPropertyChanged();
            }
        }

        public ICommand SendData { get; set; }
        public ICommand GetData { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
