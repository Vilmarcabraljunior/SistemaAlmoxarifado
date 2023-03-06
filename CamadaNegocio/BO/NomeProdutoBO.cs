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
    /// Classe que faz a validação dos dados do nome do produto.
    /// </summary>
    public class NomeProdutoBO
    {
        /// <summary>
        /// Variável do tipo nome do produto com os atributos para serem preenchidos.
        /// </summary>
        NomeProduto nomeProduto;
        /// <summary>
        /// Váriavel da classe nomeProdutoDAO para chamar os métodos da classe DAO.
        /// </summary>
        NomeProdutoDAO nomeProdutoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do nome do produto.
        /// </summary>
        IList<NomeProduto> listaNomeProduto;

        /// <summary>
        /// Método que faz a Validação dos Dados do Produto.
        /// </summary>
        /// <param name="nomeProduto">Atributo do tipo nome do produto com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(NomeProduto nomeProduto)
        {
            if (string.IsNullOrEmpty(nomeProduto._Codigo))
            {
                throw new Exception("Campo CÓDIGO DO PRODUTO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(nomeProduto._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(nomeProduto._ProdutoNome))
            {
                throw new Exception("Campo NOME DO PRODUTO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(nomeProduto._ProdutoPrecoUnitario.ToString()))
            {
                throw new Exception("Campo PREÇO UNITÁRIO é Obrigatório.");
            }
                       
            else if (nomeProduto._Conta._ContaID.Equals(0))
            {
                throw new Exception("Selecione uma CONTA.");
            }
            else if (nomeProduto._Unidade._UnidadeID.Equals(0))
            {
                throw new Exception("Selecione uma UNIDADE.");
            }
           
        }
        /// <summary>
        /// Método que não deixa excluir um nome do Produto sem que o seu id seja informado.
        /// </summary>
        /// <param name="nomeProduto">Atributo do tipo nome do produto com os atributos que serão validados.</param>
        public void ValidacaoExcluir(NomeProduto nomeProduto)
        {
            if (nomeProduto._NomeProdutoID.Equals(0))
            {
                throw new Exception("Selecione um PRODUTO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Variável do tipo nome do produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(NomeProduto nomeProduto)
        {
            try
            {
                ValidacaoSalvar(nomeProduto);

                nomeProdutoDAO = new NomeProdutoDAO();

                if (nomeProduto._NomeProdutoID != 0)
                {
                    nomeProdutoDAO.Atualizar(nomeProduto);
                }
                else
                {
                    nomeProdutoDAO.Salvar(nomeProduto);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um nome do produto.
        /// </summary>
        /// <param name="nomeProduto">Variável do tipo nome do produto com o valor do id para fazer a exclusão.</param>
        public void Excluir(NomeProduto nomeProduto)
        {
            try
            {
                ValidacaoExcluir(nomeProduto);

                nomeProdutoDAO = new NomeProdutoDAO();
                nomeProdutoDAO.Excluir(nomeProduto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um nome do produto pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do nome do produto preenchidos.</returns>
        public NomeProduto BuscarPorID(int id)
        {
            try
            {
                nomeProduto = new NomeProduto();
                nomeProdutoDAO = new NomeProdutoDAO();

                nomeProduto = nomeProdutoDAO.BuscarPorID(id);
                return nomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um nome do produto pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o código.</param>
        /// <returns>retorna uma lista com os atributos daquele nome do produto que foi consultado.</returns>
        public IList<NomeProduto> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaNomeProduto = new List<NomeProduto>();
                nomeProdutoDAO = new NomeProdutoDAO();

                listaNomeProduto = nomeProdutoDAO.BuscarPorCodigo(codigo);
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um nome do produto pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele nome do produto que foi consultado.</returns>
        public IList<NomeProduto> BuscarPorNome(string nome)
        {
            try
            {
                listaNomeProduto = new List<NomeProduto>();
                nomeProdutoDAO = new NomeProdutoDAO();

                listaNomeProduto = nomeProdutoDAO.BuscarPorNome(nome);
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                
        /// <summary>
        /// Método para buscar todos os nomes dos produtos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os nomes dos produtos e seus atributos.</returns>
        public IList<NomeProduto> BuscarTodosNomesProdutos()
        {
            try
            {
                listaNomeProduto = new List<NomeProduto>();
                nomeProdutoDAO = new NomeProdutoDAO();

                listaNomeProduto = nomeProdutoDAO.BuscarTodosNomesProdutos();
                return listaNomeProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
