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
    public partial class SomtretAvto : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//место хранения файлов по умолчанию
        public SomtretAvto()
        {
            InitializeComponent();
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        //загрузка и текстового файла текст
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(folderPath, "bmw.txt")) == true)
            {
                StreamReader outFile = new StreamReader(Path.Combine(folderPath, "bmw.txt"));
                zagolovok.Text = outFile.ReadToEnd();
                text.Text = outFile.ReadToEnd();
                outFile.Close();
            }
        }
    }
}