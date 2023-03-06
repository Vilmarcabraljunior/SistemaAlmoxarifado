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
    /// Classe que faz a validação dos dados do item da requisição.
    /// </summary>
    public class ItemRequisicaoBO
    {
        /// <summary>
        /// Variável do tipo item da requisição com os atributos para serem preenchidos.
        /// </summary>
        ItemRequisicao itemRequisicao;
        /// <summary>
        /// Variável da classe itemRequisicaoDAO para chamar os métodos da classe DAO.
        /// </summary>
        ItemRequisicaoDAO itemRequisicaoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do item da requisição.
        /// </summary>
        IList<ItemRequisicao> listaItemRequisicao;

        /// <summary>
        /// Método que faz a validação dos dados do Item da Requisição.
        /// </summary>
        /// <param name="itemRequisicao">Atributo do tipo ItemRequisicao com os atributos que seram validados.</param>
        #region Métodos Auxiliáres

        public void ValidacaoSalvar(ItemRequisicao itemRequisicao)
        {
            if (itemRequisicao._Requisicao._RequisicaoID.Equals(0))
            {
                throw new Exception("Requisição é Obrigatória.");
            }
            else if (itemRequisicao._Produto._ProdutoID.Equals(0))
            {
                throw new Exception("Produto é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um item da requisição.
        /// </summary>
        /// <param name="itemRequisicao">Variável do tipo item da requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(ItemRequisicao itemRequisicao)
        {
            try
            {
                ValidacaoSalvar(itemRequisicao);

                itemRequisicaoDAO = new ItemRequisicaoDAO();

                if (itemRequisicao._ItemRequisicaoID != 0)
                {
                    itemRequisicaoDAO.Atualizar(itemRequisicao);
                }
                else
                {
                    itemRequisicaoDAO.Salvar(itemRequisicao);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                itemRequisicaoDAO = new ItemRequisicaoDAO();
                itemRequisicaoDAO.Excluir(itemRequisicao);

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
        public ItemRequisicao BuscarPorID(int id)
        {
            try
            {
                Requisicao requisicao = new Requisicao();
                itemRequisicao = new ItemRequisicao(requisicao);
                itemRequisicaoDAO = new ItemRequisicaoDAO();

                itemRequisicao = itemRequisicaoDAO.BuscarPorID(id);
                return itemRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                itemRequisicaoDAO = new ItemRequisicaoDAO();
                itemRequisicaoDAO.ExcluirItensDaRequisicao(requisicaoID);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar os itens da requisição pelo id da requisição.
        /// </summary>
        /// <param name="requisicaoID">Variável com o valor do id da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquele item da requisição que foi consultado.</returns>
        public IList<ItemRequisicao> BuscarItensDaRequisicao(int requisicaoID)
        {
            try
            {
                listaItemRequisicao = new List<ItemRequisicao>();
                itemRequisicaoDAO = new ItemRequisicaoDAO();

                listaItemRequisicao = itemRequisicaoDAO.BuscarItensDaRequisicao(requisicaoID);
                return listaItemRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
