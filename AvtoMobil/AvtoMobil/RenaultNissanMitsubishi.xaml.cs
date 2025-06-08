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
    public partial class RenaultNissanMitsubishi : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public RenaultNissanMitsubishi()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            renaultnissanmisubishilist.ItemsSource = renaultnissanmitsubishicollection;

        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = renaultnissanmitsubishicollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            renaultnissanmisubishilist.ItemsSource = searchresult;
        }

        private async void renaultnissanmisubishi_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            RenaultNissanMistsubishimodil renaultNissanMistsubishimodil = renaultnissanmisubishilist.SelectedItem as RenaultNissanMistsubishimodil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "renaultnissanmisubishi.txt"));
            outFile.WriteLine(renaultNissanMistsubishimodil.ZAGOLOVOK);
            outFile.WriteLine(renaultNissanMistsubishimodil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoRenaultNissanMitsubishi());
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}