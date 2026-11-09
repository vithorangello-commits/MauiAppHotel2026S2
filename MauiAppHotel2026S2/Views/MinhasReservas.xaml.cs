using MauiAppHotel2026S2.Models;

namespace MauiAppHotel2026S2.Views
{
    public partial class MinhasReservas : ContentPage
    {
        public MinhasReservas()
        {
            InitializeComponent();
        }

        // Toda vez que a tela aparece, recarrega a lista
        protected override void OnAppearing()
        {
            base.OnAppearing();
            cv_reservas.ItemsSource = null;
            cv_reservas.ItemsSource = new List<Hospedagem>(Dados.Reservas);
        }
    }
}