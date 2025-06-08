using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AvtoMobil
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Strahovka : ContentPage
    {
        public Strahovka()
        {
            InitializeComponent();
        }
        //открытие страцы с чтением информации
        private async void infostrah(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new InfoStrah());
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        //открытие формы для расчёта страхования автомобиля
        private async void raschet(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StoimostStrahovki());
        }
    }
}