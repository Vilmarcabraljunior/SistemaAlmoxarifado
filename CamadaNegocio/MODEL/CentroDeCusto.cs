using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe CentroDeCusto com os atributos e propriedades.
    /// </summary>
    public class CentroDeCusto
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int centroDeCustoID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da descrição.
        /// </summary>
        private string descricao;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~CentroDeCusto()
        {

        }

        /// <summary>
        /// Propriedade da variável CentroDeCustoID.
        /// </summary>
        public int _CentroDeCustoID
        {
            get
            {
                return centroDeCustoID;
            }
            set
            {
                centroDeCustoID = value;
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
        /// Propriedade da variável datacadastro.
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
        /// Propriedade da variável descricao.
        /// </summary>
        public string _Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }
    }
}
