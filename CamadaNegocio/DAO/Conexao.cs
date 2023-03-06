using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CamadaNegocio.DAO
{
    /// <summary>
    /// Classe responsável por fazer a conexão entre a aplicação e o banco de dados Sql Server
    /// </summary>
    public class Conexao
    {
        /// <summary>
        /// Classe que indica o endereço do banco e abre a conexão
        /// </summary>
        /// <returns></returns>
        public static SqlConnection conectar()
        {
            try
            {
                string stringConexao = ConfigurationManager.ConnectionStrings["StringConexao"].ConnectionString;
                SqlConnection conexao = new SqlConnection(stringConexao);
                conexao.Open();
                return conexao;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("[ConexaoBanco] Erro de conexão com o banco de dados!" + ex.Message);
            }
        }

        /// <summary>
        /// Classe que executa um comando e retorna a chave primaria
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public static int manterCrudRetornaID(SqlCommand comando)
        {
            try
            {
                SqlConnection con = conectar();
                comando.Connection = con;
                int id = (int)comando.ExecuteScalar();
                con.Close();
                return id;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Erro ao execultar SQL MANTER CRUD - " + ex.Message);
            }

        }

        /// <summary>
        /// Executa uma query no sql server
        /// </summary>
        /// <param name="comando"></param>
        public static void manterCrud(SqlCommand comando)
        {
            try
            {
                SqlConnection con = conectar();
                comando.Connection = con;
                comando.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Erro ao execultar SQL MANTER CRUD - " + ex.Message);
            }

        }

        /// <summary>
        /// Retorna os dados do banco 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public static SqlDataReader selecionar(SqlCommand comando)
        {
            SqlConnection con = conectar();
            comando.Connection = con;
            try
            {
                SqlDataReader leitor = comando.ExecuteReader(CommandBehavior.CloseConnection);
                return leitor;
            }
            catch (Exception erro)
            {

                throw new ArgumentException("Erro(Selecionar Dados\n)" + erro.Message);
            }
        }
    }
}
