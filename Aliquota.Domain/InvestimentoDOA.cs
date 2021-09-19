using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Aliquota.Domian
{
    internal class InvestimentoDOA : IDisposable
    {
        private SqlConnection conexao;

        public InvestimentoDOA()
        {
            this.conexao = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=Investimentos;Trusted_Connection=true;");
            this.conexao.Open();
        }

        public void Dispose()
        {
            this.conexao.Close();
        }

        internal void Adicionar(Domian.Investimento i)
        {
            try
            {
                var insertCmd = conexao.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Investimentos (Lucro, TempoTotal) VALUES (@lucro, @tempototal)";

                var paramLucro = new SqlParameter("lucro", i.Lucro);
                insertCmd.Parameters.Add(paramLucro);

                var paramTempoTotal = new SqlParameter("tempototal", i.TempoTotal);
                insertCmd.Parameters.Add(paramTempoTotal);

                insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }
        internal void Atualizar(Domian.Investimento i)
        {
            try
            {
                var updateCmd = conexao.CreateCommand();
                updateCmd.CommandText = "UPDATE Produtos SET Lucro = @lucro, TempoTotal = @Tempototal, WHERE Id = @id";

                var paramLucro = new SqlParameter("lucro", i.Lucro);
                var paramTempoTotal = new SqlParameter("tempototal", i.TempoTotal);
                var paramId = new SqlParameter("id", i.Id);
                updateCmd.Parameters.Add(paramLucro);
                updateCmd.Parameters.Add(paramTempoTotal);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal void Remover(Domian.Investimento i)
        {
            try
            {
                var deleteCmd = conexao.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Produtos WHERE Id = @id";

                var paramId = new SqlParameter("id", i.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal IList<Domian.Investimento> Investimento()
        {
            var lista = new List<Domian.Investimento>();

            var selectCmd = conexao.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Investimento";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Investimento i = new Investimento();
                i.Id = Convert.ToInt32(resultado["Id"]);
                i.Lucro = Convert.ToDouble(resultado["Lucro"]);
                i.TempoTotal = Convert.ToInt32(resultado["TempoTotal"]);
                lista.Add(i);
            }
            resultado.Close();

            return lista;
        }
    }
}
