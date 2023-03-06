using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Endereco com os atributos e propriedades.
    /// </summary>
    public class Endereco
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int enderecoID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da descrição do endereço.
        /// </summary>
        private string enderecoDescricao;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Endereco()
        {

        }

        /// <summary>
        /// Propriedade da variável EnderecoID.
        /// </summary>
        public int _EnderecoID
        {
            get
            {
                return enderecoID;
            }
            set
            {
                enderecoID = value;
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
        /// Propriedade da variável enderecoDescricao.
        /// </summary>
        public string _EnderecoDescricao
        {
            get
            {
                return enderecoDescricao;
            }
            set
            {
                enderecoDescricao = value;
            }
        }
    }
}
