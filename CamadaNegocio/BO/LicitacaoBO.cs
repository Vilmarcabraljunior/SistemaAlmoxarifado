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
    /// Classe que faz a validação dos dados da licitação.
    /// </summary>
    public class LicitacaoBO
    {
        /// <summary>
        /// Variável do tipo licitação com os atributos para serem preenchidos.
        /// </summary>
        Licitacao licitacao;
        /// <summary>
        /// Váriavel da classe licitacaoDAO para chamar os métdos da classe DAO.
        /// </summary>
        LicitacaoDAO licitacaoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados da licitação.
        /// </summary>
        IList<Licitacao> listaLicitacao;

        /// <summary>
        /// Método que faz a Validação dos Dados da licitação.
        /// </summary>
        /// <param name="licitacao">Atributo do tipo licitação com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Licitacao licitacao)
        {
            if (string.IsNullOrEmpty(licitacao._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma licitação sem que o seu id seja informado.
        /// </summary>
        /// <param name="licitacao">Atributo do tipo licitacao com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Licitacao licitacao)
        {
            if (licitacao._LicitacaoID.Equals(0))
            {
                throw new Exception("Selecione uma LICITAÇÃO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma licitação.
        /// </summary>
        /// <param name="licitacao">Variável do tipo licitação com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da licitação.</returns>
        public int Salvar(Licitacao licitacao)
        {
            try
            {
                ValidacaoSalvar(licitacao);

                licitacaoDAO = new LicitacaoDAO();

                if (licitacao._LicitacaoID != 0)
                {
                    return licitacaoDAO.Atualizar(licitacao);
                }
                else
                {
                    return licitacaoDAO.Salvar(licitacao);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(licitacao);

                licitacaoDAO = new LicitacaoDAO();
                licitacaoDAO.Excluir(licitacao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                licitacao = new Licitacao();
                licitacaoDAO = new LicitacaoDAO();

                licitacao = licitacaoDAO.BuscarPorID(id);
                return licitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a ultima licitação cadastrada.
        /// </summary>
        /// <returns>Retorna uma variável com os atributos da licitação preenchidas.</returns>
        public Licitacao BuscarPorUltimaLicitacao()
        {
            try
            {
                licitacao = new Licitacao();
                licitacaoDAO = new LicitacaoDAO();

                licitacao = licitacaoDAO.BuscarPorUltimaLicitacao();
                return licitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pela data do cadastro.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data do cadastro.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarPorDataCadastro(string dataCadastro)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarPorDataCadastro(dataCadastro);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pela data prevista de entrega.
        /// </summary>
        /// <param name="dataInicial">Variável com a data prevista de entrega.</param>
        /// <param name="dataFinal">Variável com a data prevista de entrega.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarDataCadastroPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarDataCadastroPorBetween(dataInicial, dataFinal);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id do processo.
        /// </summary>
        /// <param name="processoID">Variável com o valor do id do processo.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarPorProcesso(int processoID)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarPorProcesso(processoID);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id da modalidade de compra.
        /// </summary>
        /// <param name="modalidadeCompraID">Variável com o valor do id da modalidade de compra.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarPorModalidadeCompra(int modalidadeCompraID)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarPorModalidadeCompra(modalidadeCompraID);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id da situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor do id da situação.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarPorSituacao(situacaoID);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma licitação pelo id do usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do id do usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela licitação que foi consultada.</returns>
        public IList<Licitacao> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarPorUsuario(usuarioID);
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                listaLicitacao = new List<Licitacao>();
                licitacaoDAO = new LicitacaoDAO();

                listaLicitacao = licitacaoDAO.BuscarTodasLicitacoes();
                return listaLicitacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
