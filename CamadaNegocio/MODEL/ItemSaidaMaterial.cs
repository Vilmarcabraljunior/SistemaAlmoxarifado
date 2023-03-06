using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe ItemSaidaMaterial com os atributos e propriedades.
    /// </summary>
    public class ItemSaidaMaterial
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int itemSaidaMaterialID;
        /// <summary>
        /// Variável do tipo SaidaMaterial que guarda os atributos da saida de material.
        /// </summary>
        private SaidaMaterial saidaMaterial;
        /// <summary>
        /// Variável do tipo Protudo que guarda os atributos do produto.
        /// </summary>
        private Produto produto;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public ItemSaidaMaterial(SaidaMaterial saidaMaterial)
        {
            this._SaidaMaterial = saidaMaterial;
            produto = new Produto();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~ItemSaidaMaterial()
        {

        }

        /// <summary>
        /// Propriedade da variável itemSaidaMaterialID.
        /// </summary>
        public int _ItemSaidaMaterialID
        {
            get
            {
                return itemSaidaMaterialID;
            }
            set
            {
                itemSaidaMaterialID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável saidaMaterial.
        /// </summary>
        public SaidaMaterial _SaidaMaterial
        {
            get
            {
                return saidaMaterial;
            }
            set
            {
                saidaMaterial = value;
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
