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
    /// Classe com os comandos CRUD do nome do produto.
    /// </summary>
    public class NomeProdutoDAO
    {
        /// <summary>
        /// Método para Gravar um nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Variável do tipo nome do produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(NomeProduto nomeProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO NomeProduto (codigo, dataCadastro, produtoNome, produtoPrecoUnitario, contaID, unidadeID)"+
                    " values(@codigo, @dataCadastro, @produtoNome, @produtoPrecoUnitario, @contaID, @unidadeID)";

                cmd.Parameters.AddWithValue("@codigo", nomeProduto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", nomeProduto._DataCadastro);
                cmd.Parameters.AddWithValue("@produtoNome", nomeProduto._ProdutoNome);
                cmd.Parameters.AddWithValue("@produtoPrecoUnitario", nomeProduto._ProdutoPrecoUnitario);
                cmd.Parameters.AddWithValue("@contaID", nomeProduto._Conta._ContaID);
                cmd.Parameters.AddWithValue("@unidadeID", nomeProduto._Unidade._UnidadeID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse nome do produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Variável do tipo nome do produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(NomeProduto nomeProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE NomeProduto SET codigo=@codigo, dataCadastro=@dataCadastro, produtoNome=@produtoNome,"+
                    " produtoPrecoUnitario=@produtoPrecoUnitario, contaID=@contaID, unidadeID=@unidadeID WHERE nomeProdutoID=@nomeProdutoID";

                cmd.Parameters.AddWithValue("@nomeProdutoID", nomeProduto._NomeProdutoID);
                cmd.Parameters.AddWithValue("@codigo", nomeProduto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", nomeProduto._DataCadastro);
                cmd.Parameters.AddWithValue("@produtoNome", nomeProduto._ProdutoNome);
                cmd.Parameters.AddWithValue("@produtoPrecoUnitario", nomeProduto._ProdutoPrecoUnitario);
                cmd.Parameters.AddWithValue("@contaID", nomeProduto._Conta._ContaID);
                cmd.Parameters.AddWithValue("@unidadeID", nomeProduto._Unidade._UnidadeID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse nome do produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Variável do tipo nome do produto com o valor do id para fazer a exclusão.</param>
        public void Excluir(NomeProduto nomeProduto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM NomeProduto WHERE nomeProdutoID = @nomeProdutoID";

                cmd.Parameters.AddWithValue("@nomeProdutoID", nomeProduto._NomeProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse nome do produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um nome do produto pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do nome do produto preenchidas.</returns>
        public NomeProduto BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM NomeProduto WHERE nomeProdutoID = @nomeProdutoID";

                cmd.Parameters.AddWithValue("@nomeProdutoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                NomeProduto nomeProduto = new NomeProduto();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    dr.Read();
                    nomeProduto._NomeProdutoID = (int)dr["nomeProdutoID"];
                    nomeProduto._Codigo = dr["codigo"].ToString();
                    nomeProduto._DataCadastro = dr["dataCadastro"].ToString();
                    nomeProduto._ProdutoNome = dr["produtoNome"].ToString();
                    nomeProduto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                    nomeProduto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                    nomeProduto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);
                }
                else
                {
                    nomeProduto = null;
                }
                dr.Close();
                return nomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse nome do produto pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um nome do produto pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>Retorna uma Lista com os atributos do nome do produto preenchidas.</returns>
        public IList<NomeProduto> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM NomeProduto WHERE codigo like @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        NomeProduto nomeProduto = new NomeProduto();
                        nomeProduto._NomeProdutoID = (int)dr["nomeProdutoID"];
                        nomeProduto._Codigo = dr["codigo"].ToString();
                        nomeProduto._DataCadastro = dr["dataCadastro"].ToString();
                        nomeProduto._ProdutoNome = dr["produtoNome"].ToString();
                        nomeProduto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        nomeProduto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        nomeProduto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaNomeProduto.Add(nomeProduto);
                    }
                }
                else
                {
                    listaNomeProduto = null;
                }
                dr.Close();
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse nome do produto pelo código " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um nome produto pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos do nome do produto preenchidas.</returns>
        public IList<NomeProduto> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM NomeProduto WHERE produtoNome like @produtoNome";

                cmd.Parameters.AddWithValue("@produtoNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        NomeProduto nomeProduto = new NomeProduto();
                        nomeProduto._NomeProdutoID = (int)dr["nomeProdutoID"];
                        nomeProduto._Codigo = dr["codigo"].ToString();
                        nomeProduto._DataCadastro = dr["dataCadastro"].ToString();
                        nomeProduto._ProdutoNome = dr["produtoNome"].ToString();
                        nomeProduto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        nomeProduto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        nomeProduto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaNomeProduto.Add(nomeProduto);
                    }
                }
                else
                {
                    listaNomeProduto = null;
                }
                dr.Close();
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse nome do produto pelo nome " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os nomes dos produtos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os nomes dos produtos e seus atributos.</returns>
        public IList<NomeProduto> BuscarTodosNomesProdutos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM NomeProduto ORDER BY produtoNome ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        NomeProduto nomeProduto = new NomeProduto();
                        nomeProduto._NomeProdutoID = (int)dr["nomeProdutoID"];
                        nomeProduto._Codigo = dr["codigo"].ToString();
                        nomeProduto._DataCadastro = dr["dataCadastro"].ToString();
                        nomeProduto._ProdutoNome = dr["produtoNome"].ToString();
                        nomeProduto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        nomeProduto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        nomeProduto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaNomeProduto.Add(nomeProduto);
                    }
                }
                else
                {
                    listaNomeProduto = null;
                }
                dr.Close();
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os nomes dos produtos " + ex.Message);
            }
        }
    }
}
