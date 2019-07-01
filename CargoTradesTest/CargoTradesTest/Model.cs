using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

    public class ModelBuilder
    {
        public Client client = new Client();

        public Model GetModel()
        {
            var model = new Model();
            model.SendData = new Command(() => client.SendData(model.Data));
            model.GetData = new Command(() => model.Data = client.GetData());

            return model;
        }
    }

    public class Client
    {
        //todo: http
        string v;

        public void SendData(string data)
        {
            v = data;
        }

        public string GetData()
        {
            return v;
        }
    }
}
