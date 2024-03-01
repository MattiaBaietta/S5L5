using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using S5L5.Models;

namespace S5L5.Controllers
{
    public class TrasgressoriController : Controller
    {
        private string connString = "Server=DESKTOP-367Q1CC\\SQLEXPRESS; Initial Catalog=Prova Weekly; Integrated Security=true; TrustServerCertificate=True";

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Trasgressori trasgressore)
        {
            var conn = new SqlConnection(connString);
            conn.Open();
            var command = new SqlCommand("INSERT INTO ANAGRAFICA (Cognome, Nome, Indirizzo, Città, Cap, Cod_Fisc) VALUES (@Cognome, @Nome, @Indirizzo, @Città, @Cap, @Cod_Fisc)", conn);
            command.Parameters.AddWithValue("@Cognome", trasgressore.Cognome);
            command.Parameters.AddWithValue("@Nome", trasgressore.Nome);
            command.Parameters.AddWithValue("@Indirizzo", trasgressore.Indirizzo);
            command.Parameters.AddWithValue("@Città", trasgressore.Citta);
            command.Parameters.AddWithValue("@Cap", trasgressore.Cap);
            command.Parameters.AddWithValue("@Cod_Fisc", trasgressore.Cod_Fisc);
            command.ExecuteNonQuery();
            conn.Close();
            return RedirectToAction("Index");
        }
    }
}
