using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AvtoMobil
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        //вывод сообщения о программе
        private void Oprogramme(object sender, EventArgs e)
        {
            DisplayAlert("О программе", "Разработчик Сергей Кучаев \nГруппа ИСП-41", "Ок");
        }
        //открытие страницы автопроизводителей
        private async void avtoproizvoditeli(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Avtoproizvoditeli());
        }
        //открытие страницы марок авто
        private async void markiavto(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Marki());
        }
        //открытие страницы страхования
        private async void strahovanie(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Strahovka());
        }
        //выход
        private void exit(object sender, EventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().CloseMainWindow();
        }
    }
}
