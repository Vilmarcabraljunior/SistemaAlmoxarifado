using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.DAO
{
    /// <summary>
    /// Classe com os comandos CRUD do produto.
    /// </summary>
    public class ProdutoDAO
    {
        /// <summary>
        /// Método para Gravar um produto.
        /// </summary>
        /// <param name="produto">Variável do tipo produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Produto (codigo, dataCadastro, produtoNome, produtoPrecoUnitario, produtoValorTotal, quantidadeAtendida, quantidadeSolicitada,"+
                    " quantidadeEntrada, quantidadeSaida, quantidadeEstoque, estoqueValorTotal, produtoTipo, contaID, unidadeID) "+
                    " values(@codigo, @dataCadastro, @produtoNome, @produtoPrecoUnitario, @produtoValorTotal, @quantidadeAtendida, @quantidadeSolicitada," +
                    " @quantidadeEntrada, @quantidadeSaida, @quantidadeEstoque, @estoqueValorTotal, @produtoTipo, @contaID, @unidadeID)";

                cmd.Parameters.AddWithValue("@codigo", produto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", produto._DataCadastro);
                cmd.Parameters.AddWithValue("@produtoNome", produto._ProdutoNome);
                cmd.Parameters.AddWithValue("@produtoPrecoUnitario", produto._ProdutoPrecoUnitario);
                cmd.Parameters.AddWithValue("@produtoValorTotal", produto._ProdutoValorTotal);
                cmd.Parameters.AddWithValue("@quantidadeAtendida", produto._QuantidadeAtendida);
                cmd.Parameters.AddWithValue("@quantidadeSolicitada", produto._QuantidadeSolicitada);
                cmd.Parameters.AddWithValue("@quantidadeEntrada", produto._QuantidadeEntrada);
                cmd.Parameters.AddWithValue("@quantidadeSaida", produto._QuantidadeSaida);
                cmd.Parameters.AddWithValue("@quantidadeEstoque", produto._QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@estoqueValorTotal", produto._EstoqueValorTotal);
                cmd.Parameters.AddWithValue("@produtoTipo", produto._ProdutoTipo);
                cmd.Parameters.AddWithValue("@contaID", produto._Conta._ContaID);
                cmd.Parameters.AddWithValue("@unidadeID", produto._Unidade._UnidadeID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um produto.
        /// </summary>
        /// <param name="produto">Variável do tipo produto com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Produto produto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Produto SET codigo=@codigo, dataCadastro=@dataCadastro, produtoNome=@produtoNome, produtoPrecoUnitario=@produtoPrecoUnitario," +
                    " produtoValorTotal=@produtoValorTotal, quantidadeAtendida=@quantidadeAtendida, quantidadeSolicitada=@quantidadeSolicitada," +
                    " quantidadeEntrada=@quantidadeEntrada, quantidadeSaida=@quantidadeSaida, quantidadeEstoque=@quantidadeEstoque, estoqueValorTotal=@estoqueValorTotal," +
                    " produtoTipo=@produtoTipo, contaID=@contaID, unidadeID=@unidadeID WHERE produtoID=@produtoID";

                cmd.Parameters.AddWithValue("@produtoID", produto._ProdutoID);
                cmd.Parameters.AddWithValue("@codigo", produto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", produto._DataCadastro);
                cmd.Parameters.AddWithValue("@produtoNome", produto._ProdutoNome);
                cmd.Parameters.AddWithValue("@produtoPrecoUnitario", produto._ProdutoPrecoUnitario);
                cmd.Parameters.AddWithValue("@produtoValorTotal", produto._ProdutoValorTotal);
                cmd.Parameters.AddWithValue("@quantidadeAtendida", produto._QuantidadeAtendida);
                cmd.Parameters.AddWithValue("@quantidadeSolicitada", produto._QuantidadeSolicitada);
                cmd.Parameters.AddWithValue("@quantidadeEntrada", produto._QuantidadeEntrada);
                cmd.Parameters.AddWithValue("@quantidadeSaida", produto._QuantidadeSaida);
                cmd.Parameters.AddWithValue("@quantidadeEstoque", produto._QuantidadeEstoque);
                cmd.Parameters.AddWithValue("@estoqueValorTotal", produto._EstoqueValorTotal);
                cmd.Parameters.AddWithValue("@produtoTipo", produto._ProdutoTipo);
                cmd.Parameters.AddWithValue("@contaID", produto._Conta._ContaID);
                cmd.Parameters.AddWithValue("@unidadeID", produto._Unidade._UnidadeID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar a quantidade do estoque pela entrada do produto pelo código.
        /// </summary>
        /// <param name="quantidadeEntrada">Variável com o valor da quantidade da entrada.</param>
        /// <param name="codigo">Variável com o código do produto.</param>
        /// <param name="produtoValorTotal">Variável com o valor total do produto.</param>
        public void AtualizarQtdeEstoquePorCodigoProdutoEntrada(int quantidadeEntrada, string produtoNome, decimal produtoValorTotal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Produto SET quantidadeEstoque = quantidadeEstoque + @quantidadeEntrada," +
                    " estoqueValorTotal = estoqueValorTotal + @produtoValorTotal WHERE produtoNome=@produtoNome";

                cmd.Parameters.AddWithValue("@produtoNome", produtoNome);
                cmd.Parameters.AddWithValue("@quantidadeEntrada", quantidadeEntrada);
                cmd.Parameters.AddWithValue("@produtoValorTotal", produtoValorTotal);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a quantidade de estoque entrada do produto pelo código " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar a quantidade do estoque pela saida do produto pelo código.
        /// </summary>
        /// <param name="quantidadeSaida">Variável com o valor da quantidade da saída.</param>
        /// <param name="codigo">Variável com o código do produto.</param>
        /// <param name="produtoValorTotal">Variável com o valor total do produto.</param>
        public void AtualizarQtdeEstoquePorCodigoProdutoSaida(int quantidadeSaida, string produtoNome, decimal produtoValorTotal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Produto SET quantidadeEstoque = quantidadeEstoque - @quantidadeSaida," +
                    " estoqueValorTotal = estoqueValorTotal - @produtoValorTotal WHERE produtoNome=@produtoNome";

                cmd.Parameters.AddWithValue("@produtoNome", produtoNome);
                cmd.Parameters.AddWithValue("@quantidadeSaida", quantidadeSaida);
                cmd.Parameters.AddWithValue("@produtoValorTotal", produtoValorTotal);
                
                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a quantidade de estoque saída do produto pelo código " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar o preco unitário dos produtos do estoque.
        /// </summary>
        public void AtualizarPrecoUnitarioMedioEstoque()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Produto SET produtoPrecoUnitario = estoqueValorTotal / quantidadeEstoque WHERE estoqueValorTotal > 0.00 and quantidadeEstoque > 0";
                               

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar o preço unitário dos produtos do estoque " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Produto WHERE produtoID = @produtoID";

                cmd.Parameters.AddWithValue("@produtoID", produto._ProdutoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse produto " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um produto pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do produto preenchidas.</returns>
        public Produto BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto WHERE produtoID = @produtoID";

                cmd.Parameters.AddWithValue("@produtoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Produto produto = new Produto();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    dr.Read();
                    produto._ProdutoID = (int)dr["produtoID"];
                    produto._Codigo = dr["codigo"].ToString();
                    produto._DataCadastro = dr["dataCadastro"].ToString();
                    produto._ProdutoNome = dr["produtoNome"].ToString();
                    produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                    produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                    produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                    produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                    produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                    produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                    produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                    produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                    produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                    produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                    produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);
                }
                else
                {
                    produto = null;
                }
                dr.Close();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse produto pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para retornar um produto que está com estoque vazio.
        /// </summary>
        /// <param name="produtoNome">Atributo com o valor do nome do produto.</param>
        /// <returns>Retorna uma variável com os atributos do produto preenchidas.</returns>
        public Produto VarificaSeProdutoTemEstoqueVazio(string produtoNome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto WHERE quantidadeAtendida = 0 and quantidadeSolicitada = 0 and"+
                    " quantidadeEntrada = 0 and quantidadeSaida = 0 and quantidadeEstoque >= 0 and produtoNome = @produtoNome";

                cmd.Parameters.AddWithValue("@produtoNome", produtoNome);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Produto produto = new Produto();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    dr.Read();
                    produto._ProdutoID = (int)dr["produtoID"];
                    produto._Codigo = dr["codigo"].ToString();
                    produto._DataCadastro = dr["dataCadastro"].ToString();
                    produto._ProdutoNome = dr["produtoNome"].ToString();
                    produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                    produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                    produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                    produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                    produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                    produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                    produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                    produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                    produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                    produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                    produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);
                }
                else
                {
                    produto = null;
                }
                dr.Close();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível verificar se o produto tem estoque vázio " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar o último produto cadastrado.
        /// </summary>
        /// <returns>Retorna uma variável com os atributos do produto preenchidas.</returns>
        public Produto BuscarPorUltimoProdutoCadastrado()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 * FROM Produto ORDER BY produtoID DESC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                Produto produto = new Produto();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    dr.Read();
                    produto._ProdutoID = (int)dr["produtoID"];
                    produto._Codigo = dr["codigo"].ToString();
                    produto._DataCadastro = dr["dataCadastro"].ToString();
                    produto._ProdutoNome = dr["produtoNome"].ToString();
                    produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                    produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                    produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                    produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                    produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                    produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                    produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                    produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                    produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                    produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                    produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);
                }
                else
                {
                    produto = null;
                }
                dr.Close();
                return produto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar o último produto cadastrado " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>Retorna uma Lista com os atributos do produto preenchidas.</returns>
        public IList<Produto> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto WHERE codigo like @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Produto> listaProduto = new List<Produto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto._ProdutoID = (int)dr["produtoID"];
                        produto._Codigo = dr["codigo"].ToString();
                        produto._DataCadastro = dr["dataCadastro"].ToString();
                        produto._ProdutoNome = dr["produtoNome"].ToString();
                        produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                        produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                        produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                        produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                        produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                        produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                        produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                        produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                        produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaProduto.Add(produto);
                    }
                }
                else
                {
                    listaProduto = null;
                }
                dr.Close();
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse produto pelo código " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um produto pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos do produto preenchidas.</returns>
        public IList<Produto> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto WHERE produtoNome like @produtoNome";

                cmd.Parameters.AddWithValue("@produtoNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Produto> listaProduto = new List<Produto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto._ProdutoID = (int)dr["produtoID"];
                        produto._Codigo = dr["codigo"].ToString();
                        produto._DataCadastro = dr["dataCadastro"].ToString();
                        produto._ProdutoNome = dr["produtoNome"].ToString();
                        produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                        produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                        produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                        produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                        produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                        produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                        produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                        produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                        produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaProduto.Add(produto);
                    }
                }
                else
                {
                    listaProduto = null;
                }
                dr.Close();
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse produto pelo nome " + ex.Message);
            }
        }
                 
        /// <summary>
        /// Método para buscar um produto pelo preço unitário.
        /// </summary>
        /// <param name="produtoPrecoUnitario">Variável com o valor do preço unitário.</param>
        /// <returns>Retorna uma Lista com os atributos do produto preenchidas.</returns>
        public IList<Produto> BuscarPorPrecoUnitario(decimal produtoPrecoUnitario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto WHERE produtoPrecoUnitario = @produtoPrecoUnitario";

                cmd.Parameters.AddWithValue("@produtoPrecoUnitario", produtoPrecoUnitario + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Produto> listaProduto = new List<Produto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto._ProdutoID = (int)dr["produtoID"];
                        produto._Codigo = dr["codigo"].ToString();
                        produto._DataCadastro = dr["dataCadastro"].ToString();
                        produto._ProdutoNome = dr["produtoNome"].ToString();
                        produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                        produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                        produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                        produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                        produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                        produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                        produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                        produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                        produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaProduto.Add(produto);
                    }
                }
                else
                {
                    listaProduto = null;
                }
                dr.Close();
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse produto pelo preço unitário " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Produto";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Produto> listaProduto = new List<Produto>();

                if (dr.HasRows)
                {
                    ContaDAO contaDAO = new ContaDAO();
                    UnidadeDAO unidadeDAO = new UnidadeDAO();

                    while (dr.Read())
                    {
                        Produto produto = new Produto();
                        produto._ProdutoID = (int)dr["produtoID"];
                        produto._Codigo = dr["codigo"].ToString();
                        produto._DataCadastro = dr["dataCadastro"].ToString();
                        produto._ProdutoNome = dr["produtoNome"].ToString();
                        produto._ProdutoPrecoUnitario = (decimal)dr["produtoPrecoUnitario"];
                        produto._ProdutoValorTotal = (decimal)dr["produtoValorTotal"];
                        produto._QuantidadeAtendida = (int)dr["quantidadeAtendida"];
                        produto._QuantidadeSolicitada = (int)dr["quantidadeSolicitada"];
                        produto._QuantidadeEntrada = (int)dr["quantidadeEntrada"];
                        produto._QuantidadeSaida = (int)dr["quantidadeSaida"];
                        produto._QuantidadeEstoque = (int)dr["quantidadeEstoque"];
                        produto._EstoqueValorTotal = (decimal)dr["estoqueValorTotal"];
                        produto._ProdutoTipo = (ProdutoTipo)Enum.Parse(typeof(ProdutoTipo), dr["produtoTipo"].ToString());
                        produto._Conta = contaDAO.BuscarPorID((int)dr["contaID"]);
                        produto._Unidade = unidadeDAO.BuscarPorID((int)dr["unidadeID"]);

                        listaProduto.Add(produto);
                    }
                }
                else
                {
                    listaProduto = null;
                }
                dr.Close();
                return listaProduto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os produtos " + ex.Message);
            }
        }
    }
}
