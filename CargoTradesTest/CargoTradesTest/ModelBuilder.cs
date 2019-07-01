using Shared;
using Xamarin.Forms;

namespace CargoTradesTest
{
    public class ModelBuilder
    {
        public Client client = new Client();

        public Model GetModel()
        {
            var model = new Model();
            model.SendData = new Command(() => client.SendData(new MyData(){Data = model.Data}));
            model.GetData = new Command(async () => model.Data = await client.GetData());

            return model;
        }
    }
}