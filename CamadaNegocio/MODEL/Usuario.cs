using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadaNegocio.MODEL
{
    /// <summary>
    /// Classe Usuario com os atributos e propriedades.
    /// </summary>
    public class Usuario
    {
        /// <summary>
        /// Variável que guarda o valor da chave primária.
        /// </summary>
        private int usuarioID;
        /// <summary>
        /// Variável que guarda o valor da data do cadastro.
        /// </summary>
        private string dataCadastro;
        /// <summary>
        /// Variável que guarda o valor da ultima data do acesso do usuário.
        /// </summary>
        private string ultimoAcessoData;
        /// <summary>
        /// Variável que guarda o valor do cpf do usuário.
        /// </summary>
        private string usuarioCpf;
        /// <summary>
        /// Variável que guarda o valor do nome do usuário.
        /// </summary>
        private string usuarioNome;
        /// <summary>
        /// Variável que guarda o valor da senha do usuário.
        /// </summary>
        private string usuarioSenha;
        /// <summary>
        /// Variável do tipo UsuarioNivelAcesso que guarda os atributos do usuario nivel acesso.
        /// </summary>
        private UsuarioNivelAcesso usuarioNivelAcesso;
        /// <summary>
        /// Variável do tipo Area que guarda os atributos da área.
        /// </summary>
        private Area area;

        /// <summary>
        /// Método construtor 
        /// </summary>
        public Usuario()
        {
            area = new Area();
        }

        /// <summary>
        /// Método destrutor 
        /// </summary>
        ~Usuario()
        {

        }

        /// <summary>
        /// Propriedade da variável usuarioID.
        /// </summary>
        public int _UsuarioID
        {
            get
            {
                return usuarioID;
            }
            set
            {
                usuarioID = value;
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
        /// Propriedade da variável ultimoAcessodata.
        /// </summary>
        public string _UltimoAcessoData
        {
            get
            {
                return ultimoAcessoData;
            }
            set
            {
                ultimoAcessoData = value;
            }
        }

        /// <summary>
        /// Propriedade da variável usuarioCpf.
        /// </summary>
        public string _UsuarioCpf
        {
            get
            {
                return usuarioCpf;
            }
            set
            {
                usuarioCpf = value;
            }
        }

        /// <summary>
        /// Propriedade da variável usuarioNome.
        /// </summary>
        public string _UsuarioNome
        {
            get
            {
                return usuarioNome;
            }
            set
            {
                usuarioNome = value;
            }
        }

        /// <summary>
        /// Propriedade da variável usuarioSenha.
        /// </summary>
        public string _UsuarioSenha
        {
            get
            {
                return usuarioSenha;
            }
            set
            {
                usuarioSenha = value;
            }
        }

        /// <summary>
        /// Propriedade da variável usuarioNivelAcesso.
        /// </summary>
        public UsuarioNivelAcesso _UsuarioNivelAcesso
        {
            get
            {
                return usuarioNivelAcesso;
            }
            set
            {
                usuarioNivelAcesso = value;
            }
        }

        /// <summary>
        /// Propriedade da variável area.
        /// </summary>
        public Area _Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }
    }
}
