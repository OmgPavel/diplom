using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AvtoMobil.App;

namespace AvtoMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Serializable]
    public partial class Avtoproizvoditeli : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);//место хранения файлов по умолчанию
        public Avtoproizvoditeli()
        {
            InitializeComponent();
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        //загрузка коллекции автопроизводителей
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            proizvoditely.ItemsSource = proizvoditelycollection;
        }
        //поиск элементов в коллекции
        private void search_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchresult = proizvoditelycollection.Where(c => c.ZAGOLOVOK.ToLower().Contains(search.Text.ToLower()));
            proizvoditely.ItemsSource = searchresult;
        }
        //нажатие на элемент в ListView и открытие формы для чтения информации
        private async void proizvoditely_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Proizvoditely avtoproizvoditeli = proizvoditely.SelectedItem as Proizvoditely;
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "avtoproizvoditeli.txt"));
            outFile.WriteLine(avtoproizvoditeli.ZAGOLOVOK);
            outFile.WriteLine(avtoproizvoditeli.NAME);
            outFile.WriteLine(avtoproizvoditeli.HISTORY);
            outFile.Close();
            await Navigation.PushModalAsync(new Smotret());
        }
    }
}