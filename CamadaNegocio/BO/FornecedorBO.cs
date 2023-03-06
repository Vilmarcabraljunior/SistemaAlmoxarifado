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
    /// Classe que faz a validação dos dados do fornecedor.
    /// </summary>
    public class FornecedorBO
    {
        /// <summary>
        /// Variável do tipo fornecedor com os atributos para serem preenchidos.
        /// </summary>
        Fornecedor fornecedor;
        /// <summary>
        /// Váriavel da classe fornecedorDAO para chamar os métodos da classe DAO.
        /// </summary>
        FornecedorDAO fornecedorDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do fornecedor.
        /// </summary>
        IList<Fornecedor> listaFornecedor;

        /// <summary>
        /// Método que faz a Validação dos Dados do Fornecedor.
        /// </summary>
        /// <param name="fornecedor">Atributo do tipo fornecedor com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Fornecedor fornecedor)
        {
            if (string.IsNullOrEmpty(fornecedor._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(fornecedor._FornecedorNome))
            {
                throw new Exception("Campo NOME DO FORNECEDOR é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um fornecedor sem que o seu id seja informado.
        /// </summary>
        /// <param name="fornecedor">Atributo do tipo fornecedor com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Fornecedor fornecedor)
        {
            if (fornecedor._FornecedorID.Equals(0))
            {
                throw new Exception("Selecione um FORNECEDOR para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um fornecedor.
        /// </summary>
        /// <param name="fornecedor">Variável do tipo fornecedor com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Fornecedor fornecedor)
        {
            try
            {
                ValidacaoSalvar(fornecedor);

                fornecedorDAO = new FornecedorDAO();

                if (fornecedor._FornecedorID != 0)
                {
                    fornecedorDAO.Atualizar(fornecedor);
                }
                else
                {
                    fornecedorDAO.Salvar(fornecedor);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um fornecedor.
        /// </summary>
        /// <param name="fornecedor">Variável do tipo fornecedor com o valor do id para fazer a exclusão.</param>
        public void Excluir(Fornecedor fornecedor)
        {
            try
            {
                ValidacaoExcluir(fornecedor);

                fornecedorDAO = new FornecedorDAO();
                fornecedorDAO.Excluir(fornecedor);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do fornecedor preenchidas.</returns>
        public Fornecedor BuscarPorID(int id)
        {
            try
            {
                fornecedor = new Fornecedor();
                fornecedorDAO = new FornecedorDAO();

                fornecedor = fornecedorDAO.BuscarPorID(id);
                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pelo cnpj.
        /// </summary>
        /// <param name="cnpj">Variável com o valor do cnpj.</param>
        /// <returns>retorna uma lista com os atributos daquele fornecedor que foi consultado.</returns>
        public IList<Fornecedor> BuscarPorCnpj(string cnpj)
        {
            try
            {
                listaFornecedor = new List<Fornecedor>();
                fornecedorDAO = new FornecedorDAO();

                listaFornecedor = fornecedorDAO.BuscarPorCnpj(cnpj);
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele fornecedor que foi consultado.</returns>
        public IList<Fornecedor> BuscarPorNome(string nome)
        {
            try
            {
                listaFornecedor = new List<Fornecedor>();
                fornecedorDAO = new FornecedorDAO();

                listaFornecedor = fornecedorDAO.BuscarPorNome(nome);
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pela razão social.
        /// </summary>
        /// <param name="razaoSocial">Variável com a razão social.</param>
        /// <returns>retorna uma lista com os atributos daquele fornecedor que foi consultado.</returns>
        public IList<Fornecedor> BuscarPorRazaoSocial(string razaoSocial)
        {
            try
            {
                listaFornecedor = new List<Fornecedor>();
                fornecedorDAO = new FornecedorDAO();

                listaFornecedor = fornecedorDAO.BuscarPorRazaoSocial(razaoSocial);
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os fornecedores da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os fornecedores e seus atributos.</returns>
        public IList<Fornecedor> BuscarTodosFornecedores()
        {
            try
            {
                listaFornecedor = new List<Fornecedor>();
                fornecedorDAO = new FornecedorDAO();

                listaFornecedor = fornecedorDAO.BuscarTodosFornecedores();
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
