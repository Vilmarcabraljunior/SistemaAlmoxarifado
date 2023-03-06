using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.DAO
{
    /// <summary>
    /// Classe com os comandos CRUD do processo.
    /// </summary>
    public class ProcessoDAO
    {
        /// <summary>
        /// Método para Gravar um processo.
        /// </summary>
        /// <param name="processo">Variável do tipo processo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Processo processo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Processo (dataCadastro, processoData, processoNumero)" +
                    " values(@dataCadastro, @processoData, @processoNumero)";

                cmd.Parameters.AddWithValue("@dataCadastro", processo._DataCadastro);
                cmd.Parameters.AddWithValue("@processoData", processo._ProcessoData);
                cmd.Parameters.AddWithValue("@processoNumero", processo._ProcessoNumero);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse processo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um processo.
        /// </summary>
        /// <param name="processo">Variável do tipo processo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Processo processo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Processo SET dataCadastro=@dataCadastro, processoData=@processoData, processoNumero=@processoNumero" +
                    " WHERE processoID=@processoID";

                cmd.Parameters.AddWithValue("@processoID", processo._ProcessoID);
                cmd.Parameters.AddWithValue("@dataCadastro", processo._DataCadastro);
                cmd.Parameters.AddWithValue("@processoData", processo._ProcessoData);
                cmd.Parameters.AddWithValue("@processoNumero", processo._ProcessoNumero);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse processo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um processo.
        /// </summary>
        /// <param name="processo">Variável do tipo processo com o valor do id para fazer a exclusão.</param>
        public void Excluir(Processo processo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Processo WHERE processoID = @processoID";

                cmd.Parameters.AddWithValue("@processoID", processo._ProcessoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse processo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um processo pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do processo preenchidas.</returns>
        public Processo BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Processo WHERE processoID = @processoID";

                cmd.Parameters.AddWithValue("@processoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Processo processo = new Processo();

                if (dr.HasRows)
                {
                    dr.Read();
                    processo._ProcessoID = (int)dr["processoID"];
                    processo._DataCadastro = dr["dataCadastro"].ToString();
                    processo._ProcessoData = dr["processoData"].ToString();
                    processo._ProcessoNumero = dr["processoNumero"].ToString();
                }
                else
                {
                    processo = null;
                }
                dr.Close();
                return processo;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse processo pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um processo pela data.
        /// </summary>
        /// <param name="data">Variável com o valor da data.</param>
        /// <returns>Retorna uma Lista com os atributos do processo preenchidas.</returns>
        public IList<Processo> BuscarPorData(string data)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Processo WHERE processoData like @processoData";

                cmd.Parameters.AddWithValue("@processoData", data + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Processo> listaProcesso = new List<Processo>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Processo processo = new Processo();
                        processo._ProcessoID = (int)dr["processoID"];
                        processo._DataCadastro = dr["dataCadastro"].ToString();
                        processo._ProcessoData = dr["processoData"].ToString();
                        processo._ProcessoNumero = dr["processoNumero"].ToString();

                        listaProcesso.Add(processo);
                    }
                }
                else
                {
                    listaProcesso = null;
                }
                dr.Close();
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse processo pela data  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um processo pelo número.
        /// </summary>
        /// <param name="numero">Variável com o valor do número.</param>
        /// <returns>Retorna uma Lista com os atributos do processo preenchidas.</returns>
        public IList<Processo> BuscarPorNumero(string numero)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Processo WHERE processoNumero like @processoNumero";

                cmd.Parameters.AddWithValue("@processoNumero", numero + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Processo> listaProcesso = new List<Processo>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Processo processo = new Processo();
                        processo._ProcessoID = (int)dr["processoID"];
                        processo._DataCadastro = dr["dataCadastro"].ToString();
                        processo._ProcessoData = dr["processoData"].ToString();
                        processo._ProcessoNumero = dr["processoNumero"].ToString();

                        listaProcesso.Add(processo);
                    }
                }
                else
                {
                    listaProcesso = null;
                }
                dr.Close();
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse processo pelo número  " + ex.Message);
            }
        }
        
        /// <summary>
        /// Método para buscar todos os processos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os processos e seus atributos.</returns>
        public IList<Processo> BuscarTodosProcessos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Processo";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Processo> listaProcesso = new List<Processo>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Processo processo = new Processo();
                        processo._ProcessoID = (int)dr["processoID"];
                        processo._DataCadastro = dr["dataCadastro"].ToString();
                        processo._ProcessoData = dr["processoData"].ToString();
                        processo._ProcessoNumero = dr["processoNumero"].ToString();

                        listaProcesso.Add(processo);
                    }
                }
                else
                {
                    listaProcesso = null;
                }
                dr.Close();
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os processos " + ex.Message);
            }
        }
    }
}
