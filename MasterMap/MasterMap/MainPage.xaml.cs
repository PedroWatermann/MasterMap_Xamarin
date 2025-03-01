using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace MasterMap
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        private async void btnMapa_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(entLocal.Text) || string.IsNullOrEmpty(entCidade.Text) || string.IsNullOrEmpty(entUf.Text) || string.IsNullOrEmpty(entPais.Text))
                {
                    await DisplayAlert("Aviso", "Preencha todos os campos!", "OK");
                    return;
                }

                string local = entLocal.Text;
                string cidade = entCidade.Text;
                string estado = entUf.Text;
                string pais = entPais.Text;

                Placemark placemark = new Placemark
                {
                    CountryName = pais,
                    AdminArea = estado,
                    Locality = cidade,
                    Thoroughfare = local,
                };
                var options = new MapLaunchOptions
                {
                    Name = "Localização",
                    NavigationMode = NavigationMode.Walking
                };

                await Map.OpenAsync(placemark, options);
            }
            catch (Exception er)
            {
                await DisplayAlert("Erro", er.Message, "OK");
            }
        }
    }
}
