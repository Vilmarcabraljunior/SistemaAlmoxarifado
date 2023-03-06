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
    /// Classe que faz a validação dos dados do item da entrada de material.
    /// </summary>
    public class ItemEntradaMaterialBO
    {
        /// <summary>
        /// Variável do tipo item da entrada de material com os atributos para serem preenchidos.
        /// </summary>
        ItemEntradaMaterial itemEntradaMaterial;
        /// <summary>
        /// Váriavel da classe itemEntradaMaterialDAO para chamar os métodos da classe DAO.
        /// </summary>
        ItemEntradaMaterialDAO itemEntradaMaterialDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do item da entrada de material.
        /// </summary>
        IList<ItemEntradaMaterial> listaItemEntradaMaterial;

        /// <summary>
        /// Método que faz a validação dos dados do Item da Entrada de Material.
        /// </summary>
        /// <param name="itemEntradaMaterial">Atributo do tipo ItemEntradaMaterial com os atributos que seram validados.</param>
        #region Métodos Auxiliáres
        
        public void ValidacaoSalvar(ItemEntradaMaterial itemEntradaMaterial)
        {
            if (itemEntradaMaterial._EntradaMaterial._EntradaMaterialID.Equals(0))
            {
                throw new Exception("Entrada de Material é Obrigatória.");
            }
            else if (itemEntradaMaterial._Produto._ProdutoID.Equals(0))
            {
                throw new Exception("Produto é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um item da entrada de material.
        /// </summary>
        /// <param name="itemEntradaMaterial">Variável do tipo item da entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemEntradaMaterial itemEntradaMaterial)
        {
            try
            {
                ValidacaoSalvar(itemEntradaMaterial);

                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                if (itemEntradaMaterial._ItemEntradaMaterialID != 0)
                {
                    itemEntradaMaterialDAO.Atualizar(itemEntradaMaterial);
                }
                else
                {
                    itemEntradaMaterialDAO.Salvar(itemEntradaMaterial);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();
                itemEntradaMaterialDAO.Excluir(itemEntradaMaterial);

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
        public ItemEntradaMaterial BuscarPorID(int id)
        {
            try
            {
                EntradaMaterial entradaMaterial = new EntradaMaterial();
                itemEntradaMaterial = new ItemEntradaMaterial(entradaMaterial);
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                itemEntradaMaterial = itemEntradaMaterialDAO.BuscarPorID(id);
                return itemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();
                itemEntradaMaterialDAO.ExcluirItensDaEntradaMaterial(entradaMaterialID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar os itens da entrada de material pelo id da entrada de material.
        /// </summary>
        /// <param name="entradaMaterialID">Variável com o valor do id da entrada de material.</param>
        /// <returns>retorna uma lista com os atributos daquele item da entrada de material que foi consultado.</returns>
        public IList<ItemEntradaMaterial> BuscarItensDaEntradaMaterial(int entradaMaterialID)
        {
            try
            {
                listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                listaItemEntradaMaterial = itemEntradaMaterialDAO.BuscarItensDaEntradaMaterial(entradaMaterialID);
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da entrada de material.
        /// </summary>
        /// <returns>retorna uma lista com os atributos daquele item da entrada de material que foi consultado.</returns>
        public IList<ItemEntradaMaterial> BuscarItensDaEntradaMaterialPorData(string dataCadastro)
        {
            try
            {
                listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                listaItemEntradaMaterial = itemEntradaMaterialDAO.BuscarItensDaEntradaMaterialPorData(dataCadastro);
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os itens da entrada de material.
        /// </summary>
        /// <returns>retorna uma lista com os atributos daquele item da entrada de material que foi consultado.</returns>
        public IList<ItemEntradaMaterial> BuscarTodosItensDaEntradaMaterial()
        {
            try
            {
                listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
                itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                listaItemEntradaMaterial = itemEntradaMaterialDAO.BuscarTodosItensDaEntradaMaterial();
                return listaItemEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
