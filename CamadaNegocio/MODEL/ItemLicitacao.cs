using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe ItemEstoque com os atributos e propriedades.
    /// </summary>
    public class ItemLicitacao
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int itemLicitacaoID;
        /// <summary>
        /// Variável do tipo Licitacao que guarda os atributos do estoque.
        /// </summary>
        private Licitacao licitacao;
        /// <summary>
        /// Variável do tipo Protudo que guarda os atributos do produto.
        /// </summary>
        private Produto produto;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public ItemLicitacao(Licitacao licitacao)
        {
            this._Licitacao = licitacao;
            produto = new Produto();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~ItemLicitacao()
        {

        }

        /// <summary>
        /// Propriedade da variável itemLicitacaoID.
        /// </summary>
        public int _ItemLicitacaoID
        {
            get
            {
                return itemLicitacaoID;
            }
            set
            {
                itemLicitacaoID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável licitacao.
        /// </summary>
        public Licitacao _Licitacao
        {
            get
            {
                return licitacao;
            }
            set
            {
                licitacao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produro.
        /// </summary>
        public Produto _Produto
        {
            get
            {
                return produto;
            }
            set
            {
                produto = value;
            }
        }
    }
}
