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
    public partial class StoimostStrahovki : ContentPage
    {
        public StoimostStrahovki()
        {
            InitializeComponent();
        }
        //расчитываем страховку
        private void raschet(object sender, EventArgs e)
        {
            double a = 0, b= 0, c = 0, d = 0;
            double x = 5000;
            if (type.SelectedItem == "Ограниченная") a = 1;
            if (type.SelectedItem == "Не ограниченная") a = 1.8;
            if (period.SelectedItem == "3 месяца") b = 0.5;
            if (period.SelectedItem == "4 месяца") b = 0.6;
            if (period.SelectedItem == "5 месяцев") b = 0.65;
            if (period.SelectedItem == "6 месяцев") b = 0.7;
            if (period.SelectedItem == "7 месяцев") b = 0.8;
            if (period.SelectedItem == "8 месяцев") b = 0.9;
            if (period.SelectedItem == "9 месяцев") b = 0.95;
            if (period.SelectedItem == "10 месяцев и более") b = 1;
            if (mosh.SelectedItem == "50 и меньше") c = 0.6;
            if (mosh.SelectedItem == "50 до 70") c = 1;
            if (mosh.SelectedItem == "70 до 100") c = 1.1;
            if (mosh.SelectedItem == "100 до 120") c = 1.2;
            if (mosh.SelectedItem == "120 до 150") c = 1.4;
            if (mosh.SelectedItem == "свыше 150") c = 1.6;
            if (stazh.SelectedItem == "до 22, стаж до 3") d = 1.8;
            if (stazh.SelectedItem == "старше 22, стаж до 3") d = 1.7;
            if (stazh.SelectedItem == "до 22, стаж выше 3") d = 1.6;
            if (stazh.SelectedItem == "старше 22, стаж выше 3") d = 1;
            if (a == 0 || b == 0 || c == 0 || d == 0)
            {
                DisplayAlert("Ошибка", "Не все поля заполнены", "Ок");
                return;
            }
            summ.Text = "Приблизительная сумма страхования = " + Convert.ToString(x * a * b * c * d);
        }
        //возвращение к предыдущей странице
        private async void nazad(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}