namespace S5L5.Models
{
    public class Verbali
    {
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string Nominativo_Agente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public int Importo { get; set; }
        public int DecurtamentoPunti { get; set; }

        public string Descrizione { get; set; }
        public int idviolazione { get; set; }
        public int idanagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
    }
}
