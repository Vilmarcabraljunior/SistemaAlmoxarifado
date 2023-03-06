using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Requisitante com os atributos e propriedades.
    /// </summary>
    public class Requisitante
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int requisitanteID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor do nome do requisitante.
        /// </summary>
        private string requisitanteNome;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Requisitante()
        {

        }

        /// <summary>
        /// Propriedade da variável requisitanteID.
        /// </summary>
        public int _RequisitanteID
        {
            get
            {
                return requisitanteID;
            }
            set
            {
                requisitanteID = value;
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
        /// Propriedade da variável requisitanteNome.
        /// </summary>
        public string _RequisitanteNome
        {
            get
            {
                return requisitanteNome;
            }
            set
            {
                requisitanteNome = value;
            }
        }
    }
}
