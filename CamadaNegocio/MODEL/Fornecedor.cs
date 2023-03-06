using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Fornecedor com os atributos e propriedades.
    /// </summary>
    public class Fornecedor
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int fornecedorID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor do nome do fornecedor.
        /// </summary>
        private string fornecedorNome;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Fornecedor()
        {

        }

        /// <summary>
        /// Propriedade da variável FornecedorID.
        /// </summary>
        public int _FornecedorID
        {
            get
            {
                return fornecedorID;
            }
            set
            {
                fornecedorID = value;
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
        /// Propriedade da variável fornecedorNome.
        /// </summary>
        public string _FornecedorNome
        {
            get
            {
                return fornecedorNome;
            }
            set
            {
                fornecedorNome = value;
            }
        }
    }
}
