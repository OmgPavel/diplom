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
    public partial class Suzuki : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public Suzuki()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            suzuki.ItemsSource = suzukicollection;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = suzukicollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            suzuki.ItemsSource = searchresult;
        }

        private async void suzuki_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Suzukimobil suzukimobil = suzuki.SelectedItem as Suzukimobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "suzuki.txt"));
            outFile.WriteLine(suzukimobil.ZAGOLOVOK);
            outFile.WriteLine(suzukimobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoSuzuki());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}