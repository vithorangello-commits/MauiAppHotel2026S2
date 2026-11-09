using MauiAppHotel2026S2.Models;

namespace MauiAppHotel2026S2.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        public ContratacaoHospedagem()
        {
            InitializeComponent();

            // Lista de acomodações do Picker
            pck_quarto.ItemsSource = new List<string>
            {
                "Standard",
                "Luxo",
                "Suíte Master"
            };

            // Datas iniciais
            dtp_checkin.MinimumDate = DateTime.Today;
            dtp_checkin.Date = DateTime.Today;

            dtp_checkout.MinimumDate = DateTime.Today.AddDays(1);
            dtp_checkout.Date = DateTime.Today.AddDays(1);
        }

        private void Adultos_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            lbl_adultos.Text = e.NewValue.ToString("0");
        }

        private void Criancas_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            lbl_criancas.Text = e.NewValue.ToString("0");
        }

        private async void Calcular_Clicked(object? sender, EventArgs e)
        {
            // Pega as datas (se vier nulo, usa as datas padrão)
            DateTime checkIn = dtp_checkin.Date ?? DateTime.Today;
            DateTime checkOut = dtp_checkout.Date ?? DateTime.Today.AddDays(1);

            if (stp_adultos.Value < 1)
            {
                await DisplayAlertAsync("Atenção", "Informe pelo menos 1 adulto!", "OK");
                return;
            }

            if (pck_quarto.SelectedIndex == -1)
            {
                await DisplayAlertAsync("Atenção", "Selecione a acomodação!", "OK");
                return;
            }

            if (checkOut <= checkIn)
            {
                await DisplayAlertAsync("Atenção", "O check-out deve ser depois do check-in!", "OK");
                return;
            }

            string quarto = pck_quarto.SelectedItem?.ToString() ?? "";

            double diaria = 400;
            if (quarto == "Standard") diaria = 150;
            if (quarto == "Luxo") diaria = 250;

            Hospedagem h = new Hospedagem
            {
                Quarto = quarto,
                Adultos = (int)stp_adultos.Value,
                Criancas = (int)stp_criancas.Value,
                CheckIn = checkIn,
                CheckOut = checkOut,
                ValorDiaria = diaria
            };

            // Envia os dados para a tela Resumo usando BindingContext
            Resumo telaResumo = new Resumo();
            telaResumo.BindingContext = h;
            await Navigation.PushAsync(telaResumo);
        }

        private async void Sobre_Clicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}