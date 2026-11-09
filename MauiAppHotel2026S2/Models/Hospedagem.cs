namespace MauiAppHotel2026S2.Models
{
    public class Hospedagem
    {
        public string Quarto { get; set; } = "";
        public int Adultos { get; set; }
        public int Criancas { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public double ValorDiaria { get; set; }

        public int Noites
        {
            get { return (CheckOut.Date - CheckIn.Date).Days; }
        }

        public double ValorTotal
        {
            get { return Noites * ValorDiaria; }
        }
    }
}