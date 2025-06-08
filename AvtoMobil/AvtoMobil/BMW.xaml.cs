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
    public partial class BMW : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//место хранения файлов по умолчанию
        public BMW()
        {
            InitializeComponent();
        }
        //нажатие на элемент в ListView и открытие формы для чтения информации
        private async void bmw_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            BMWmobil bMWmobil = bmw.SelectedItem as BMWmobil;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "bmw.txt"));
            outFile.WriteLine(bMWmobil.ZAGOLOVOK);
            outFile.WriteLine(bMWmobil.TEXT);
            outFile.Close();
            await Navigation.PushModalAsync(new SomtretAvto());
        }
        //поиск элементов в коллекции
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = bmwcollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            bmw.ItemsSource = searchresult;
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        //загрузка коллекции
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            bmw.ItemsSource = bmwcollection;
        }
    }
    }