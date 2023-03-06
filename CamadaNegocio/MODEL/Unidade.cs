using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Unidade com os atributos e propriedades.
    /// </summary>
    public class Unidade
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int unidadeID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da descrição da unidade.
        /// </summary>
        private string unidadeDescricao;

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Unidade()
        {

        }

        /// <summary>
        /// Propriedade da variável unidadeID.
        /// </summary>
        public int _UnidadeID
        {
            get
            {
                return unidadeID;
            }
            set
            {
                unidadeID = value;
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
        /// Propriedade da variável unidadeDescricao.
        /// </summary>
        public string _UnidadeDescricao
        {
            get
            {
                return unidadeDescricao;
            }
            set
            {
                unidadeDescricao = value;
            }
        }
    }
}
