using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe ItemRequisicao com os atributos e propriedades.
    /// </summary>
    public class ItemRequisicao
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int itemRequisicaoID;
        /// <summary>
        /// Variável do tipo Requisicao que guarda os atributos da requisição.
        /// </summary>
        private Requisicao requisicao;
        /// <summary>
        /// Variável do tipo Protudo que guarda os atributos do produto.
        /// </summary>
        private Produto produto;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public ItemRequisicao(Requisicao requisicao)
        {
            this._Requisicao = requisicao;
            produto = new Produto();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~ItemRequisicao()
        {

        }

        /// <summary>
        /// Propriedade da variável itemRequisicaoID.
        /// </summary>
        public int _ItemRequisicaoID
        {
            get
            {
                return itemRequisicaoID;
            }
            set
            {
                itemRequisicaoID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável requisicao.
        /// </summary>
        public Requisicao _Requisicao
        {
            get
            {
                return requisicao;
            }
            set
            {
                requisicao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável produto.
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
