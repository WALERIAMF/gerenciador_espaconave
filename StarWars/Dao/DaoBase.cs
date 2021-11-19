using Microsoft.Data.SqlClient;
using System;
using System.Threading.Tasks;

namespace StarWars.Dao
{
    public abstract class DaoBase : IDisposable 
    {
        protected readonly SqlConnection con;

        protected DaoBase()
        {
            con = new SqlConnection(@"Server=Tiranitar\\SQLEXPRESS;database=StarWars;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        public void Dispose()
        {
            con?.Close();
            con?.Dispose();
        }

        protected async Task Insert(string comando)
        {
            con.Open();
            SqlConnection cmd = new SqlCommand(comando, con);
            await cmd.ExecuteNonQueryAsync();
            con.Close();
        }
        protected async Task Select(string comando, Action<SqlDataReader> tratamentoLeitura)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(comando, con);
            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            tratamentoLeitura(dr);
            con.Close();
        }

    }
}


