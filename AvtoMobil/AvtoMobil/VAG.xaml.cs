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
    public partial class VAG : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public VAG()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            vaglist.ItemsSource = vagcollection;

        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = vagcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            vaglist.ItemsSource = searchresult;
        }

        private async void vag_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Vagmobil vagmobil = vaglist.SelectedItem as Vagmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "vag.txt"));
            outFile.WriteLine(vagmobil.ZAGOLOVOK);
            outFile.WriteLine(vagmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoVAG());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}