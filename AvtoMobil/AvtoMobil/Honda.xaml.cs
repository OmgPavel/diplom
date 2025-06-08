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
    public partial class Honda : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Honda()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            hondalist.ItemsSource = hondacollection;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = hondacollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            hondalist.ItemsSource = searchresult;
        }

        private async void honda_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Hondamobil hondamobil = hondalist.SelectedItem as Hondamobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "honda.txt"));
            outFile.WriteLine(hondamobil.ZAGOLOVOK);
            outFile.WriteLine(hondamobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoHonda());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}