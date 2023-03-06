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
    /// Classe com os comandos CRUD do item da licitação.
    /// </summary>
    public class ItemLicitacaoDAO
    {
        /// <summary>
        /// Método para Gravar um item da licitação.
        /// </summary>
        /// <param name="itemLicitacao">Variável do tipo item da licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemLicitacao itemLicitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ItemLicitacao (licitacaoID, produtoID) values(@licitacaoID, @produtoID)";

                cmd.Parameters.AddWithValue("@licitacaoID", itemLicitacao._Licitacao._LicitacaoID);
                cmd.Parameters.AddWithValue("@produtoID", itemLicitacao._Produto._ProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse item da licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um item da licitação.
        /// </summary>
        /// <param name="itemLicitacao">Variável do tipo item da licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(ItemLicitacao itemLicitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ItemLicitacao SET licitacaoID=@licitacaoID, produtoID=@produtoID" +
                    " WHERE itemLicitacaoID=@itemLicitacaoID";

                cmd.Parameters.AddWithValue("@itemLicitacaoID", itemLicitacao._ItemLicitacaoID);
                cmd.Parameters.AddWithValue("@licitacaoID", itemLicitacao._Licitacao._LicitacaoID);
                cmd.Parameters.AddWithValue("@produtoID", itemLicitacao._Produto._ProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse item da licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um item da licitação.
        /// </summary>
        /// <param name="itemLicitacao">Variável do tipo item da licitação com o valor do id para fazer a exclusão.</param>
        public void Excluir(ItemLicitacao itemLicitacao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemLicitacao WHERE itemLicitacaoID = @itemLicitacaoID";

                cmd.Parameters.AddWithValue("@itemLicitacaoID", itemLicitacao._ItemLicitacaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse item da licitação" + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um item pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemLicitacao BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM itemLicitacao WHERE itemlicitacaoID = @itemlicitacaoID";

                cmd.Parameters.AddWithValue("@itemlicitacaoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Licitacao licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    LicitacaoDAO licitacaoDAO = new LicitacaoDAO();

                    dr.Read();
                    itemLicitacao._ItemLicitacaoID = (int)dr["itemLicitacaoID"];
                    itemLicitacao._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                    itemLicitacao._Licitacao = licitacaoDAO.BuscarPorID((int)dr["licitacaoID"]);
                }
                else
                {
                    itemLicitacao = null;
                }
                dr.Close();
                return itemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar item da Licitação pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um item pelo seu código do produto.
        /// </summary>
        /// <param name="produtoCodigo">Atributo com o valor do  código do produto.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemLicitacao BuscarProdutoDoItemLicitacao(string produtoCodigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM itemLicitacao, Produto, Licitacao WHERE ItemLicitacao.produtoID = Produto.produtoID and" +
                    " ItemLicitacao.licitacaoID = Licitacao.licitacaoID and Produto.codigo = @produtoCodigo";

                cmd.Parameters.AddWithValue("@produtoCodigo", produtoCodigo);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Licitacao licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    LicitacaoDAO licitacaoDAO = new LicitacaoDAO();

                    dr.Read();
                    itemLicitacao._ItemLicitacaoID = (int)dr["itemLicitacaoID"];
                    itemLicitacao._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                    itemLicitacao._Licitacao = licitacaoDAO.BuscarPorID((int)dr["licitacaoID"]);
                }
                else
                {
                    itemLicitacao = null;
                }
                dr.Close();
                return itemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar o produto do item da licitação pelo código " + ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir os itens da licitação pelo id da licitação.
        /// </summary>
        /// <param name="licitacaoID">Variável com o valor do id da licitação.</param>
        public void ExcluirItensDaLicitacao(int licitacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemLicitacao WHERE licitacaoID = @licitacaoID";

                cmd.Parameters.AddWithValue("@licitacaoID", licitacaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir os itens da licitação pelo id da licitação " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar os itens da licitação pelo id da licitação.
        /// </summary>
        /// <param name="licitacaoID">Variável com o valor do id da licitação.</param>
        /// <returns>Retorna uma Lista com os atributos do item da licitação preenchidas.</returns>
        public IList<ItemLicitacao> BuscarItensDaLicitacao(int licitacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemLicitacao WHERE licitacaoID = @licitacaoID";

                cmd.Parameters.AddWithValue("@licitacaoID", licitacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();

                if (dr.HasRows)
                {
                    LicitacaoDAO licitacaoDAO = new LicitacaoDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    while (dr.Read())
                    {
                        Licitacao licitacao = new Licitacao();
                        ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                        itemLicitacao._ItemLicitacaoID = (int)dr["itemLicitacaoID"];
                        itemLicitacao._Licitacao = licitacaoDAO.BuscarPorID((int)dr["licitacaoID"]);
                        itemLicitacao._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);

                        listaItemLicitacao.Add(itemLicitacao);
                    }
                }
                else
                {
                    listaItemLicitacao = null;
                }
                dr.Close();
                return listaItemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os itens da licitação pelo id da licitação  " + ex.Message);
            }
        }
    }
}
