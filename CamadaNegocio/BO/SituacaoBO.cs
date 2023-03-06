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
    /// Classe que faz a validação dos dados da situação.
    /// </summary>
    public class SituacaoBO
    {
        /// <summary>
        /// Variável do tipo situação com os atributos para serem preenchidos.
        /// </summary>
        Situacao situacao;
        /// <summary>
        /// Váriavel da classe situacaoDAO para chamar os métodos da classe DAO.
        /// </summary>
        SituacaoDAO situacaoDAO;
        /// <summary>
        /// Variável do tipo Lista para retorna os dados da situação.
        /// </summary>
        IList<Situacao> listaSituacao;

        /// <summary>
        /// Método que faz a Validação dos Dados da situação.
        /// </summary>
        /// <param name="situacao">Atributo do tipo situação com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Situacao situacao)
        {
            if (string.IsNullOrEmpty(situacao._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(situacao._SituacaoNome))
            {
                throw new Exception("Campo SITUAÇÃO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma situação sem que o seu id seja informado.
        /// </summary>
        /// <param name="situacao">Atributo do tipo situação com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Situacao situacao)
        {
            if (situacao._SituacaoID.Equals(0))
            {
                throw new Exception("Selecione uma SITUAÇÃO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma situação.
        /// </summary>
        /// <param name="situacao">Variável do tipo situação com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Situacao situacao)
        {
            try
            {
                ValidacaoSalvar(situacao);

                situacaoDAO = new SituacaoDAO();

                if (situacao._SituacaoID != 0)
                {
                    situacaoDAO.Atualizar(situacao);
                }
                else
                {
                    situacaoDAO.Salvar(situacao);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir uma situação.
        /// </summary>
        /// <param name="situacao">Variável do tipo situação com o valor do id para fazer a exclusão.</param>
        public void Excluir(Situacao situacao)
        {
            try
            {
                ValidacaoExcluir(situacao);

                situacaoDAO = new SituacaoDAO();
                situacaoDAO.Excluir(situacao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma situação pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da situação preenchidas.</returns>
        public Situacao BuscarPorID(int id)
        {
            try
            {
                situacao = new Situacao();
                situacaoDAO = new SituacaoDAO();

                situacao = situacaoDAO.BuscarPorID(id);
                return situacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma situação pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquela situação que foi consultada.</returns>
        public IList<Situacao> BuscarPorNome(string nome)
        {
            try
            {
                listaSituacao = new List<Situacao>();
                situacaoDAO = new SituacaoDAO();

                listaSituacao = situacaoDAO.BuscarPorNome(nome);
                return listaSituacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as situações da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as situações e seus atributos.</returns>
        public IList<Situacao> BuscarTodasSituacoes()
        {
            try
            {
                listaSituacao = new List<Situacao>();
                situacaoDAO = new SituacaoDAO();

                listaSituacao = situacaoDAO.BuscarTodasSituacoes();
                return listaSituacao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
