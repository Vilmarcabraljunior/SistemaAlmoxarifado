using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Estoque com os atributos e propriedades.
    /// </summary>
    public class Licitacao
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int licitacaoID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da observação.
        /// </summary>
        private string observacao;
                                    

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Licitacao()
        {

        }

        /// <summary>
        /// Propriedade da variável EstoqueID.
        /// </summary>
        public int _LicitacaoID
        {
            get
            {
                return licitacaoID;
            }
            set
            {
                licitacaoID = value;
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
        /// Propriedade da variável observacao.
        /// </summary>
        public string _Observacao
        {
            get
            {
                return observacao;
            }
            set
            {
                observacao = value;
            }
        }
                
    }
}
