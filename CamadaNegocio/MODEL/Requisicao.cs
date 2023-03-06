using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Requisicao com os atributos e propriedades.
    /// </summary>
    public class Requisicao
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int requisicaoID;
        /// <summary>
        /// Variável que guarda o valor do codigo.
        /// </summary>
        private string codigo;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da hora do cadastro.
        /// </summary>
        private string horaCadastro;
        /// <summary>
        /// Variável que guarda o valor da observação da requisição.
        /// </summary>
        private string requisicaoObservacao;

        /// <summary>
        /// Variável do tipo Endereco que guarda os atributos do endereço.
        /// </summary>
        private Endereco endereco;
        /// <summary>
        /// Variável do tipo Usuario que guarda os atributos do usuário.
        /// </summary>
        private Usuario usuario;
        /// <summary>
        /// Variável do tipo Requisitante que guarda os atributos do requisitante.
        /// </summary>
        private Requisitante requisitante;
        /// <summary>
        /// Variável do tipo Situacao que guarda os atributos da situação.
        /// </summary>
        private Situacao situacao;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public Requisicao()
        {
            endereco = new Endereco();
            usuario = new Usuario();
            requisitante = new Requisitante();
            situacao = new Situacao();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Requisicao()
        {

        }

        /// <summary>
        /// Propriedade da variável requisicaolID.
        /// </summary>
        public int _RequisicaoID
        {
            get
            {
                return requisicaoID;
            }
            set
            {
                requisicaoID = value;
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
        /// Propriedade da variável requisicaoObservacao.
        /// </summary>
        public string _RequisicaoObservacao
        {
            get
            {
                return requisicaoObservacao;
            }
            set
            {
                requisicaoObservacao = value;
            }
        }

        /// <summary>
        /// Propriedade da variável endereco.
        /// </summary>
        public Endereco _Endereco
        {
            get
            {
                return endereco;
            }
            set
            {
                endereco = value;
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
        /// Propriedade da variável situacao.
        /// </summary>
        public Situacao _Situacao
        {
            get
            {
                return situacao;
            }
            set
            {
                situacao = value;
            }
        }
    }
}
