using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe ItemEntradaMaterial com os atributos e propriedades.
    /// </summary>
    public class ItemEntradaMaterial
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int itemEntradaMaterialID;
        /// <summary>
        /// Variável do tipo EntradaMaterial que guarda os atributos da entrada de material.
        /// </summary>
        private EntradaMaterial entradaMaterial;
        /// <summary>
        /// Variável do tipo Protudo que guarda os atributos do produto.
        /// </summary>
        private Produto produto;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public ItemEntradaMaterial(EntradaMaterial entradaMaterial)
        {
            this._EntradaMaterial = entradaMaterial;
            produto = new Produto();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~ItemEntradaMaterial()
        {

        }

        /// <summary>
        /// Propriedade da variável FornecedorID.
        /// </summary>
        public int _ItemEntradaMaterialID
        {
            get
            {
                return itemEntradaMaterialID;
            }
            set
            {
                itemEntradaMaterialID = value;
            }
        }

        /// <summary>
        /// Propriedade da variável entradaMaterial.
        /// </summary>
        public EntradaMaterial _EntradaMaterial
        {
            get
            {
                return entradaMaterial;
            }
            set
            {
                entradaMaterial = value;
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
