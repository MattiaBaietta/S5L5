using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5L5.Models;
using System.Data;
using System.Data.Common;
using System.Dynamic;
namespace S5L5.Controllers
{
    public class VerbaliController : Controller
    {
        List<Verbali> verbale = new List<Verbali>();
        List<string> valoritab = new List<string>();
        private string connString = "Server=DESKTOP-367Q1CC\\SQLEXPRESS; Initial Catalog=Prova Weekly; Integrated Security=true; TrustServerCertificate=True";
        public IActionResult Index()
        {


            var conn = new SqlConnection(connString);
            conn.Open();
            var cmd = new SqlCommand($"SELECT Verbale.*, [Tipo Violazione].Descrizione FROM Verbale JOIN [Tipo Violazione] ON Verbale.idviolazione = [Tipo Violazione].idviolazione", conn);

            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var verb = new Verbali()
                {
                    DataViolazione = (DateTime)reader["DataViolazione"],
                    IndirizzoViolazione = (string)reader["IndirizzoViolazione"],
                    Nominativo_Agente = (string)reader["Nominativo_Agente"],
                    DataTrascrizioneVerbale = (DateTime)reader["DataTrascrizioneVerbale"],
                    Importo = (int)reader["Importo"],
                    DecurtamentoPunti = (int)reader["DecurtamentoPunti"],
                    Descrizione = (string)reader["Descrizione"]
                };

                verbale.Add(verb);

            }

            conn.Close();
            return View(verbale);
        }
        [HttpGet]
        public IActionResult Bottone(string opzione)
        {
            verbale.Clear();
            var conn = new SqlConnection(connString);
            conn.Open();
            if (opzione == "groupby")
            {
                var cmd = new SqlCommand($"SELECT Verbale.idanagrafica,Anagrafica.Nome,Anagrafica.Cognome, COUNT(*) AS NumeroViolazioni FROM Verbale  JOIN Anagrafica ON Verbale.idanagrafica=Anagrafica.idanagrafica    GROUP BY Verbale.idanagrafica, Anagrafica.Nome,Anagrafica.Cognome ;", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var verb = new Verbali()
                    {
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        Importo = (int)reader["NumeroViolazioni"]
                    };

                    verbale.Add(verb);

                }
                valoritab.Add("Totale Verbali ");
                ViewBag.valori = valoritab;
            }
            else if (opzione == "points")
            {

                var cmd = new SqlCommand($"SELECT Verbale.idanagrafica,Anagrafica.Nome,Anagrafica.Cognome, SUM(DecurtamentoPunti) AS PuntiTotali FROM Verbale  JOIN Anagrafica ON Verbale.idanagrafica=Anagrafica.idanagrafica    GROUP BY Verbale.idanagrafica, Anagrafica.Nome,Anagrafica.Cognome ;", conn);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var verb = new Verbali()
                    {
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        Importo = (int)reader["PuntiTotali"]
                    };


                    verbale.Add(verb);

                }
                valoritab.Add("Totale Punti Decurtati ");
                ViewBag.valori = valoritab;
            }
            else if (opzione == "morethan10")
            {
                var cmd = new SqlCommand($"SELECT * FROM VERBALE JOIN Anagrafica ON Verbale.idanagrafica=Anagrafica.idanagrafica WHERE DecurtamentoPunti>10", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var verb = new Verbali()
                    {
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        Importo = (int)reader["Importo"],
                        DataViolazione = (DateTime)reader["DataViolazione"],
                        DecurtamentoPunti = (int)reader["DecurtamentoPunti"]
                    };

                    verbale.Add(verb);

                }
                valoritab.Add("Importo ");
                valoritab.Add("Data Violazione");
                valoritab.Add("Decurtamento Punti");
                ViewBag.valori = valoritab;
            }
            else if (opzione == "morethan400")
            {
                var cmd = new SqlCommand($"SELECT * FROM VERBALE JOIN Anagrafica ON Verbale.idanagrafica=Anagrafica.idanagrafica WHERE Importo>400", conn);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var verb = new Verbali()
                    {
                        Nome = (string)reader["Nome"],
                        Cognome = (string)reader["Cognome"],
                        Importo = (int)reader["Importo"],
                        DataViolazione = (DateTime)reader["DataViolazione"],
                        DecurtamentoPunti = (int)reader["DecurtamentoPunti"]
                    };

                    verbale.Add(verb);

                }
                valoritab.Add("Importo ");
                valoritab.Add("Data Violazione");
                valoritab.Add("Decurtamento Punti");
                ViewBag.valori = valoritab;
            }


            conn.Close();
            return View(verbale);
        }


    }
}
