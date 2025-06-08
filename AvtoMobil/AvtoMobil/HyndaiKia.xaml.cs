using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AvtoMobil.App;

namespace AvtoMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HyndaiKia : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public HyndaiKia()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            hyndaikialist.ItemsSource = hyndaikiacollection;

        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = hyndaikiacollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            hyndaikialist.ItemsSource = searchresult;
        }

        private async void hyndaikia_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Hyndaikiamobil hyndaikiamobil = hyndaikialist.SelectedItem as Hyndaikiamobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "hyndaikia.txt"));
            outFile.WriteLine(hyndaikiamobil.ZAGOLOVOK);
            outFile.WriteLine(hyndaikiamobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoHyndaiKia());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}