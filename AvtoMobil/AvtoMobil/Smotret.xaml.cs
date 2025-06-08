using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AvtoMobil.App;

namespace AvtoMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Serializable]
    public partial class Smotret : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public Smotret()
        {
            InitializeComponent();
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            //BinaryFormatter bf2 = new BinaryFormatter();
            //using (Stream reader = new FileStream(Path.Combine(folderPath, "avtoproizvoditeli.txt"), FileMode.Open))
            //{
            //    zagolovok.Text = reader.ReadLine();
            //       name.Text = outFile.ReadLine();
            //       history.Text = outFile.ReadLine();
            //        outFile.Close();
            //    //proizvoditelycollection = (ObservableCollection<Proizvoditely>)bf2.Deserialize(reader);
            //    //reader.Close();
            //}
            if (File.Exists(Path.Combine(folderPath, "avtoproizvoditeli.txt")) == true)
            {
                StreamReader outFile = new StreamReader(Path.Combine(folderPath, "avtoproizvoditeli.txt"));
                zagolovok.Text = outFile.ReadToEnd();
                name.Text = outFile.ReadToEnd();
                history.Text = outFile.ReadToEnd();
                outFile.Close();
            }
        }
    }
}