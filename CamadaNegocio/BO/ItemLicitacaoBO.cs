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
    /// Classe que faz a validação dos dados do item da licitação.
    /// </summary>
    public class ItemLicitacaoBO
    {
        /// <summary>
        /// Variável do tipo item da licitação com os atributos para serem preenchidos.
        /// </summary>
        ItemLicitacao itemLicitacao;
        /// <summary>
        /// Váriavel da classe itemLicitacaoDAO para chamar os métodos da classe DAO.
        /// </summary>
        ItemLicitacaoDAO itemLicitacaoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do item da licitação.
        /// </summary>
        IList<ItemLicitacao> listaItemLicitacao;

        /// <summary>
        /// Método que faz a validação dos dados do Item da Licitação.
        /// </summary>
        /// <param name="itemLicitacao">Atributo do tipo ItemLicitacao com os atributos que seram validados.</param>
        #region Métodos Auxiliáres

        public void ValidacaoSalvar(ItemLicitacao itemLicitacao)
        {
            if (itemLicitacao._Licitacao._LicitacaoID.Equals(0))
            {
                throw new Exception("Estoque é Obrigatório.");
            }
            else if (itemLicitacao._Produto._ProdutoID.Equals(0))
            {
                throw new Exception("Produto é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um item da licitação.
        /// </summary>
        /// <param name="itemLicitacao">Variável do tipo item da licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemLicitacao itemLicitacao)
        {
            try
            {
                ValidacaoSalvar(itemLicitacao);

                itemLicitacaoDAO = new ItemLicitacaoDAO();

                if (itemLicitacao._ItemLicitacaoID != 0)
                {
                    itemLicitacaoDAO.Atualizar(itemLicitacao);
                }
                else
                {
                    itemLicitacaoDAO.Salvar(itemLicitacao);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                itemLicitacaoDAO = new ItemLicitacaoDAO();
                itemLicitacaoDAO.Excluir(itemLicitacao);

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
        public ItemLicitacao BuscarPorID(int id)
        {
            try
            {
                Licitacao licitacao = new Licitacao();
                itemLicitacao = new ItemLicitacao(licitacao);
                itemLicitacaoDAO = new ItemLicitacaoDAO();

                itemLicitacao = itemLicitacaoDAO.BuscarPorID(id);
                return itemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto do item licitação pelo seu código.
        /// </summary>
        /// <param name="produtoCodigo">Atributo com o valor do código do produto.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public ItemLicitacao BuscarProdutoDoItemLicitacao(string produtoCodigo)
        {
            try
            {
                Licitacao licitacao = new Licitacao();
                itemLicitacao = new ItemLicitacao(licitacao);
                itemLicitacaoDAO = new ItemLicitacaoDAO();

                itemLicitacao = itemLicitacaoDAO.BuscarProdutoDoItemLicitacao(produtoCodigo);
                return itemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                itemLicitacaoDAO = new ItemLicitacaoDAO();
                itemLicitacaoDAO.ExcluirItensDaLicitacao(licitacaoID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar os itens da licitação pelo id da licitação.
        /// </summary>
        /// <param name="licitacaoID">Variável com o valor do id da licitação.</param>
        /// <returns>retorna uma lista com os atributos daquele item da licitação que foi consultado.</returns>
        public IList<ItemLicitacao> BuscarItensDaLicitacao(int licitacaoID)
        {
            try
            {
                listaItemLicitacao = new List<ItemLicitacao>();
                itemLicitacaoDAO = new ItemLicitacaoDAO();

                listaItemLicitacao = itemLicitacaoDAO.BuscarItensDaLicitacao(licitacaoID);
                return listaItemLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
