namespace MauiAppHotel2026S2.Models
{
    public class Acomodacao
    {
        private double _valorDiaria;

        public string Descricao { get; set; } = "";

        // Propriedade com validação (get/set): não aceita valor negativo
        public double ValorDiaria
        {
            get { return _valorDiaria; }
            set
            {
                if (value >= 0)
                    _valorDiaria = value;
            }
        }

        // É o texto que aparece no Picker
        public override string ToString()
        {
            return $"{Descricao} - R$ {ValorDiaria:N2}";
        }
    }
}