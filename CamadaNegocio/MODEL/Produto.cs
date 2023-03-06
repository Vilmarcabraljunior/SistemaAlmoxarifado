using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Produto com os atributos e propriedades.
    /// </summary>
    public class Produto
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int produtoID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor do nome do produto.
        /// </summary>
        private string produtoNome;
        /// <summary>
        /// Variável que guarda o valor do preço unitário.
        /// </summary>
        private decimal produtoPrecoUnitario;
        /// <summary>
        /// Variável que guarda o valor do valor total.
        /// </summary>
        private decimal produtoValorTotal;
        /// <summary>
        /// Variável que guarda o valor da quantidade fornecida.
        /// </summary>
        private int quantidadeAtendida;
        /// <summary>
        /// Variável que guarda o valor da quantidade solicitada.
        /// </summary>
        private int quantidadeSolicitada;
        /// <summary>
        /// Variável que guarda o valor da quantidade da entrada.
        /// </summary>
        private int quantidadeEntrada;
        /// <summary>
        /// Variável que guarda o valor da quantidade da saída.
        /// </summary>
        private int quantidadeSaida;
        /// <summary>
        /// Variável que guarda o valor da quantidade em estoque.
        /// </summary>
        private int quantidadeEstoque;
        /// <summary>
        /// Variável que guarda o valor o valor total do estoque.
        /// </summary>
        private decimal estoqueValorTotal;
        /// <summary>
        /// Variável que guarda o valor do tipo do produto.
        /// </summary>
        private ProdutoTipo produtoTipo;

        /// <summary>
        /// Variável do tipo Conta que guarda os atributos da conta.
        /// </summary>
        private Conta conta;
        /// <summary>
        /// Variável do tipo Unidade que guarda os atributos da unidade.
        /// </summary>
        private Unidade unidade;


        /// <summary>
        /// Método construtor 
        /// </summary>
        public Produto()
        {
            conta = new Conta();
            unidade = new Unidade();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Produto()
        {

        }

        /// <summary>
        /// Propriedade da variável produtolID.
        /// </summary>
        public int _ProdutoID
        {
            get
            {
                return produtoID;
            }
            set
            {
                produtoID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável codigo.
        /// </summary>
        public string _Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        /// <summary>
        /// Propriedade da variável dataCadastro.
        /// </summary>
        public string _DataCadastro
        {
            get
            {
                return dataCadastro;
            }
            set
            {
                dataCadastro = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produtoNome.
        /// </summary>
        public string _ProdutoNome
        {
            get
            {
                return produtoNome;
            }
            set
            {
                produtoNome = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produtoPrecoUnitario.
        /// </summary>
        public decimal _ProdutoPrecoUnitario
        {
            get
            {
                return produtoPrecoUnitario;
            }
            set
            {
                produtoPrecoUnitario = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produtoValorTotal.
        /// </summary>
        public decimal _ProdutoValorTotal
        {
            get
            {
                return produtoValorTotal;
            }
            set
            {
                produtoValorTotal = value;
            }
        }

        /// <summary>
        /// Propriedade da variável quantidadeFornecida.
        /// </summary>
        public int _QuantidadeAtendida
        {
            get
            {
                return quantidadeAtendida;
            }
            set
            {
                quantidadeAtendida = value;
            }
        }

        /// <summary>
        /// Propriedade da variável quantidadeSolicitada.
        /// </summary>
        public int _QuantidadeSolicitada
        {
            get
            {
                return quantidadeSolicitada;
            }
            set
            {
                quantidadeSolicitada = value;
            }
        }

        /// <summary>
        /// Propriedade da variável quantidadeEntrada.
        /// </summary>
        public int _QuantidadeEntrada
        {
            get
            {
                return quantidadeEntrada;
            }
            set
            {
                quantidadeEntrada = value;
            }
        }

        /// <summary>
        /// Propriedade da variável quantidadeSaida.
        /// </summary>
        public int _QuantidadeSaida
        {
            get
            {
                return quantidadeSaida;
            }
            set
            {
                quantidadeSaida = value;
            }
        }

        /// <summary>
        /// Propriedade da variável quantidadeEstoque.
        /// </summary>
        public int _QuantidadeEstoque
        {
            get
            {
                return quantidadeEstoque;
            }
            set
            {
                quantidadeEstoque = value;
            }
        }

        /// <summary>
        /// Propriedade da variável estoqueValorTotal.
        /// </summary>
        public decimal _EstoqueValorTotal
        {
            get
            {
                return estoqueValorTotal;
            }
            set
            {
                estoqueValorTotal = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produtoTipo.
        /// </summary>
        public ProdutoTipo _ProdutoTipo
        {
            get
            {
                return produtoTipo;
            }
            set
            {
                produtoTipo = value;
            }
        }

        /// <summary>
        /// Propriedade da variável conta.
        /// </summary>
        public Conta _Conta
        {
            get
            {
                return conta;
            }
            set
            {
                conta = value;
            }
        }

        /// <summary>
        /// Propriedade da variável unidade.
        /// </summary>
        public Unidade _Unidade
        {
            get
            {
                return unidade;
            }
            set
            {
                unidade = value;
            }
        }
    }
}
