using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Situacao com os atributos e propriedades.
    /// </summary>
    public class Situacao
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int situacaoID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor do nome da situação.
        /// </summary>
        private string situacaoNome;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Situacao()
        {

        }

        /// <summary>
        /// Propriedade da variável situacaoID.
        /// </summary>
        public int _SituacaoID
        {
            get
            {
                return situacaoID;
            }
            set
            {
                situacaoID = value;
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
        /// Propriedade da variável situacaoNome.
        /// </summary>
        public string _SituacaoNome
        {
            get
            {
                return situacaoNome;
            }
            set
            {
                situacaoNome = value;
            }
        }
    }
}
