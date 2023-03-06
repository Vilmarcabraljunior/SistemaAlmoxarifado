using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Entradamaterial com os atributos e propriedades.
    /// </summary>
    public class EntradaMaterial
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int entradaMaterialID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da hora do cadastro.
        /// </summary>
        private string horaCadastro;
        /// <summary>
        /// Variável que guarda o valor da observação.
        /// </summary>
        private string observacao;

        /// <summary>
        /// Variável do tipo Fornecedor que guarda os atributos do fornecedor.
        /// </summary>
        private Fornecedor fornecedor;
        /// <summary>
        /// Variável do tipo Usuario que guarda os atributos do usuario.
        /// </summary>
        private Usuario usuario;
        /// <summary>
        /// Variável do tipo processo que guarda os atributos do processo.
        /// </summary>
        private Processo processo;
        /// <summary>
        /// Variável do tipo ItemEntradaMaterial que guarda o valor dos itens da entrada de material.
        /// </summary>
        IList<ItemEntradaMaterial> listaItemEntradaMaterial;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public EntradaMaterial()
        {
            fornecedor = new Fornecedor();
            usuario = new Usuario();
            processo = new Processo();
            listaItemEntradaMaterial = new List<ItemEntradaMaterial>();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~EntradaMaterial()
        {

        }

        /// <summary>
        /// Propriedade da variável EntradaMaterialID.
        /// </summary>
        public int _EntradaMaterialID
        {
            get
            {
                return entradaMaterialID;
            }
            set
            {
                entradaMaterialID = value;
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
        /// Propriedade da variável horaCadastro.
        /// </summary>
        public string _HoraCadastro
        {
            get
            {
                return horaCadastro;
            }
            set
            {
                horaCadastro = value;
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

        /// <summary>
        /// Propriedade da variável fornecedor.
        /// </summary>
        public Fornecedor _Fornecedor
        {
            get
            {
                return fornecedor;
            }
            set
            {
                fornecedor = value;
            }
        }

        /// <summary>
        /// Propriedade da variável usuario.
        /// </summary>
        public Usuario _Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
            }
        }
        
        /// <summary>
        /// Propriedade da variável processo.
        /// </summary>
        public Processo _Processo
        {
            get
            {
                return processo;
            }
            set
            {
                processo = value;
            }
        }

        /// <summary>
        /// Propriedade da variável listaItemEntradaMaterial.
        /// </summary>
        public IList<ItemEntradaMaterial> _ListaItemEntradaMaterial
        {
            get
            {
                return listaItemEntradaMaterial;
            }
            set
            {
                listaItemEntradaMaterial = value;
            }
        }
    }
}
