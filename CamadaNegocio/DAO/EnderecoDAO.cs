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
    /// Classe com os comandos CRUD do endereço.
    /// </summary>
    public class EnderecoDAO
    {
        /// <summary>
        /// Método para Gravar um endereço.
        /// </summary>
        /// <param name="endereco">Variável do tipo endereço com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Endereco endereco)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Endereco (codigo, dataCadastro, enderecoDescricao) values(@codigo, @dataCadastro, @enderecoDescricao)";

                cmd.Parameters.AddWithValue("@codigo", endereco._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", endereco._DataCadastro);
                cmd.Parameters.AddWithValue("@enderecoDescricao", endereco._EnderecoDescricao);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse endereço " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um endereço.
        /// </summary>
        /// <param name="endereco">Variável do tipo endereço com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Endereco endereco)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Endereco SET codigo=@codigo, dataCadastro=@dataCadastro, enderecoDescricao=@enderecoDescricao" +
                    " WHERE enderecoID=@enderecoID";


                cmd.Parameters.AddWithValue("@enderecoID", endereco._EnderecoID);
                cmd.Parameters.AddWithValue("@codigo", endereco._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", endereco._DataCadastro);
                cmd.Parameters.AddWithValue("@enderecoDescricao", endereco._EnderecoDescricao);


                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse endereço " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um endereço.
        /// </summary>
        /// <param name="endereco">Variável do tipo endereço com o valor do id para fazer a exclusão.</param>
        public void Excluir(Endereco endereco)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Endereco WHERE enderecoID = @enderecoID";

                cmd.Parameters.AddWithValue("@enderecoID", endereco._EnderecoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse endereço " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um endereço pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do endereço preenchidas.</returns>
        public Endereco BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Endereco WHERE enderecoID = @enderecoID";

                cmd.Parameters.AddWithValue("@enderecoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Endereco endereco = new Endereco();

                if (dr.HasRows)
                {
                    dr.Read();
                    endereco._EnderecoID = (int)dr["enderecoID"];
                    endereco._Codigo = dr["codigo"].ToString();
                    endereco._DataCadastro = dr["dataCadastro"].ToString();
                    endereco._EnderecoDescricao = dr["enderecoDescricao"].ToString();
                }
                else
                {
                    endereco = null;
                }
                dr.Close();
                return endereco;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse endereço pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um endereço pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>Retorna uma Lista com os atributos do endereço preenchidas.</returns>
        public IList<Endereco> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Endereco WHERE codigo like @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Endereco> listaEndereco = new List<Endereco>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Endereco endereco = new Endereco();
                        endereco._EnderecoID = (int)dr["enderecoID"];
                        endereco._Codigo = dr["codigo"].ToString();
                        endereco._DataCadastro = dr["dataCadastro"].ToString();
                        endereco._EnderecoDescricao = dr["enderecoDescricao"].ToString();

                        listaEndereco.Add(endereco);
                    }
                }
                else
                {
                    listaEndereco = null;
                }
                dr.Close();
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse endereço pelo código  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um endereço pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com o valor da descrição.</param>
        /// <returns>Retorna uma Lista com os atributos do endereço preenchidas.</returns>
        public IList<Endereco> BuscarPorDescricao(string descricao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Endereco WHERE enderecoDescricao like @enderecoDescricao";

                cmd.Parameters.AddWithValue("@enderecoDescricao", descricao + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Endereco> listaEndereco = new List<Endereco>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Endereco endereco = new Endereco();
                        endereco._EnderecoID = (int)dr["enderecoID"];
                        endereco._Codigo = dr["codigo"].ToString();
                        endereco._DataCadastro = dr["dataCadastro"].ToString();
                        endereco._EnderecoDescricao = dr["enderecoDescricao"].ToString();

                        listaEndereco.Add(endereco);
                    }
                }
                else
                {
                    listaEndereco = null;
                }
                dr.Close();
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse endereço pela descrição " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os endereços da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os endereços e seus atributos.</returns>
        public IList<Endereco> BuscarTodosEnderecos()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Endereco ORDER BY enderecoDescricao ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Endereco> listaEndereco = new List<Endereco>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Endereco endereco = new Endereco();
                        endereco._EnderecoID = (int)dr["enderecoID"];
                        endereco._Codigo = dr["codigo"].ToString();
                        endereco._DataCadastro = dr["dataCadastro"].ToString();
                        endereco._EnderecoDescricao = dr["enderecoDescricao"].ToString();

                        listaEndereco.Add(endereco);
                    }
                }
                else
                {
                    listaEndereco = null;
                }
                dr.Close();
                return listaEndereco;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os endereços " + ex.Message);
            }
        }
    }
}
