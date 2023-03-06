using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Processo com os atributos e propriedades.
    /// </summary>
    public class Processo
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int processoID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da data do processo.
        /// </summary>
        private string processoData;
        /// <summary>
        /// Variável que guarda o valor do número do processo.
        /// </summary>
        private string processoNumero;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Processo()
        {

        }

        /// <summary>
        /// Propriedade da variável processoID.
        /// </summary>
        public int _ProcessoID
        {
            get
            {
                return processoID;
            }
            set
            {
                processoID = value;
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
        /// Propriedade da variável processoData.
        /// </summary>
        public string _ProcessoData
        {
            get
            {
                return processoData;
            }
            set
            {
                processoData = value;
            }
        }

        /// <summary>
        /// Propriedade da variável processoNumero.
        /// </summary>
        public string _ProcessoNumero
        {
            get
            {
                return processoNumero;
            }
            set
            {
                processoNumero = value;
            }
        }
    }
}
