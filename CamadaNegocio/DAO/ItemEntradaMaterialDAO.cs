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
    /// Classe com os comandos CRUD do item da entrada de material.
    /// </summary>
    public class ItemEntradaMaterialDAO
    {
        /// <summary>
        /// Método para Gravar um item da entrada de material.
        /// </summary>
        /// <param name="itemEntradaMaterial">Variável do tipo item da entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemEntradaMaterial itemEntradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO ItemEntradaMaterial (entradaMaterialID, produtoID) values(@entradaMaterialID, @produtoID)";

                cmd.Parameters.AddWithValue("@entradaMaterialID", itemEntradaMaterial._EntradaMaterial._EntradaMaterialID);
                cmd.Parameters.AddWithValue("@produtoID", itemEntradaMaterial._Produto._ProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse item da entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um item da entrada de material.
        /// </summary>
        /// <param name="itemEntradaMaterial">Variável do tipo item da entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(ItemEntradaMaterial itemEntradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE ItemEntradaMaterial SET entradaMaterialID=@entradaMaterialID, produtoID=@produtoID" +
                    " WHERE itemEntradaMaterialID=@itemEntradaMaterialID";

                cmd.Parameters.AddWithValue("@itemEntradaMaterialID", itemEntradaMaterial._ItemEntradaMaterialID);
                cmd.Parameters.AddWithValue("@entradaMaterialID", itemEntradaMaterial._EntradaMaterial._EntradaMaterialID);
                cmd.Parameters.AddWithValue("@produtoID", itemEntradaMaterial._Produto._ProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse item da entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um item da entrada de material.
        /// </summary>
        /// <param name="itemEntradaMaterial">Variável do tipo item da entrada de material com o valor do id para fazer a exclusão.</param>
        public void Excluir(ItemEntradaMaterial itemEntradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemEntradaMaterial WHERE itemEntradaMaterialID = @itemEntradaMaterialID";

                cmd.Parameters.AddWithValue("@itemEntradaMaterialID", itemEntradaMaterial._ItemEntradaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse item da entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um item pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemEntradaMaterial BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemEntradaMaterial WHERE itemEntradaMaterialID = @itemEntradaMaterialID";

                cmd.Parameters.AddWithValue("@itemEntradaMaterialID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                EntradaMaterial entradaMaterial = new EntradaMaterial();
                ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);

                if (dr.HasRows)
                {
                    ProdutoDAO produtoDAO = new ProdutoDAO();
                    EntradaMaterialDAO entradaMaterialDAO = new EntradaMaterialDAO();

                    dr.Read();
                    itemEntradaMaterial._ItemEntradaMaterialID = (int)dr["itemEntradaMaterialID"];
                    itemEntradaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                    itemEntradaMaterial._EntradaMaterial = entradaMaterialDAO.BuscarPorID((int)dr["entradaMaterialID"]);
                }
                else
                {
                    itemEntradaMaterial = null;
                }
                dr.Close();
                return itemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar item da entrada de material pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir os itens da entrada de material pelo id da entrada de material.
        /// </summary>
        /// <param name="entradaMaterialID">Variável com o valor do id da entrada de material.</param>
        public void ExcluirItensDaEntradaMaterial(int entradaMaterialID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM ItemEntradaMaterial WHERE entradaMaterialID = @entradaMaterialID";

                cmd.Parameters.AddWithValue("@entradaMaterialID", entradaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir os itens da entrada de material pelo id da entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar os itens da entrada de material pelo id da entra da de material.
        /// </summary>
        /// <param name="entradaMaterialID">Variável do tipo entrada de material com o valor do id.</param>
        /// <returns>Retorna uma Lista com os atributos do item da entrada de material preenchidas.</returns>
        public IList<ItemEntradaMaterial> BuscarItensDaEntradaMaterial(int entradaMaterialID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemEntradaMaterial WHERE entradaMaterialID = @entradaMaterialID";

                cmd.Parameters.AddWithValue("@entradaMaterialID", entradaMaterialID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();

                if (dr.HasRows)
                {
                    EntradaMaterialDAO entradaMaterialDAO = new EntradaMaterialDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                        itemEntradaMaterial._ItemEntradaMaterialID = (int)dr["itemEntradaMaterialID"];
                        itemEntradaMaterial._EntradaMaterial = entradaMaterialDAO.BuscarPorID((int)dr["entradaMaterialID"]);
                        itemEntradaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);
                       
                        listaItemEntradaMaterial.Add(itemEntradaMaterial);
                    }
                }
                else
                {
                    listaItemEntradaMaterial = null;
                }
                dr.Close();
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar os itens de entrada da material pelo id da entrada de material  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da entrada de material.
        /// </summary>
        /// <returns>Retorna uma Lista com os atributos do item da entrada de material preenchidas.</returns>
        public IList<ItemEntradaMaterial> BuscarItensDaEntradaMaterialPorData(string dataCadastro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemEntradaMaterial, EntradaMaterial WHERE ItemEntradaMaterial.entradaMateriaID = EntradaMaterial.entradaMaterialID"+
                    " EntradaMaterial.dataCadastro = @dataCadastro ORDER BY entradaMaterialID ASC ";

                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();

                if (dr.HasRows)
                {
                    EntradaMaterialDAO entradaMaterialDAO = new EntradaMaterialDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                        itemEntradaMaterial._ItemEntradaMaterialID = (int)dr["itemEntradaMaterialID"];
                        itemEntradaMaterial._EntradaMaterial = entradaMaterialDAO.BuscarPorID((int)dr["entradaMaterialID"]);
                        itemEntradaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);

                        listaItemEntradaMaterial.Add(itemEntradaMaterial);
                    }
                }
                else
                {
                    listaItemEntradaMaterial = null;
                }
                dr.Close();
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os itens da entrada da material  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da entrada de material.
        /// </summary>
        /// <returns>Retorna uma Lista com os atributos do item da entrada de material preenchidas.</returns>
        public IList<ItemEntradaMaterial> BuscarTodosItensDaEntradaMaterial()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM ItemEntradaMaterial ORDER BY entradaMaterialID ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();

                if (dr.HasRows)
                {
                    EntradaMaterialDAO entradaMaterialDAO = new EntradaMaterialDAO();
                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        ItemEntradaMaterial itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                        itemEntradaMaterial._ItemEntradaMaterialID = (int)dr["itemEntradaMaterialID"];
                        itemEntradaMaterial._EntradaMaterial = entradaMaterialDAO.BuscarPorID((int)dr["entradaMaterialID"]);
                        itemEntradaMaterial._Produto = produtoDAO.BuscarPorID((int)dr["produtoID"]);

                        listaItemEntradaMaterial.Add(itemEntradaMaterial);
                    }
                }
                else
                {
                    listaItemEntradaMaterial = null;
                }
                dr.Close();
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os itens da entrada da material  " + ex.Message);
            }
        }
    }
}
