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
    public partial class GroupPSA : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public GroupPSA()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            grouppsalist.ItemsSource = grouopPSAcollection;
        }

        private async void grouppsa_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            GrouopPSAmobil grouopPSAmobil = grouppsalist.SelectedItem as GrouopPSAmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "grouppsa.txt"));
            outFile.WriteLine(grouopPSAmobil.ZAGOLOVOK);
            outFile.WriteLine(grouopPSAmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SmotretAvtoGroupPSA());
        }

        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = grouopPSAcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            grouppsalist.ItemsSource = searchresult;
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}