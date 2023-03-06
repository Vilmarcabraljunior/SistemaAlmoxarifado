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
    /// Classe com os comandos CRUD do item da requisição.
    /// </summary>
    public class ItemRequisicaoDAO
    {
        /// <summary>
        /// Método para Gravar um item da requisição.
        /// </summary>
        /// <param name="itemRequisicao">Variável do tipo item da requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemRequisicao itemRequisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ItemRequisicao (produtoID, requisicaoID) values(@produtoID, @requisicaoID)";

                cmd.Parameters.AddWithValue("@produtoID", itemRequisicao._Produto._ProdutoID);
                cmd.Parameters.AddWithValue("@requisicaoID", itemRequisicao._Requisicao._RequisicaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse item da requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um item da requisição.
        /// </summary>
        /// <param name="itemRequisicao">Variável do tipo item da requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(ItemRequisicao itemRequisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ItemRequisicao SET produtoID=@produtoID, requisicaoID=@requisicaoID" +
                    " WHERE itemRequisicaoID=@itemRequisicaoID";

                cmd.Parameters.AddWithValue("@itemRequisicaoID", itemRequisicao._ItemRequisicaoID);
                cmd.Parameters.AddWithValue("@produtoID", itemRequisicao._Produto._ProdutoID);
                cmd.Parameters.AddWithValue("@RequisicaoID", itemRequisicao._Requisicao._RequisicaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse item da requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um item da requisição.
        /// </summary>
        /// <param name="itemRequisicao">Variável do tipo item da requisição com o valor do id para fazer a exclusão.</param>
        public void Excluir(ItemRequisicao itemRequisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemRequisicao WHERE itemRequisicaoID = @itemRequisicaoID";

                cmd.Parameters.AddWithValue("@itemRequisicaoID", itemRequisicao._ItemRequisicaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse item da requisição" + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um item pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemRequisicao BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemRequisicao WHERE itemRequisicaoID = @itemRequisicaoID";

                cmd.Parameters.AddWithValue("@itemRequisicaoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Requisicao requisicao = new Requisicao();
                ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    RequisicaoDAO requsicaoDAO = new RequisicaoDAO();

                    dr.Read();
                    itemRequisicao._ItemRequisicaoID = (int)dr["itemRequisicaoID"];
                    itemRequisicao._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                    itemRequisicao._Requisicao = requsicaoDAO.BuscarPorID((int)dr["requisicaoID"]);
                }
                else
                {
                    itemRequisicao = null;
                }
                dr.Close();
                return itemRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar item requisição pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir os itens da requisição pelo id da requisição.
        /// </summary>
        /// <param name="requisicaoID">Variável com o valor do id da requisição.</param>
        public void ExcluirItensDaRequisicao(int requisicaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemRequisicao WHERE requisicaoID = @requisicaoID";

                cmd.Parameters.AddWithValue("@requisicaoID", requisicaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir os itens da requisição pelo id da requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar os itens da requisição pelo id da requisição.
        /// </summary>
        /// <param name="requisicaoID">Variável com o valor do id da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos do item da requisição preenchidas.</returns>
        public IList<ItemRequisicao> BuscarItensDaRequisicao(int requisicaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemRequisicao WHERE requisicaoID = @requisicaoID";

                cmd.Parameters.AddWithValue("@requisicaoID", requisicaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    RequisicaoDAO requsicaoDAO = new RequisicaoDAO();
                    
                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                        itemRequisicao._ItemRequisicaoID = (int)dr["itemRequisicaoID"];
                        itemRequisicao._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                        itemRequisicao._Requisicao = requsicaoDAO.BuscarPorID((int)dr["requisicaoID"]);


                        listaItemRequisicao.Add(itemRequisicao);
                    }
                }
                else
                {
                    listaItemRequisicao = null;
                }
                dr.Close();
                return listaItemRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os itens da requisição pelo id da requisição  " + ex.Message);
            }
        }
    }
}
