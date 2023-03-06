using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe SaidaMaterial com os atributos e propriedades.
    /// </summary>
    public class SaidaMaterial
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int saidaMaterialID;
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
        /// Variável do tipo Usuario que guarda os atributos do usuário.
        /// </summary>
        private Usuario usuario;
        /// <summary>
        /// Variável do tipo Requisitante que guarda os atributos do requisitante.
        /// </summary>
        private Requisitante requisitante;
        /// <summary>
        /// Variável do tipo CentroDeCusto que guarda os atributos do centro de custo.
        /// </summary>
        private CentroDeCusto centroDeCusto;
        /// <summary>
        /// Variável do tipo ItemSaidaMaterial que guarda os atributos do item da saída de material.
        /// </summary>
        IList<ItemSaidaMaterial> listaItemSaidaMaterial;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public SaidaMaterial()
        {
            usuario = new Usuario();
            requisitante = new Requisitante();
            centroDeCusto = new CentroDeCusto();
            listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~SaidaMaterial()
        {

        }

        /// <summary>
        /// Propriedade da variável saidaMateriallID.
        /// </summary>
        public int _SaidaMaterialID
        {
            get
            {
                return saidaMaterialID;
            }
            set
            {
                saidaMaterialID = value;
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
        /// Propriedade da variável requisitante.
        /// </summary>
        public Requisitante _Requisitante
        {
            get
            {
                return requisitante;
            }
            set
            {
                requisitante = value;
            }
        }
        
        /// <summary>
        /// Propriedade da variável centroDeCusto.
        /// </summary>
        public CentroDeCusto _CentroDeCusto
        {
            get
            {
                return centroDeCusto;
            }
            set
            {
                centroDeCusto = value;
            }
        }

        /// <summary>
        /// Propriedade da variável listaItemSaidaMaterial.
        /// </summary>
        public IList<ItemSaidaMaterial> _ListaItemSaidaMaterial
        {
            get
            {
                return listaItemSaidaMaterial;
            }
            set
            {
                listaItemSaidaMaterial = value;
            }
        }
    }
}
