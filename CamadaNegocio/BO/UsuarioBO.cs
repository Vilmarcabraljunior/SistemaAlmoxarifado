using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.DAO;

namespace CamadaNegocio.BO
{
    /// <summary>
    /// Classe que faz a validação dos dados do usuário.
    /// </summary>
    public class UsuarioBO
    {
        /// <summary>
        /// Variável do tipo usuário com os atributos para serem preenchidos.
        /// </summary>
        Usuario usuario;
        /// <summary>
        /// Váriavel da classe usuarioDAO para chamar os métodos da classe DAO.
        /// </summary>
        UsuarioDAO usuarioDAO;
        /// <summary>
        /// Variável do tipo Lista para retorna os dados do usuário.
        /// </summary>
        IList<Usuario> listaUsuario;

        /// <summary>
        /// Método que faz a Validação dos Dados do Usuário.
        /// </summary>
        /// <param name="usuario">Atributo do tipo usuário com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(usuario._UsuarioNome))
            {
                throw new Exception("Campo NOME é Obrigatório.");
            }

            else if (usuario._Area._AreaID.Equals(0))
            {
                throw new Exception("Selecione a ÁREA.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um usuário sem que o seu id seja informado.
        /// </summary>
        /// <param name="usuario">Atributo do tipo usuário com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Usuario usuario)
        {
            if (usuario._UsuarioID.Equals(0))
            {
                throw new Exception("Selecione um USUÁRIO para efetuar a Exclusão.");
            }
        }
        /// <summary>
        /// Método que não deixa os campos do login nulos.
        /// </summary>
        /// <param name="cpf">Atributo com o valor do cpf do usuário.</param>
        /// <param name="senha">Atributo com o valor da senha do usuário.</param>
        public void ValidacaoLogin(string cpf, string senha)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                throw new Exception("Campo CPF é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(senha))
            {
                throw new Exception("Campo SENHA é Obrigatório.");
            }
        }

        #endregion

        /// <summary>
        /// Método para Gravar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Usuario usuario)
        {
            try
            {
                ValidacaoSalvar(usuario);

                usuarioDAO = new UsuarioDAO();

                if (usuario._UsuarioID != 0)
                {
                    usuarioDAO.Atualizar(usuario);
                }
                else
                {
                    usuarioDAO.Salvar(usuario);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com o valor do id para fazer a exclusão.</param>
        public void Excluir(Usuario usuario)
        {
            try
            {
                ValidacaoExcluir(usuario);

                usuarioDAO = new UsuarioDAO();
                usuarioDAO.Excluir(usuario);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para redefinir a senha do usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void RedefinirSenha(Usuario usuario)
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.RedefinirSenha(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar a data do último acesso do usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void AtualizarUltimoAcessoData(Usuario usuario)
        {
            try
            {
                usuarioDAO = new UsuarioDAO();
                usuarioDAO.AtualizarUltimoAcessoData(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public Usuario BuscarPorID(int id)
        {
            try
            {
                usuario = new Usuario();
                usuarioDAO = new UsuarioDAO();

                usuario = usuarioDAO.BuscarPorID(id);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método que busca o usuário pelo cpf e senha.
        /// </summary>
        /// <param name="cpf">Atributo com o valor do cpf.</param>
        /// <param name="senha">Atributo com o valor da senha.</param>
        /// <returns>Retorna uma variável com os atributos do usuário preenchidos.</returns>
        public Usuario Logar(string cpf, string senha)
        {
            try
            {
                ValidacaoLogin(cpf, senha);

                usuario = new Usuario();
                usuarioDAO = new UsuarioDAO();

                usuario = usuarioDAO.Logar(cpf, senha);
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele usuário que foi consultado.</returns>
        public IList<Usuario> BuscarPorNome(string nome)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorNome(nome);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome e pelo id da área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="nome">Variável com o nome.</param>
        /// <returns>retorna uma lista com os atributos daquele usuário que foi consultado.</returns>
        public IList<Usuario> BuscarPorNomePorArea(string nome, int areaID)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorNomePorArea(nome, areaID);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo cpf.
        /// </summary>
        /// <param name="cpf">Variável com o cpf.</param>
        /// <returns>retorna uma lista com os atributos daquele usuário que foi consultado.</returns>
        public IList<Usuario> BuscarPorCpf(string cpf)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarPorCpf(cpf);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        /// <summary>
        /// Método para buscar todos os usuários da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários e seus atributos.</returns>
        public IList<Usuario> BuscarTodosUsuarios()
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarTodosUsuarios();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os usuários da base de dados pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todos os usuários e seus atributos.</returns>
        public IList<Usuario> BuscarTodosUsuariosPorArea(int areaID)
        {
            try
            {
                listaUsuario = new List<Usuario>();
                usuarioDAO = new UsuarioDAO();

                listaUsuario = usuarioDAO.BuscarTodosUsuariosPorArea(areaID);
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
