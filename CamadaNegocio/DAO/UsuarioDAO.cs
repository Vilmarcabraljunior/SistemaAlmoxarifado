using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.DAO
{
    /// <summary>
    /// Classe com os comandos CRUD do usuário.
    /// </summary>
    public class UsuarioDAO
    {
        /// <summary>
        /// Método para Gravar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Usuario (dataCadastro, ultimoAcessoData, usuarioCpf, usuarioNome, usuarioSenha, usuarioNivelAcesso, areaID)" +
                    " values(@dataCadastro, @ultimoAcessoData, @usuarioCpf, @usuarioNome, @usuarioSenha, @usuarioNivelAcesso, @areaID)";

                cmd.Parameters.AddWithValue("@dataCadastro", usuario._DataCadastro);
                cmd.Parameters.AddWithValue("@ultimoAcessoData", usuario._UltimoAcessoData);
                cmd.Parameters.AddWithValue("@usuarioCpf", usuario._UsuarioCpf);
                cmd.Parameters.AddWithValue("@usuarioNome", usuario._UsuarioNome);
                cmd.Parameters.AddWithValue("@usuarioSenha", usuario._UsuarioSenha);
                cmd.Parameters.AddWithValue("@usuarioNivelAcesso", usuario._UsuarioNivelAcesso);
                cmd.Parameters.AddWithValue("@areaID", usuario._Area._AreaID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse usuário " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um usuário.
        /// </summary>
        /// <param name="usuario">Variável do tipo usuário com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Usuario usuario)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuario SET dataCadastro=@dataCadastro, ultimoAcessoData=@ultimoAcessoData, usuarioCpf=@usuarioCpf," +
                    " usuarioNome=@usuarioNome, usuarioSenha=@usuarioSenha, usuarioNivelAcesso=@usuarioNivelAcesso, areaID=@areaID WHERE usuarioID=@usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@dataCadastro", usuario._DataCadastro);
                cmd.Parameters.AddWithValue("@ultimoAcessoData", usuario._UltimoAcessoData);
                cmd.Parameters.AddWithValue("@usuarioCpf", usuario._UsuarioCpf);
                cmd.Parameters.AddWithValue("@usuarioNome", usuario._UsuarioNome);
                cmd.Parameters.AddWithValue("@usuarioSenha", usuario._UsuarioSenha);
                cmd.Parameters.AddWithValue("@usuarioNivelAcesso", usuario._UsuarioNivelAcesso);
                cmd.Parameters.AddWithValue("@areaID", usuario._Area._AreaID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse usuário " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Usuario WHERE usuarioID = @UsuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse usuário " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuario SET usuarioSenha=@usuarioSenha WHERE usuarioID=@usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@usuarioSenha", usuario._UsuarioSenha);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível redefinir a senha do usuário." + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Usuario SET ultimoAcessoData=@ultimoAcessoData WHERE usuarioID=@usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@ultimoAcessoData", usuario._UltimoAcessoData);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar a data do último acesso do usuário." + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Usuario usuario = new Usuario();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    dr.Read();
                    usuario._UsuarioID = (int)dr["usuarioID"];
                    usuario._DataCadastro = dr["dataCadastro"].ToString();
                    usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                    usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                    usuario._UsuarioNome = dr["usuarioNome"].ToString();
                    usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                    usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                    usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);
                }
                else
                {
                    usuario = null;
                }
                dr.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse nível de acesso do usuário pelo id " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuarioCpf = @usuarioCpf and usuarioSenha = @usuarioSenha";

                cmd.Parameters.AddWithValue("@usuarioCpf", cpf);
                cmd.Parameters.AddWithValue("@usuarioSenha", senha);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Usuario usuario = new Usuario();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    dr.Read();
                    usuario._UsuarioID = (int)dr["usuarioID"];
                    usuario._DataCadastro = dr["dataCadastro"].ToString();
                    usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                    usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                    usuario._UsuarioNome = dr["usuarioNome"].ToString();
                    usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                    usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                    usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);
                }
                else
                {
                    usuario = null;
                }
                dr.Close();
                return usuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível logar. " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos do usuário preenchidas.</returns>
        public IList<Usuario> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuarioNome like @usuarioNome";

                cmd.Parameters.AddWithValue("@usuarioNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._DataCadastro = dr["dataCadastro"].ToString();
                        usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                        usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                        usuario._UsuarioNome = dr["usuarioNome"].ToString();
                        usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                        usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                        usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo nome  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo nome e pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="nome">Variável com o valor do nome do usuário.</param>
        /// <returns>Retorna uma Lista com os atributos do usuário preenchidas.</returns>
        public IList<Usuario> BuscarPorNomePorArea(string nome, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE areaID = @areaID and usuarioNome like @usuarioNome";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@usuarioNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._DataCadastro = dr["dataCadastro"].ToString();
                        usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                        usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                        usuario._UsuarioNome = dr["usuarioNome"].ToString();
                        usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                        usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                        usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo nome pela área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um usuário pelo cpf.
        /// </summary>
        /// <param name="cpf">Variável com o valor do cpf.</param>
        /// <returns>Retorna uma Lista com os atributos do usuário preenchidos.</returns>
        public IList<Usuario> BuscarPorCpf(string cpf)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE usuarioCpf like @usuarioCpf";

                cmd.Parameters.AddWithValue("@usuarioCpf", cpf + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._DataCadastro = dr["dataCadastro"].ToString();
                        usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                        usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                        usuario._UsuarioNome = dr["usuarioNome"].ToString();
                        usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                        usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                        usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse usuário pelo cpf  " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._DataCadastro = dr["dataCadastro"].ToString();
                        usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                        usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                        usuario._UsuarioNome = dr["usuarioNome"].ToString();
                        usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                        usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                        usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os usuários " + ex.Message);
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
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Usuario WHERE areaID = @areaID";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Usuario> listaUsuario = new List<Usuario>();

                if (dr.HasRows)
                {
                    AreaDAO areaDAO = new AreaDAO();

                    while (dr.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario._UsuarioID = (int)dr["usuarioID"];
                        usuario._DataCadastro = dr["dataCadastro"].ToString();
                        usuario._UltimoAcessoData = dr["ultimoAcessoData"].ToString();
                        usuario._UsuarioCpf = dr["usuarioCpf"].ToString();
                        usuario._UsuarioNome = dr["usuarioNome"].ToString();
                        usuario._UsuarioSenha = dr["usuarioSenha"].ToString();
                        usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), dr["usuarioNivelAcesso"].ToString());
                        usuario._Area = areaDAO.BuscarPorID((int)dr["areaID"]);

                        listaUsuario.Add(usuario);
                    }
                }
                else
                {
                    listaUsuario = null;
                }
                dr.Close();
                return listaUsuario;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os usuários pela área do usuário " + ex.Message);
            }
        }
    }
}
