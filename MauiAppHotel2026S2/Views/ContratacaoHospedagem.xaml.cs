using MauiAppHotel2026S2.Models;

namespace MauiAppHotel2026S2.Views
{
    public partial class ContratacaoHospedagem : ContentPage
    {
        // Acesso às propriedades do App (onde está a lista de quartos)
        App PropriedadesApp;

        public ContratacaoHospedagem()
        {
            InitializeComponent();

            PropriedadesApp = (App)Application.Current!;

            // Carrega o Picker com a List de objetos
            pck_quarto.ItemsSource = PropriedadesApp.lista_quartos;

            // Check-in: de hoje até 1 ano à frente
            dtpck_checkin.MinimumDate = DateTime.Today;
            dtpck_checkin.MaximumDate = DateTime.Today.AddYears(1);
            dtpck_checkin.Date = DateTime.Today;

            // Check-out: de check-in + 1 dia até check-in + 6 meses
            AtualizarLimitesCheckout();
        }

        // Define os limites do check-out com base na data do check-in
        private void AtualizarLimitesCheckout()
        {
            DateTime checkIn = dtpck_checkin.Date ?? DateTime.Today;

            // Abre os limites antes, para não dar erro de intervalo
            dtpck_checkout.MinimumDate = new DateTime(1900, 1, 1);
            dtpck_checkout.MaximumDate = new DateTime(2100, 12, 31);

            DateTime minimo = checkIn.AddDays(1);

            dtpck_checkout.MinimumDate = minimo;
            dtpck_checkout.MaximumDate = checkIn.AddMonths(6);

            if ((dtpck_checkout.Date ?? minimo) < minimo)
            {
                dtpck_checkout.Date = minimo;
            }
        }

        private void dtpck_checkin_DateSelected(object? sender, DateChangedEventArgs e)
        {
            AtualizarLimitesCheckout();
        }

        private void Adultos_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            lbl_adultos.Text = e.NewValue.ToString("0");
        }

        private void Criancas_ValueChanged(object? sender, ValueChangedEventArgs e)
        {
            lbl_criancas.Text = e.NewValue.ToString("0");
        }

        private async void Avancar_Clicked(object? sender, EventArgs e)
        {
            try
            {
                DateTime checkIn = dtpck_checkin.Date ?? DateTime.Today;
                DateTime checkOut = dtpck_checkout.Date ?? DateTime.Today.AddDays(1);

                if (stp_adultos.Value < 1)
                {
                    await DisplayAlertAsync("Atenção", "Informe pelo menos 1 adulto!", "OK");
                    return;
                }

                Acomodacao? escolhida = pck_quarto.SelectedItem as Acomodacao;

                if (escolhida == null)
                {
                    await DisplayAlertAsync("Atenção", "Selecione a acomodação!", "OK");
                    return;
                }

                if (checkOut <= checkIn)
                {
                    await DisplayAlertAsync("Atenção", "O check-out deve ser depois do check-in!", "OK");
                    return;
                }

                Hospedagem h = new Hospedagem
                {
                    Quarto = escolhida.Descricao,
                    Adultos = (int)stp_adultos.Value,
                    Criancas = (int)stp_criancas.Value,
                    CheckIn = checkIn,
                    CheckOut = checkOut,
                    ValorDiaria = escolhida.ValorDiaria
                };

                // Envia os dados para a tela Resumo usando BindingContext
                Resumo telaResumo = new Resumo();
                telaResumo.BindingContext = h;
                await Navigation.PushAsync(telaResumo);
            }
            catch (Exception ex)
            {
                await DisplayAlertAsync("Ops", ex.Message, "OK");
            }
        }

        private async void Reservas_Clicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new MinhasReservas());
        }

        private async void Sobre_Clicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new Sobre());
        }
    }
}