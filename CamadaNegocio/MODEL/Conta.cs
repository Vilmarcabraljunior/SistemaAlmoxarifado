using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Conta com os atributos e propriedades.
    /// </summary>
    public class Conta
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int contaID;
        /// <summary>
        /// Variável que guarda o valor da descrição da conta.
        /// </summary>
        private string contaDescricao;
        /// <summary>
        /// Variável que guarda o valor do número da conta.
        /// </summary>
        private string contaNumero;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da função da conta.
        /// </summary>
        private string contaFuncao;
        /// <summary>
        /// Variável que guarda o valor do tipo da conta.
        /// </summary>
        private TipoConta tipoConta;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Conta()
        {

        }

        /// <summary>
        /// Propriedade da variável contaID.
        /// </summary>
        public int _ContaID
        {
            get
            {
                return contaID;
            }
            set
            {
                contaID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável contaDescricao.
        /// </summary>
        public string _ContaDescricao
        {
            get
            {
                return contaDescricao;
            }
            set
            {
                contaDescricao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável contaNumero.
        /// </summary>
        public string _ContaNumero
        {
            get
            {
                return contaNumero;
            }
            set
            {
                contaNumero = value;
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
        /// Propriedade da variável contaFuncao.
        /// </summary>
        public string _ContaFuncao
        {
            get
            {
                return contaFuncao;
            }
            set
            {
                contaFuncao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável tipoConta.
        /// </summary>
        public TipoConta _TipoConta
        {
            get
            {
                return tipoConta;
            }
            set
            {
                tipoConta = value;
            }
        }
    }
}
