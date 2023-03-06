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
    /// Classe que faz a validação dos dados da conta.
    /// </summary>
    public class ContaBO
    {
        /// <summary>
        /// Variável do tipo conta com os atributos para serem preenchidos.
        /// </summary>
        Conta conta;
        /// <summary>
        /// Váriavel da classe contaDAO para chamar os métodos da classe DAO.
        /// </summary>
        ContaDAO contaDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados da conta.
        /// </summary>
        IList<Conta> listaConta;

        /// <summary>
        /// Método que faz a Validação dos Dados da Conta.
        /// </summary>
        /// <param name="conta">Atributo do tipo conta com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Conta conta)
        {
            if (string.IsNullOrEmpty(conta._ContaNumero))
            {
                throw new Exception("Campo NÚMERO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(conta._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma conta sem que o seu id seja informado.
        /// </summary>
        /// <param name="conta">Atributo do tipo conta com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Conta conta)
        {
            if (conta._ContaID.Equals(0))
            {
                throw new Exception("Selecione uma CONTA para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma conta.
        /// </summary>
        /// <param name="conta">Variável do tipo conta com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Conta conta)
        {
            try
            {
                ValidacaoSalvar(conta);

                contaDAO = new ContaDAO();

                if (conta._ContaID != 0)
                {
                    contaDAO.Atualizar(conta);
                }
                else
                {
                    contaDAO.Salvar(conta);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir uma conta.
        /// </summary>
        /// <param name="conta">Variável do tipo conta com o valor do id para fazer a exclusão.</param>
        public void Excluir(Conta conta)
        {
            try
            {
                ValidacaoExcluir(conta);

                contaDAO = new ContaDAO();
                contaDAO.Excluir(conta);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma conta pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da conta preenchidas.</returns>
        public Conta BuscarPorID(int id)
        {
            try
            {
                conta = new Conta();
                contaDAO = new ContaDAO();

                conta = contaDAO.BuscarPorID(id);
                return conta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma conta pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com a descrição da conta.</param>
        /// <returns>retorna uma lista com os atributos daquela conta que foi consultada.</returns>
        public IList<Conta> BuscarPorDescricao(string descricao)
        {
            try
            {
                listaConta = new List<Conta>();
                contaDAO = new ContaDAO();

                listaConta = contaDAO.BuscarPorDescricao(descricao);
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma conta pelo número.
        /// </summary>
        /// <param name="numero">Variável com o número da conta.</param>
        /// <returns>retorna uma lista com os atributos daquela conta que foi consultada.</returns>
        public IList<Conta> BuscarPorNumero(string numero)
        {
            try
            {
                listaConta = new List<Conta>();
                contaDAO = new ContaDAO();

                listaConta = contaDAO.BuscarPorNumero(numero);
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as contas da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as contas e seus atributos.</returns>
        public IList<Conta> BuscarTodasContas()
        {
            try
            {
                listaConta = new List<Conta>();
                contaDAO = new ContaDAO();

                listaConta = contaDAO.BuscarTodasContas();
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
