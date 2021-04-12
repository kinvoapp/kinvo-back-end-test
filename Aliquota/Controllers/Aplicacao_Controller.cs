using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Aliquota.Data;
using Aliquota.Domain;
using Aliquota.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aliquota.Controllers
{
 
    public class Aplicacao_Controller : Controller
    {
        public SqlConnection connect()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "aliquota-domaindbserver.database.windows.net";
                builder.UserID = "aliquota";
                builder.Password = "Henrique1299";
                builder.InitialCatalog = "Aliquota.Domain_db";

                SqlConnection connection = new SqlConnection(builder.ConnectionString);
                return connection;
   
            }
            catch
            {
                return null;
            }
        }
        public ActionResult Resgatar(int id)
        {
            IR i = new IR();

            SqlConnection connection = connect();

            String sql = "SELECT * FROM Aplicacao WHERE Id=" + id;

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    String dR = DateTime.Now.ToString().Substring(0, 10);
                    double valor = reader.GetDouble(1);
                    String dA = reader.GetString(2);
                    double taxa = 0.088;
                    Lucro l = new Lucro(dR, dA, taxa, valor);

                    i.valor = valor;
                    i.dataAplicacao = l.getDataAplicacao().ToString().Substring(0, 10);
                    i.dataResgate = l.getDataResgate().ToString().Substring(0, 10);
                    i.ir = Math.Round(l.getIR(l), 2);
                    i.lucro = Math.Round(l.getLucro(), 2);
                    i.aliquota = l.getAliquota()*100;
                    
                }
            }
            connection.Close();
            return View(i);
        }
        // GET: Aplicacao_Controller
        public ActionResult Index()
        {
            ArrayList aps = new ArrayList();
            SqlConnection connection = connect();

            String sql = "SELECT * FROM Aplicacao ORDER BY valor DESC";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Aplicacao a = new Aplicacao();
                    a.Id = reader.GetInt32(0);
                    a.valor = reader.GetDouble(1);
                    a.dataAplicacao = reader.GetString(2);
                    aps.Add(a);
                }
            }
            IEnumerable<Aplicacao> query = aps.Cast<Aplicacao>();
            connection.Close();
            return View(query);
        }
   

        // GET: Aplicacao_Controller/Details/5
        public ActionResult Details(int id)
        {
            SqlConnection connection = connect();
            String sql = "SELECT * FROM Aplicacao WHERE Id=" + id;

            Aplicacao a = new Aplicacao();

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    a.Id = reader.GetInt32(0);
                    a.valor = reader.GetDouble(1);
                    a.dataAplicacao = reader.GetString(2);
                }
                
            }
            connection.Close();
            return View(a);
        }

        // GET: Aplicacao_Controller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aplicacao_Controller/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Aplicacao aplicacao)
        {
            SqlConnection connection = connect();
            String sql = "insert into Aplicacao (valor, dataAplicacao)"
                + " values (" + Math.Round(aplicacao.valor, 2) + ", '" + aplicacao.dataAplicacao + "')";

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aplicacao_Controller/Edit/5
        public ActionResult Edit(int id)
        {

            SqlConnection connection = connect();
            String sql = "SELECT * FROM Aplicacao WHERE Id=" + id;

            Aplicacao a = new Aplicacao();

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    a.Id = reader.GetInt32(0);
                    a.valor = Math.Round(reader.GetDouble(1), 2);
                    a.dataAplicacao = reader.GetString(2);
                }

            }
            connection.Close();
            return View(a);
        }

        // POST: Aplicacao_Controller/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Aplicacao aplicacao)
        {
            try
            {
                SqlConnection connection = connect();

                String sql = "UPDATE Aplicacao SET valor="+ aplicacao.valor +",dataAplicacao='"+aplicacao.dataAplicacao+"' WHERE Id=" + id;

                Aplicacao a = new Aplicacao();

                SqlCommand command = new SqlCommand(sql, connection);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Aplicacao_Controller/Delete/5
        public ActionResult Delete(int id)
        {
            SqlConnection connection = connect();
            //String sql = "DELETE FROM Aplicacao WHERE Id=" + id;
            String sql = "SELECT * FROM Aplicacao WHERE Id=" + id;

            Aplicacao a = new Aplicacao();

            SqlCommand command = new SqlCommand(sql, connection);
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    a.Id = reader.GetInt32(0);
                    a.valor = reader.GetDouble(1);
                    a.dataAplicacao = reader.GetString(2);
                }

            }
            connection.Close();
            return View(a);
        }

        // POST: Aplicacao_Controller/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                SqlConnection connection = connect();
                String sql = "DELETE FROM Aplicacao WHERE Id=" + id;

                Aplicacao a = new Aplicacao();

                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                connection.Close();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        } 
    }
}
