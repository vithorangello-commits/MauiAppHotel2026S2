using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel2026S2
{
    public partial class App : Application
    {
        // Lista de acomodações (igual ao exemplo do professor)
        public List<Models.Acomodacao> lista_quartos = new List<Models.Acomodacao>
        {
            new Models.Acomodacao { Descricao = "Standard", ValorDiaria = 150 },
            new Models.Acomodacao { Descricao = "Luxo", ValorDiaria = 250 },
            new Models.Acomodacao { Descricao = "Suíte Master", ValorDiaria = 400 }
        };
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}