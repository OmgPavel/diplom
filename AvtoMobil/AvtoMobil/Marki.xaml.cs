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
    public partial class Marki : ContentPage
    {
        public Marki()
        {
            InitializeComponent();
        }
        //открытие страницы
        private async void BMW(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BMW());
        }

        private async void Suzuki(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Suzuki());
        }

        private async void Group_PSA(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GroupPSA());
        }

        private async void Fiat_Chrysler_Automobiles(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new FCA());
        }

        private async void Honda_Motor(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Honda());
        }

        private async void Ford_Motor(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Ford());
        }

        private async void Hyndai_Kia(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new HyndaiKia());
        }

        private async void General_Motors(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new GeneralMotors());
        }

        private async void Toyota(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Toyota());
        }

        private async void VAG(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new VAG());
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void Renault_Nissan_Mitsubishi(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RenaultNissanMitsubishi());
        }

        private async void Mercedes_Benz(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MercedesBenz());
        }
    }
}