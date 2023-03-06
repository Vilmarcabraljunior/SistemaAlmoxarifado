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
    /// Classe com os comandos CRUD do item da saída de material.
    /// </summary>
    public class ItemSaidaMaterialDAO
    {
        /// <summary>
        /// Método para Gravar um item da saída de material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Variável do tipo item da saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemSaidaMaterial itemSaidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ItemSaidaMaterial (produtoID, saidaMaterialID) values(@produtoID, @saidaMaterialID)";

                cmd.Parameters.AddWithValue("@produtoID", itemSaidaMaterial._Produto._ProdutoID);
                cmd.Parameters.AddWithValue("@saidaMaterialID", itemSaidaMaterial._SaidaMaterial._SaidaMaterialID);
                                
                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse item da saída de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um item da saída de material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Variável do tipo item da saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(ItemSaidaMaterial itemSaidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ItemSaidaMaterial SET produtoID=@produtoID, saidaMaterialID=@saidaMaterialID" +
                    " WHERE itemSaidaMaterialID=@itemSaidaMaterialID";

                cmd.Parameters.AddWithValue("@itemSaidaMaterialID", itemSaidaMaterial._ItemSaidaMaterialID);
                cmd.Parameters.AddWithValue("@produtoID", itemSaidaMaterial._Produto._ProdutoID);
                cmd.Parameters.AddWithValue("@SaidaMaterialID", itemSaidaMaterial._SaidaMaterial._SaidaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse item da saída de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um item da saída de material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Variável do tipo município com o valor do id para fazer a exclusão.</param>
        public void Excluir(ItemSaidaMaterial itemSaidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemSaidaMaterial WHERE itemSaidaMaterialID = @itemSaidaMaterialID";

                cmd.Parameters.AddWithValue("@itemSaidaMaterialID", itemSaidaMaterial._ItemSaidaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse item da saída de material" + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um item pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemSaidaMaterial BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemSaidaMaterial WHERE itemSaidaMaterialID = @itemSaidaMaterialID";

                cmd.Parameters.AddWithValue("@itemSaidaMaterialID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                SaidaMaterial saidaMaterial = new SaidaMaterial();
                ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    SaidaMaterialDAO saidaMaterialDAO = new SaidaMaterialDAO();

                    dr.Read();
                    itemSaidaMaterial._ItemSaidaMaterialID = (int)dr["itemSaidaMaterialID"];
                    itemSaidaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                    itemSaidaMaterial._SaidaMaterial = saidaMaterialDAO.BuscarPorID((int)dr["saidaMaterialID"]);
                }
                else
                {
                    itemSaidaMaterial = null;
                }
                dr.Close();
                return itemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar item da saída de material pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir os itens da saída de material pelo id da saída de material.
        /// </summary>
        /// <param name="saidaMaterialID">Variável com o valor do id da saída de material.</param>
        public void ExcluirItensDaSaidaMaterial(int saidaMaterialID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemSaidaMaterial WHERE saidaMaterialID = @saidaMaterialID";

                cmd.Parameters.AddWithValue("@saidaMaterialID", saidaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir os itens da saída de material pelo id da saída de material " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar os itens da saída de material pelo id da saída de material.
        /// </summary>
        /// <param name="saidaMaterialID">Variável com o valor do id da saída de material.</param>
        /// <returns>Retorna uma Lista com os atributos do item da saída de material preenchidas.</returns>
        public IList<ItemSaidaMaterial> BuscarItensDaSaidaMaterial(int saidaMaterialID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemSaidaMaterial WHERE saidaMaterialID = @saidaMaterialID";

                cmd.Parameters.AddWithValue("@saidaMaterialID", saidaMaterialID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();

                if (dr.HasRows)
                {
                    SaidaMaterialDAO saidaMaterialDAO = new SaidaMaterialDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                   
                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                        itemSaidaMaterial._ItemSaidaMaterialID = (int)dr["itemSaidaMaterialID"];
                        itemSaidaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                        itemSaidaMaterial._SaidaMaterial = saidaMaterialDAO.BuscarPorID((int)dr["saidaMaterialID"]);


                        listaItemSaidaMaterial.Add(itemSaidaMaterial);
                    }
                }
                else
                {
                    listaItemSaidaMaterial = null;
                }
                dr.Close();
                return listaItemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os itens da saída de material pelo id da saída de material  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da saída de material.
        /// </summary>
        /// <returns>Retorna uma Lista com os atributos do item da saída de material preenchidas.</returns>
        public IList<ItemSaidaMaterial> BuscarTodosItensDaSaidaMaterial()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemSaidaMaterial ORDER BY saidaMaterialID ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();

                if (dr.HasRows)
                {
                    SaidaMaterialDAO saidaMaterialDAO = new SaidaMaterialDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                        itemSaidaMaterial._ItemSaidaMaterialID = (int)dr["itemSaidaMaterialID"];
                        itemSaidaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                        itemSaidaMaterial._SaidaMaterial = saidaMaterialDAO.BuscarPorID((int)dr["saidaMaterialID"]);


                        listaItemSaidaMaterial.Add(itemSaidaMaterial);
                    }
                }
                else
                {
                    listaItemSaidaMaterial = null;
                }
                dr.Close();
                return listaItemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os itens da saída de material  " + ex.Message);
            }
        }
    }
}
