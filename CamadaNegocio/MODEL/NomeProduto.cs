using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe NomeProduto com os atributos e propriedades.
    /// </summary>
    public class NomeProduto
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int nomeProdutoID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da  data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da nome do produto.
        /// </summary>
        private string produtoNome;
        /// <summary>
        /// Variável que guarda o valor do preço unitário.
        /// </summary>
        private decimal produtoPrecoUnitario;


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
        public NomeProduto()
        {
            conta = new Conta();
            unidade = new Unidade();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~NomeProduto()
        {
            
        }

        /// <summary>
        /// Propriedade da variável nomeProdutoID.
        /// </summary>
        public int _NomeProdutoID
        {
            get
            {
                return nomeProdutoID;
            }
            set
            {
                nomeProdutoID = value;
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
