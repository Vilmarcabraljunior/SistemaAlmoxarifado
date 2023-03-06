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
    /// Classe com os comandos CRUD do fornecedor.
    /// </summary>
    public class FornecedorDAO
    {
        /// <summary>
        /// Método para Gravar um fornecedor.
        /// </summary>
        /// <param name="fornecedor">Variável do tipo fornecedor com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Fornecedor fornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Fornecedor(dataCadastro, fornecedorNome) values(@dataCadastro, @fornecedorNome)";

                cmd.Parameters.AddWithValue("@dataCadastro", fornecedor._DataCadastro);
                cmd.Parameters.AddWithValue("@fornecedorNome", fornecedor._FornecedorNome);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse fornecedor " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um fornecedor.
        /// </summary>
        /// <param name="fornecedor">Variável do tipo fornecedor com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Fornecedor fornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Fornecedor SET dataCadastro=@dataCadastro, fornecedorNome=@fornecedorNome WHERE fornecedorID=@fornecedorID";

                cmd.Parameters.AddWithValue("@fornecedorID", fornecedor._FornecedorID);
                cmd.Parameters.AddWithValue("@dataCadastro", fornecedor._DataCadastro);
                cmd.Parameters.AddWithValue("@fornecedorNome", fornecedor._FornecedorNome);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse fornecedor" + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um fornecedor.
        /// </summary>
        /// <param name="fornecedor">Variável do tipo fornecedor com o valor do id para fazer a exclusão.</param>
        public void Excluir(Fornecedor fornecedor)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Fornecedor WHERE fornecedorID = @fornecedorID";

                cmd.Parameters.AddWithValue("@fornecedorID", fornecedor._FornecedorID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse fornecedor " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um fornecedor pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do fornecedor preenchidas.</returns>
        public Fornecedor BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Fornecedor WHERE fornecedorID = @fornecedorID";

                cmd.Parameters.AddWithValue("@fornecedorID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Fornecedor fornecedor = new Fornecedor();

                if (dr.HasRows)
                {
                    dr.Read();
                    fornecedor._FornecedorID = (int)dr["fornecedorID"];
                    fornecedor._DataCadastro = dr["dataCadastro"].ToString();
                    fornecedor._FornecedorNome = dr["fornecedorNome"].ToString();
                }
                else
                {
                    fornecedor = null;
                }
                dr.Close();
                return fornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse fornecedor pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pelo cnpj.
        /// </summary>
        /// <param name="fornecedor">Variável com o valor do cnpj.</param>
        /// <returns>Retorna uma Lista com os atributos do fornecedor preenchidas.</returns>
        public IList<Fornecedor> BuscarPorCnpj(string cnpj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Fornecedor WHERE cnpj like @cnpj";

                cmd.Parameters.AddWithValue("@cnpj", cnpj + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor._FornecedorID = (int)dr["fornecedorID"];
                        fornecedor._DataCadastro = dr["dataCadastro"].ToString();
                        fornecedor._FornecedorNome = dr["fornecedorNome"].ToString();

                        listaFornecedor.Add(fornecedor);
                    }
                }
                else
                {
                    listaFornecedor = null;
                }
                dr.Close();
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse fornecedor pelo cnpj  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos do fornecedor preenchidas.</returns>
        public IList<Fornecedor> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Fornecedor WHERE fornecedorNome like @fornecedorNome";

                cmd.Parameters.AddWithValue("@fornecedorNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor._FornecedorID = (int)dr["fornecedorID"];
                        fornecedor._DataCadastro = dr["dataCadastro"].ToString();
                        fornecedor._FornecedorNome = dr["fornecedorNome"].ToString();

                        listaFornecedor.Add(fornecedor);
                    }
                }
                else
                {
                    listaFornecedor = null;
                }
                dr.Close();
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse fornecedor pelo nome  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um fornecedor pela razão social.
        /// </summary>
        /// <param name="razaoSocial">Variável com o valor da razão social.</param>
        /// <returns>Retorna uma Lista com os atributos da fornecedor preenchidas.</returns>
        public IList<Fornecedor> BuscarPorRazaoSocial(string razaoSocial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Fornecedor WHERE razaoSocial like @razaoSocial";

                cmd.Parameters.AddWithValue("@razaoSocial", razaoSocial + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor._FornecedorID = (int)dr["fornecedorID"];
                        fornecedor._DataCadastro = dr["dataCadastro"].ToString();
                        fornecedor._FornecedorNome = dr["fornecedorNome"].ToString();

                        listaFornecedor.Add(fornecedor);
                    }
                }
                else
                {
                    listaFornecedor = null;
                }
                dr.Close();
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse fornecedor pela razão social  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os fornecedores da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os fornecedores e seus atributos.</returns>
        public IList<Fornecedor> BuscarTodosFornecedores()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Fornecedor ORDER BY fornecedorNome ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Fornecedor fornecedor = new Fornecedor();
                        fornecedor._FornecedorID = (int)dr["fornecedorID"];
                        fornecedor._DataCadastro = dr["dataCadastro"].ToString();
                        fornecedor._FornecedorNome = dr["fornecedorNome"].ToString();

                        listaFornecedor.Add(fornecedor);
                    }
                }
                else
                {
                    listaFornecedor = null;
                }
                dr.Close();
                return listaFornecedor;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os fornecedores " + ex.Message);
            }
        }
    }
}
