using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.DAO;

namespace CamadaNegocio.BO
{
    /// <summary>
    /// Classe que faz a validação dos dados do item da saída de material.
    /// </summary>
    public class ItemSaidaMaterialBO
    {
        /// <summary>
        /// Variável do tipo item da saída de material com os atributos para serem preenchidos.
        /// </summary>
        ItemSaidaMaterial itemSaidaMaterial;
        /// <summary>
        /// Váriavel da classe itemSaidaMaterialDAO para chamar os métodos da classe DAO.
        /// </summary>
        ItemSaidaMaterialDAO itemSaidaMaterialDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do item da saída de material.
        /// </summary>
        IList<ItemSaidaMaterial> listaItemSaidaMaterial;

        /// <summary>
        /// Método que faz a validação dos dados do Item da Saída de Material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Atributo do tipo ItemSaidaMaterial com os atributos que seram validados.</param>
        #region Métodos Auxiliáres

        public void ValidacaoSalvar(ItemSaidaMaterial itemSaidaMaterial)
        {
            if (itemSaidaMaterial._SaidaMaterial._SaidaMaterialID.Equals(0))
            {
                throw new Exception("Saída de Material é Obrigatória.");
            }
            else if (itemSaidaMaterial._Produto._ProdutoID.Equals(0))
            {
                throw new Exception("Produto é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um item da saída de material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Variável do tipo item da saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemSaidaMaterial itemSaidaMaterial)
        {
            try
            {
                ValidacaoSalvar(itemSaidaMaterial);

                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();

                if (itemSaidaMaterial._ItemSaidaMaterialID != 0)
                {
                    itemSaidaMaterialDAO.Atualizar(itemSaidaMaterial);
                }
                else
                {
                    itemSaidaMaterialDAO.Salvar(itemSaidaMaterial);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um item da saída de material.
        /// </summary>
        /// <param name="itemSaidaMaterial">Variável do tipo item da saída de material com o valor do id para fazer a exclusão.</param>
        public void Excluir(ItemSaidaMaterial itemSaidaMaterial)
        {
            try
            {
                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();
                itemSaidaMaterialDAO.Excluir(itemSaidaMaterial);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                SaidaMaterial saidaMaterial = new SaidaMaterial();
                itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();

                itemSaidaMaterial = itemSaidaMaterialDAO.BuscarPorID(id);
                return itemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();
                itemSaidaMaterialDAO.ExcluirItensDaSaidaMaterial(saidaMaterialID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar os itens da saída de material pelo id da saída de material.
        /// </summary>
        /// <param name="saidaMaterialID">Variável com o valor do id da saída de material.</param>
        /// <returns>retorna uma lista com os atributos daquele item da saída de material que foi consultado.</returns>
        public IList<ItemSaidaMaterial> BuscarItensDaSaidaMaterial(int saidaMaterialID)
        {
            try
            {
                listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();

                listaItemSaidaMaterial = itemSaidaMaterialDAO.BuscarItensDaSaidaMaterial(saidaMaterialID);
                return listaItemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da saída de material.
        /// </summary>
        /// <returns>retorna uma lista com os atributos daquele item da saída de material que foi consultado.</returns>
        public IList<ItemSaidaMaterial> BuscarTodosItensDaSaidaMaterial()
        {
            try
            {
                listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                itemSaidaMaterialDAO = new ItemSaidaMaterialDAO();

                listaItemSaidaMaterial = itemSaidaMaterialDAO.BuscarTodosItensDaSaidaMaterial();
                return listaItemSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
