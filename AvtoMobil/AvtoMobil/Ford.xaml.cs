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
    public partial class Ford : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Ford()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            fordlist.ItemsSource = fordcollection;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = fordcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            fordlist.ItemsSource = searchresult;
        }

        private async void ford_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Fordmobil fordmobil = fordlist.SelectedItem as Fordmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "ford.txt"));
            outFile.WriteLine(fordmobil.ZAGOLOVOK);
            outFile.WriteLine(fordmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoFord());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}