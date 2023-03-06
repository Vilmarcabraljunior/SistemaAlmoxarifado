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
    /// Classe com os comandos CRUD da licitação.
    /// </summary>
    public class LicitacaoDAO
    {
        /// <summary>
        /// Método para Gravar uma licitação.
        /// </summary>
        /// <param name="licitacao">Variável do tipo licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da licitação.</returns>
        public int Salvar(Licitacao licitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Licitacao (dataCadastro, observacao)" +
                    " output inserted.licitacaoID values(@dataCadastro, @observacao)";

                cmd.Parameters.AddWithValue("@dataCadastro", licitacao._DataCadastro);
                cmd.Parameters.AddWithValue("@observacao", licitacao._Observacao);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma licitação.
        /// </summary>
        /// <param name="licitacao">Variável do tipo licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da licitação.</returns>
        public int Atualizar(Licitacao licitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Licitacao SET dataCadastro=@dataCadastro, observacao=@observacao" +
                    " output inserted.licitacaoID WHERE licitacaoID=@licitacaoID";

                cmd.Parameters.AddWithValue("@licitacaoID", licitacao._LicitacaoID);
                cmd.Parameters.AddWithValue("@dataCadastro", licitacao._DataCadastro);
                cmd.Parameters.AddWithValue("@observacao", licitacao._Observacao);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma licitação.
        /// </summary>
        /// <param name="licitacao">Variável do tipo licitação com o valor do id para fazer a exclusão.</param>
        public void Excluir(Licitacao licitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Licitacao WHERE licitacaoID = @licitacaoID";

                cmd.Parameters.AddWithValue("@licitacaoID", licitacao._LicitacaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma licitação pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da licitação preenchidas.</returns>
        public Licitacao BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE licitacaoID = @licitacaoID";

                cmd.Parameters.AddWithValue("@licitacaoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Licitacao licitacao = new Licitacao();

                if (dr.HasRows)
                {
                    dr.Read();
                    licitacao._LicitacaoID = (int)dr["licitacaoID"];
                    licitacao._DataCadastro = dr["dataCadastro"].ToString();
                    licitacao._Observacao = dr["observacao"].ToString();
                }
                else
                {
                    licitacao = null;
                }
                dr.Close();
                return licitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a ultima requisição cadastrada.
        /// </summary>
        /// <returns>Retorna uma variável com os atributos da licitação preenchidas.</returns>
        public Licitacao BuscarPorUltimaLicitacao()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 * FROM Licitacao ORDER BY licitacaoID ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                Licitacao licitacao = new Licitacao();

                if (dr.HasRows)
                {
                    dr.Read();
                    licitacao._LicitacaoID = (int)dr["licitacaoID"];
                    licitacao._DataCadastro = dr["dataCadastro"].ToString();
                    licitacao._Observacao = dr["observacao"].ToString();
                }
                else
                {
                    licitacao = null;
                }
                dr.Close();
                return licitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar a última licitação cadastrada " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pela data do cadastro.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data do cadastro.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarPorDataCadastro(string dataCadastro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE dataCadastro = @dataCadastro";

                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pela data do cadastro  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pela data cadastro por betwwen.
        /// </summary>
        /// <param name="dataInicial">Variável com o valor da data incial.</param>
        /// <param name="dataFinal">Variável com o valor da data final.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarDataCadastroPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação por between  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id do processo.
        /// </summary>
        /// <param name="processoID">Variável com o valor do id do processo.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarPorProcesso(int processoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE processoID = @processoID";

                cmd.Parameters.AddWithValue("@processoID", processoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pelo id do processo  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id da modalidade de compra.
        /// </summary>
        /// <param name="modalidadeCompraID">Variável com o valor do id da modalidade de compra.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarPorModalidadeCompra(int modalidadeCompraID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE modalidadeCompraID = @modalidadeCompraID";

                cmd.Parameters.AddWithValue("@modalidadeCompraID", modalidadeCompraID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pelo id da modalidade de compra  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id da situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor do id da situação.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", situacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pelo id da situação  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id do usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do id do usuário.</param>
        /// <returns>Retorna uma Lista com os atributos da licitação preenchidas.</returns>
        public IList<Licitacao> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa licitação pelo id do usuário  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as licitações da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as licitações e seus atributos.</returns>
        public IList<Licitacao> BuscarTodasLicitacoes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Licitacao";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Licitacao> listaLicitacao = new List<Licitacao>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        licitacao._LicitacaoID = (int)dr["licitacaoID"];
                        licitacao._DataCadastro = dr["dataCadastro"].ToString();
                        licitacao._Observacao = dr["observacao"].ToString();

                        listaLicitacao.Add(licitacao);
                    }
                }
                else
                {
                    listaLicitacao = null;
                }
                dr.Close();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as licitações " + ex.Message);
            }
        }
    }
}
