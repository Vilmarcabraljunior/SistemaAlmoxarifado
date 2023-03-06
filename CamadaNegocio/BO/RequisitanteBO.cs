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
    /// Classe que faz a validação dos dados do requisitante.
    /// </summary>
    public class RequisitanteBO
    {
        /// <summary>
        /// Variável do tipo requisitante com os atributos para serem preenchidos.
        /// </summary>
        Requisitante requisitante;
        /// <summary>
        /// Váriavel da classe requisitanteDAO para chamar os métodos da classe DAO.
        /// </summary>
        RequisitanteDAO requisitanteDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do requisitante.
        /// </summary>
        IList<Requisitante> listaRequisitante;

        /// <summary>
        /// Método que faz a Validação dos Dados do requisitante.
        /// </summary>
        /// <param name="requisitante">Atributo do tipo requisitante com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Requisitante requisitante)
        {
            if (string.IsNullOrEmpty(requisitante._Codigo))
            {
                throw new Exception("Campo CÓDIGO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(requisitante._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(requisitante._RequisitanteNome))
            {
                throw new Exception("Campo NOME DO REQUISITANTE é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um requisitante sem que o seu id seja informado.
        /// </summary>
        /// <param name="requisitante">Atributo do tipo requisitante com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Requisitante requisitante)
        {
            if (requisitante._RequisitanteID.Equals(0))
            {
                throw new Exception("Selecione um REQUISITANTE para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um requisitante.
        /// </summary>
        /// <param name="requisitante">Variável do tipo requisitante com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Requisitante requisitante)
        {
            try
            {
                ValidacaoSalvar(requisitante);

                requisitanteDAO = new RequisitanteDAO();

                if (requisitante._RequisitanteID != 0)
                {
                    requisitanteDAO.Atualizar(requisitante);
                }
                else
                {
                    requisitanteDAO.Salvar(requisitante);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um requisitante.
        /// </summary>
        /// <param name="requisitante">Variável do tipo requisitante com o valor do id para fazer a exclusão.</param>
        public void Excluir(Requisitante requisitante)
        {
            try
            {
                ValidacaoExcluir(requisitante);

                requisitanteDAO = new RequisitanteDAO();
                requisitanteDAO.Excluir(requisitante);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um requisitante pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do requisitante preenchidos.</returns>
        public Requisitante BuscarPorID(int id)
        {
            try
            {
                requisitante = new Requisitante();
                requisitanteDAO = new RequisitanteDAO();

                requisitante = requisitanteDAO.BuscarPorID(id);
                return requisitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um requisitante pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o código do requisitante.</param>
        /// <returns>retorna uma lista com os atributos daquele requisitante que foi consultado.</returns>
        public IList<Requisitante> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaRequisitante = new List<Requisitante>();
                requisitanteDAO = new RequisitanteDAO();

                listaRequisitante = requisitanteDAO.BuscarPorCodigo(codigo);
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um requisitante pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o tipo do requisitante.</param>
        /// <returns>retorna uma lista com os atributos daquele requisitante que foi consultado.</returns>
        public IList<Requisitante> BuscarPorNome(string nome)
        {
            try
            {
                listaRequisitante = new List<Requisitante>();
                requisitanteDAO = new RequisitanteDAO();

                listaRequisitante = requisitanteDAO.BuscarPorNome(nome);
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os requisitantes da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os requisitantes e seus atributos.</returns>
        public IList<Requisitante> BuscarTodosRequisitantes()
        {
            try
            {
                listaRequisitante = new List<Requisitante>();
                requisitanteDAO = new RequisitanteDAO();

                listaRequisitante = requisitanteDAO.BuscarTodosRequisitantes();
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
