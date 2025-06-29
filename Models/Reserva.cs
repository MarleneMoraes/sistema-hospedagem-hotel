namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Hospede> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(List<Hospede> hospedes, Suite suite, int diasReservados)
        {
            if (hospedes == null || !hospedes.Any())
            {
                throw new ArgumentException("A reserva deve ter pelo menos um hóspede.");
            }

            if (suite == null)
            {
                throw new ArgumentException("Uma suíte deve ser especificada para a reserva.");
            }

            if (hospedes.Count > suite.Capacidade)
            {
                throw new ArgumentException($"O número de hóspedes ({hospedes.Count}) excede a capacidade da suíte {suite.TipoSuite} ({suite.Capacidade}).");
            }

            if (diasReservados <= 0)
            {
                throw new ArgumentException("O número de dias reservados deve ser maior que zero.");
            }

            Hospedes = hospedes;
            Suite = suite;
            DiasReservados = diasReservados;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes?.Count ?? 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            if (DiasReservados >= 10)
            {
                valor *= 0.90;
            }

            return valor;
        }
    }
}