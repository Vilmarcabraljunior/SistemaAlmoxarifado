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
    /// Classe com os comandos CRUD da situação.
    /// </summary>
    public class SituacaoDAO
    {
        /// <summary>
        /// Método para Gravar uma situação.
        /// </summary>
        /// <param name="situacao">Variável do tipo situação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Situacao situacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Situacao (dataCadastro, situacaoNome) values(@dataCadastro, @situacaoNome)";

                cmd.Parameters.AddWithValue("@dataCadastro", situacao._DataCadastro);
                cmd.Parameters.AddWithValue("@situacaoNome", situacao._SituacaoNome);


                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa situação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma situação.
        /// </summary>
        /// <param name="situacao">Variável do tipo situação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Situacao situacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Situacao SET dataCadastro=@dataCadastro, situacaoNome=@situacaoNome WHERE situacaoID=@situacaoID";

                cmd.Parameters.AddWithValue("@SituacaoID", situacao._SituacaoID);
                cmd.Parameters.AddWithValue("@dataCadastro", situacao._DataCadastro);
                cmd.Parameters.AddWithValue("@situacaoNome", situacao._SituacaoNome);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa situação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma situação.
        /// </summary>
        /// <param name="situacao">Variável do tipo situação com o valor do id para fazer a exclusão.</param>
        public void Excluir(Situacao situacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Situacao WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", situacao._SituacaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa situação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma situação pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da situação preenchidas.</returns>
        public Situacao BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Situacao WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Situacao situacao = new Situacao();

                if (dr.HasRows)
                {
                    dr.Read();
                    situacao._SituacaoID = (int)dr["situacaoID"];
                    situacao._DataCadastro = dr["dataCadastro"].ToString();
                    situacao._SituacaoNome = dr["situacaoNome"].ToString();
                }
                else
                {
                    situacao = null;
                }
                dr.Close();
                return situacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa situação pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma situação pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos da situação preenchidas.</returns>
        public IList<Situacao> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Situacao WHERE situacaoNome like @situacaoNome";

                cmd.Parameters.AddWithValue("@situacaoNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Situacao> listaSituacao = new List<Situacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Situacao situacao = new Situacao();
                        situacao._SituacaoID = (int)dr["situacaoID"];
                        situacao._DataCadastro = dr["dataCadastro"].ToString();
                        situacao._SituacaoNome = dr["situacaoNome"].ToString();

                        listaSituacao.Add(situacao);
                    }
                }
                else
                {
                    listaSituacao = null;
                }
                dr.Close();
                return listaSituacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa situação pelo nome  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as situações da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as situações e seus atributos.</returns>
        public IList<Situacao> BuscarTodasSituacoes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Situacao";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Situacao> listaSituacao = new List<Situacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Situacao situacao = new Situacao();
                        situacao._SituacaoID = (int)dr["situacaoID"];
                        situacao._DataCadastro = dr["dataCadastro"].ToString();
                        situacao._SituacaoNome = dr["situacaoNome"].ToString();

                        listaSituacao.Add(situacao);
                    }
                }
                else
                {
                    listaSituacao = null;
                }
                dr.Close();
                return listaSituacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as situações " + ex.Message);
            }
        }
    }
}
