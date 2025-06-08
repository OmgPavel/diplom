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
    public partial class FCA : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public FCA()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            fcalist.ItemsSource = FCAcollection;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = FCAcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            fcalist.ItemsSource = searchresult;
        }

        private async void fca_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            FCAmobil fCAmobil = fcalist.SelectedItem as FCAmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "fca.txt"));
            outFile.WriteLine(fCAmobil.ZAGOLOVOK);
            outFile.WriteLine(fCAmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoFCA());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}