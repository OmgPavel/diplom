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
    public partial class Toyota : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Toyota()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            toyotalist.ItemsSource = toyotacollection;

        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = toyotacollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            toyotalist.ItemsSource = searchresult;
        }

        private async void toyota_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Toyotamodbil toyotamodbil = toyotalist.SelectedItem as Toyotamodbil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "toyota.txt"));
            outFile.WriteLine(toyotamodbil.ZAGOLOVOK);
            outFile.WriteLine(toyotamodbil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoToyota());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}