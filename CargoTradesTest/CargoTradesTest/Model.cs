using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CargoTradesTest
{
    public class Model
    {
        public string Data { get; set; }
        public ICommand SendData { get; set; }
        public ICommand GetData { get; set; }
    }

    public class ModelBuilder
    {
        public Client client = new Client();

        public Model GetModel()
        {
            var model = new Model();
            model.SendData = new Command(() => client.SendData(model.Data));
            model.GetData = new Command(() => model.Data = client.GetData());

        }
    }

    public class Client
    {
        public void SendData(string data)
        {

        }

        public string GetData()
        {

        }
    }
}
