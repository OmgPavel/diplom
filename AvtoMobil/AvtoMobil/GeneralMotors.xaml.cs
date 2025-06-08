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
    public partial class GeneralMotors : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public GeneralMotors()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            generalmotorslist.ItemsSource = generalmotorscollection;

        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = generalmotorscollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            generalmotorslist.ItemsSource = searchresult;
        }

        private async void generalmotors_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Generalmotorsmobil generalmotorsmobil = generalmotorslist.SelectedItem as Generalmotorsmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "generalmotors.txt"));
            outFile.WriteLine(generalmotorsmobil.ZAGOLOVOK);
            outFile.WriteLine(generalmotorsmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoGeneralMotors());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}