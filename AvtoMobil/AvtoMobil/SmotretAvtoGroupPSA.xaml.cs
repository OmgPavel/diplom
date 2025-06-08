using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AvtoMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SmotretAvtoGroupPSA : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        public SmotretAvtoGroupPSA()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(folderPath, "grouppsa.txt")) == true)
            {
                StreamReader outFile = new StreamReader(Path.Combine(folderPath, "grouppsa.txt"));
                zagolovok.Text = outFile.ReadToEnd();
                text.Text = outFile.ReadToEnd();
                outFile.Close();
            }
        }

        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}