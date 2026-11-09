using MauiAppHotel2026S2.Models;

namespace MauiAppHotel2026S2.Views
{
    public partial class Resumo : ContentPage
    {
        public Resumo()
        {
            InitializeComponent();
        }

        private async void Confirmar_Clicked(object? sender, EventArgs e)
        {
            // Pega o objeto que veio pelo BindingContext e guarda na lista
            if (BindingContext is Hospedagem h)
            {
                Dados.Reservas.Add(h);
                await DisplayAlertAsync("Reserva confirmada", "Sua reserva foi salva!", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}