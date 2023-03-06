using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Area com os atributos e propriedades.
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int areaID;
        /// <summary>
        /// Variável que guarda o valor do nome.
        /// </summary>
        private string areaNome;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Area()
        {

        }

        /// <summary>
        /// Propriedade da variável AreaID.
        /// </summary>
        public int _AreaID
        {
            get
            {
                return areaID;
            }
            set
            {
                areaID = value;
            }
        }

        /// <summary>
        /// Variável que guarda o valor do nome.
        /// </summary>
        public string _AreaNome
        {
            get
            {
                return areaNome;
            }
            set
            {
                areaNome = value;
            }
        }

        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
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
    }
}
