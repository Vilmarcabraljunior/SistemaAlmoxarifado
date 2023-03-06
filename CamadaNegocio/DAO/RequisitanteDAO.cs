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
    /// Classe com os comandos CRUD do requisitante.
    /// </summary>
    public class RequisitanteDAO
    {
        /// <summary>
        /// Método para Gravar um requisitante.
        /// </summary>
        /// <param name="requisitante">Variável do tipo requisitante com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Requisitante requisitante)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Requisitante (codigo, dataCadastro, requisitanteNome) values(@codigo, @dataCadastro, @requisitanteNome)";

                cmd.Parameters.AddWithValue("@codigo", requisitante._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", requisitante._DataCadastro);
                cmd.Parameters.AddWithValue("@requisitanteNome", requisitante._RequisitanteNome);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse requisitante " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um requisitante.
        /// </summary>
        /// <param name="requisitante">Variável do tipo requisitante com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Requisitante requisitante)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Requisitante SET codigo=@codigo, dataCadastro=@dataCadastro, requisitanteNome=@requisitanteNome"+
                    " WHERE requisitanteID=@requisitanteID";

                cmd.Parameters.AddWithValue("@requisitanteID", requisitante._RequisitanteID);
                cmd.Parameters.AddWithValue("@codigo", requisitante._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", requisitante._DataCadastro);
                cmd.Parameters.AddWithValue("@requisitanteNome", requisitante._RequisitanteNome);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse requisitante " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um requisitante.
        /// </summary>
        /// <param name="requisitante">Variável do tipo requisitante com o valor do id para fazer a exclusão.</param>
        public void Excluir(Requisitante requisitante)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Requisitante WHERE requisitanteID = @requisitanteID";

                cmd.Parameters.AddWithValue("@requisitanteID", requisitante._RequisitanteID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse requisitante " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um requisitante pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do requisitante preenchidos.</returns>
        public Requisitante BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisitante WHERE requisitanteID = @requisitanteID";

                cmd.Parameters.AddWithValue("@requisitanteID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Requisitante requisitante = new Requisitante();

                if (dr.HasRows)
                {
                    dr.Read();
                    requisitante._RequisitanteID = (int)dr["requisitanteID"];
                    requisitante._Codigo = dr["codigo"].ToString();
                    requisitante._DataCadastro = dr["dataCadastro"].ToString();
                    requisitante._RequisitanteNome = dr["requisitanteNome"].ToString();
                }
                else
                {
                    requisitante = null;
                }
                dr.Close();
                return requisitante;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse requisitante pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um requisitante pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código do requisitante.</param>
        /// <returns>Retorna uma Lista com os atributos do requisitante preenchidos.</returns>
        public IList<Requisitante> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisitante WHERE codigo like @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Requisitante requisitante = new Requisitante();
                        requisitante._RequisitanteID = (int)dr["requisitanteID"];
                        requisitante._Codigo = dr["codigo"].ToString();
                        requisitante._DataCadastro = dr["dataCadastro"].ToString();
                        requisitante._RequisitanteNome = dr["requisitanteNome"].ToString();

                        listaRequisitante.Add(requisitante);
                    }
                }
                else
                {
                    listaRequisitante = null;
                }
                dr.Close();
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse requisitante pelo código  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um requisitante pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome do requisitante.</param>
        /// <returns>Retorna uma Lista com os atributos do requisitante preenchidos.</returns>
        public IList<Requisitante> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisitante WHERE requisitanteNome like @requisitanteNome";

                cmd.Parameters.AddWithValue("@requisitanteNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Requisitante requisitante = new Requisitante();
                        requisitante._RequisitanteID = (int)dr["requisitanteID"];
                        requisitante._Codigo = dr["codigo"].ToString();
                        requisitante._DataCadastro = dr["dataCadastro"].ToString();
                        requisitante._RequisitanteNome = dr["requisitanteNome"].ToString();

                        listaRequisitante.Add(requisitante);
                    }
                }
                else
                {
                    listaRequisitante = null;
                }
                dr.Close();
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse requisitante pelo nome  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os requisitantes da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os requisitantes e seus atributos.</returns>
        public IList<Requisitante> BuscarTodosRequisitantes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisitante ORDER BY requisitanteNome ASC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Requisitante requisitante = new Requisitante();
                        requisitante._RequisitanteID = (int)dr["requisitanteID"];
                        requisitante._Codigo = dr["codigo"].ToString();
                        requisitante._DataCadastro = dr["dataCadastro"].ToString();
                        requisitante._RequisitanteNome = dr["requisitanteNome"].ToString();

                        listaRequisitante.Add(requisitante);
                    }
                }
                else
                {
                    listaRequisitante = null;
                }
                dr.Close();
                return listaRequisitante;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os requisitantes " + ex.Message);
            }
        }
    }
}
