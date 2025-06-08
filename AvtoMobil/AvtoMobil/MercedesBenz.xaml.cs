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
    public partial class MercedesBenz : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        public MercedesBenz()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            mercedesbenzlist.ItemsSource = mercedesbenzcollection;
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = mercedesbenzcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            mercedesbenzlist.ItemsSource = searchresult;
        }

        private async void mercedesbenz_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            MercedesBenzmobil mercedesBenzmobil = mercedesbenzlist.SelectedItem as MercedesBenzmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "mercedesbenz.txt"));
            outFile.WriteLine(mercedesBenzmobil.ZAGOLOVOK);
            outFile.WriteLine(mercedesBenzmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoMercedesBenz());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}