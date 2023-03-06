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
    /// Classe que faz a validação dos dados do endereço.
    /// </summary>
    public class EnderecoBO
    {
        /// <summary>
        /// Variável do tipo endereço com os atributos para serem preenchidos.
        /// </summary>
        Endereco endereco;
        /// <summary>
        /// Váriavel da classe enderecoDAO para chamar os métodos da classe DAO.
        /// </summary>
        EnderecoDAO enderecoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do endereço.
        /// </summary>
        IList<Endereco> listaEndereco;

        /// <summary>
        /// Método que faz a Validação dos Dados do endereço.
        /// </summary>
        /// <param name="endereco">Atributo do tipo endereço com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Endereco endereco)
        {
            if (string.IsNullOrEmpty(endereco._Codigo))
            {
                throw new Exception("Campo CÓDIGO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(endereco._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(endereco._EnderecoDescricao))
            {
                throw new Exception("Campo ENDEREÇO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um endereço sem que o seu id seja informado.
        /// </summary>
        /// <param name="endereco">Atributo do tipo endereço com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Endereco endereco)
        {
            if (endereco._EnderecoID.Equals(0))
            {
                throw new Exception("Selecione um ENDEREÇO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um endereço.
        /// </summary>
        /// <param name="endereco">Variável do tipo endereço com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Endereco endereco)
        {
            try
            {
                ValidacaoSalvar(endereco);

                enderecoDAO = new EnderecoDAO();

                if (endereco._EnderecoID != 0)
                {
                    enderecoDAO.Atualizar(endereco);
                }
                else
                {
                    enderecoDAO.Salvar(endereco);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um endereço.
        /// </summary>
        /// <param name="endereco">Variável do tipo endereço com o valor do id para fazer a exclusão.</param>
        public void Excluir(Endereco endereco)
        {
            try
            {
                ValidacaoExcluir(endereco);

                enderecoDAO = new EnderecoDAO();
                enderecoDAO.Excluir(endereco);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um endereço pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do endereço preenchidos.</returns>
        public Endereco BuscarPorID(int id)
        {
            try
            {
                endereco = new Endereco();
                enderecoDAO = new EnderecoDAO();

                endereco = enderecoDAO.BuscarPorID(id);
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um endereço pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>retorna uma lista com os atributos daquele endereço que foi consultado.</returns>
        public IList<Endereco> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaEndereco = new List<Endereco>();
                enderecoDAO = new EnderecoDAO();

                listaEndereco = enderecoDAO.BuscarPorCodigo(codigo);
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um endereço pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com a descrição do endereço.</param>
        /// <returns>retorna uma lista com os atributos daquele endereço que foi consultado.</returns>
        public IList<Endereco> BuscarPorDescricao(string descricao)
        {
            try
            {
                listaEndereco = new List<Endereco>();
                enderecoDAO = new EnderecoDAO();

                listaEndereco = enderecoDAO.BuscarPorDescricao(descricao);
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os endereços da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os endereços e seus atributos.</returns>
        public IList<Endereco> BuscarTodosEnderecos()
        {
            try
            {
                listaEndereco = new List<Endereco>();
                enderecoDAO = new EnderecoDAO();

                listaEndereco = enderecoDAO.BuscarTodosEnderecos();
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
