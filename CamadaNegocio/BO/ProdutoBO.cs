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
    /// Classe que faz a validação dos dados do produto.
    /// </summary>
    public class ProdutoBO
    {
        /// <summary>
        /// Variável do tipo produto com os atributos para serem preenchidos.
        /// </summary>
        Produto produto;
        /// <summary>
        /// Váriavel da classe produtoDAO para chamar os métodos da classe DAO.
        /// </summary>
        ProdutoDAO produtoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do produto.
        /// </summary>
        IList<Produto> listaProduto;

        /// <summary>
        /// Método que faz a Validação dos Dados do Produto.
        /// </summary>
        /// <param name="produto">Atributo do tipo produto com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Produto produto)
        {
            if (string.IsNullOrEmpty(produto._Codigo))
            {
                throw new Exception("Campo CÓDIGO DO PRODUTO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(produto._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(produto._ProdutoNome))
            {
                throw new Exception("Campo NOME DO PRODUTO é Obrigatório.");
            }
            
            else if (produto._Conta._ContaID.Equals(0))
            {
                throw new Exception("Selecione uma CONTA.");
            }
            else if (produto._Unidade._UnidadeID.Equals(0))
            {
                throw new Exception("Selecione uma UNIDADE.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um Produto sem que o seu id seja informado.
        /// </summary>
        /// <param name="produto">Atributo do tipo produto com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Produto produto)
        {
            if (produto._ProdutoID.Equals(0))
            {
                throw new Exception("Selecione um PRODUTO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um produto.
        /// </summary>
        /// <param name="produto">Variável do tipo produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Produto produto)
        {
            try
            {
                ValidacaoSalvar(produto);

                produtoDAO = new ProdutoDAO();

                if (produto._ProdutoID != 0)
                {
                    produtoDAO.Atualizar(produto);
                }
                else
                {
                    produtoDAO.Salvar(produto);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um produto.
        /// </summary>
        /// <param name="produto">Variável do tipo produto com o valor do id para fazer a exclusão.</param>
        public void Excluir(Produto produto)
        {
            try
            {
                ValidacaoExcluir(produto);

                produtoDAO = new ProdutoDAO();
                produtoDAO.Excluir(produto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar a quantidade de estoque do produto.
        /// </summary>
        /// <param name="quantidadeEntrada">Variável com o valor da quantidade da entrada.</param>
        /// <param name="codigo">Atributo com o valor do produto.</param>
        /// <param name="produtoValorTotal">Atributo com o valor total do produto.</param>
        public void AtualizarQtdeEstoquePorCodigoProdutoEntrada(int quantidadeEntrada, string produtoNome, decimal produtoValorTotal)
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produtoDAO.AtualizarQtdeEstoquePorCodigoProdutoEntrada(quantidadeEntrada, produtoNome, produtoValorTotal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar a quantidade de estoque do produto.
        /// </summary>
        /// <param name="quantidadeSaida">Variável com o valor da quantidade da saída.</param>
        /// <param name="codigo">Variável com o código do produto.</param>
        /// <param name="produtoValorTotal">Variável com o valor total do produto.</param>
        public void AtualizarQtdeEstoquePorCodigoProdutoSaida(int quantidadeSaida, string produtoNome, decimal produtoValorTotal)
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produtoDAO.AtualizarQtdeEstoquePorCodigoProdutoSaida(quantidadeSaida, produtoNome, produtoValorTotal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar o preco unitário dos produtos do estoque.
        /// </summary>
        public void AtualizarPrecoUnitarioMedioEstoque()
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produtoDAO.AtualizarPrecoUnitarioMedioEstoque();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do produto preenchidos.</returns>
        public Produto BuscarPorID(int id)
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produto = produtoDAO.BuscarPorID(id);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para retornar um produto que está com estoque vazio.
        /// </summary>
        /// <param name="produtoNome">Atributo com o valor do nome do produto.</param>
        /// <returns>Retorna uma variável com os atributos do produto preenchidos.</returns>
        public Produto VarificaSeProdutoTemEstoqueVazio(string produtoNome)
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produto = produtoDAO.VarificaSeProdutoTemEstoqueVazio(produtoNome);
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Método para buscar pelo último produto cadastrado.
        /// </summary>
        /// <returns>Retorna uma variável com os atributos do produto preenchidos.</returns>
        public Produto BuscarPorUltimoProdutoCadastrado()
        {
            try
            {
                produto = new Produto();
                produtoDAO = new ProdutoDAO();

                produto = produtoDAO.BuscarPorUltimoProdutoCadastrado();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o código.</param>
        /// <returns>retorna uma lista com os atributos daquele produto que foi consultado.</returns>
        public IList<Produto> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaProduto = new List<Produto>();
                produtoDAO = new ProdutoDAO();

                listaProduto = produtoDAO.BuscarPorCodigo(codigo);
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele produto que foi consultado.</returns>
        public IList<Produto> BuscarPorNome(string nome)
        {
            try
            {
                listaProduto = new List<Produto>();
                produtoDAO = new ProdutoDAO();

                listaProduto = produtoDAO.BuscarPorNome(nome);
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
               
        /// <summary>
        /// Método para buscar um produto pelo preço.
        /// </summary>
        /// <param name="precoUnitario">Variável com o preço.</param>
        /// <returns>retorna uma lista com os atributos daquele produto que foi consultado.</returns>
        public IList<Produto> BuscarPorPrecoUnitario(decimal precoUnitario)
        {
            try
            {
                listaProduto = new List<Produto>();
                produtoDAO = new ProdutoDAO();

                listaProduto = produtoDAO.BuscarPorPrecoUnitario(precoUnitario);
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
                
        /// <summary>
        /// Método para buscar todos os produtos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os produtos e seus atributos.</returns>
        public IList<Produto> BuscarTodosProdutos()
        {
            try
            {
                listaProduto = new List<Produto>();
                produtoDAO = new ProdutoDAO();

                listaProduto = produtoDAO.BuscarTodosProdutos();
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
