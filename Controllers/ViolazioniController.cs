using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5L5.Models;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace S5L5.Controllers
{
    public class ViolazioniController : Controller
    {
        private string connString = "Server=DESKTOP-367Q1CC\\SQLEXPRESS; Initial Catalog=Prova Weekly; Integrated Security=true; TrustServerCertificate=True";

        List<Violazioni> violazione = new List<Violazioni>();
        List<Trasgressori> tra = new List<Trasgressori>();
        public IActionResult Index()
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var cmd = new SqlCommand($"SELECT * FROM [TIPO VIOLAZIONE]", conn);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var viol = new Violazioni()
                {
                    idviolazione = (int)reader["idviolazione"],
                    Descrizione = (string)reader["Descrizione"]
                };
                violazione.Add(viol);
            }
            conn.Close();
            conn.Open();
            var cmd2 = new SqlCommand($"SELECT * FROM ANAGRAFICA ", conn);
            var reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                var temp = new Trasgressori()
                {
                    Cognome = (string)reader2["Cognome"],
                    Nome = (string)reader2["Nome"],
                    idanagrafica = (int)reader2["idanagrafica"]
                };
                tra.Add(temp);
            }
            conn.Close();
            ViewBag.Trasgressori = tra;
            ViewBag.Violazione = violazione;
            return View();
        }
        [HttpPost]
        public IActionResult Add(Verbali temp)
        {


            var conn = new SqlConnection(connString);
            conn.Open();
            var command = new SqlCommand("INSERT INTO VERBALE (DataViolazione, IndirizzoViolazione, Nominativo_Agente, DataTrascrizioneVerbale, Importo, DecurtamentoPunti,idviolazione,idanagrafica) VALUES (@DataV ,@Indirizzo, @Nominativo, @DataT, @Importo, @Decurtamento,@idV,@idT)", conn);
            command.Parameters.AddWithValue("@DataV", temp.DataViolazione);
            command.Parameters.AddWithValue("@Indirizzo", temp.IndirizzoViolazione);
            command.Parameters.AddWithValue("@Nominativo", temp.Nominativo_Agente);
            command.Parameters.AddWithValue("@DataT", temp.DataTrascrizioneVerbale);
            command.Parameters.AddWithValue("@Importo", temp.Importo);
            command.Parameters.AddWithValue("@Decurtamento", temp.DecurtamentoPunti);
            command.Parameters.AddWithValue("@idV", temp.idviolazione);
            command.Parameters.AddWithValue("@idT", temp.idanagrafica);
            command.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");

        }
    }
}
