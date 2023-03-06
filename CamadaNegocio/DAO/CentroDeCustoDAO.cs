using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;
using System.Data.SqlClient;
using System.Data;

namespace CamadaNegocio.DAO
{
    /// <summary>
    /// Classe com os comandos CRUD do centro de custo.
    /// </summary>
    public class CentroDeCustoDAO
    {
        /// <summary>
        /// Método para Gravar um centro de custo.
        /// </summary>
        /// <param name="centroDeCusto">Variável do tipo centro de custo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(CentroDeCusto centroDeCusto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO CentroDeCusto (codigo, dataCadastro, descricao) values(@codigo, @dataCadastro, @descricao)";

                cmd.Parameters.AddWithValue("@codigo", centroDeCusto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", centroDeCusto._DataCadastro);
                cmd.Parameters.AddWithValue("@descricao", centroDeCusto._Descricao);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar esse centro de custo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar um centro de custo.
        /// </summary>
        /// <param name="centroDeCusto">Variável do tipo centro de custo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(CentroDeCusto centroDeCusto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE CentroDeCusto SET codigo=@codigo, dataCadastro=@dataCadastro, descricao=@descricao" +
                    " WHERE centroDeCustoID=@centroDeCustoID";


                cmd.Parameters.AddWithValue("@centroDeCustoID", centroDeCusto._CentroDeCustoID);
                cmd.Parameters.AddWithValue("@codigo", centroDeCusto._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", centroDeCusto._DataCadastro);
                cmd.Parameters.AddWithValue("@descricao", centroDeCusto._Descricao);


                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar esse centro de custo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir um centro de custo.
        /// </summary>
        /// <param name="centroDeCusto">Variável do tipo centro de custo com o valor do id para fazer a exclusão.</param>
        public void Excluir(CentroDeCusto centroDeCusto)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM CentroDeCusto WHERE centroDeCustoID = @centroDeCustoID";

                cmd.Parameters.AddWithValue("@centroDeCustoID", centroDeCusto._CentroDeCustoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir esse centro de custo " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar um centro de custo pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do centro de custo preenchidas.</returns>
        public CentroDeCusto BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CentroDeCusto WHERE centroDeCustoID = @centroDeCustoID";

                cmd.Parameters.AddWithValue("@centroDeCustoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                CentroDeCusto centroDeCusto = new CentroDeCusto();

                if (dr.HasRows)
                {
                    dr.Read();
                    centroDeCusto._CentroDeCustoID = (int)dr["centroDeCustoID"];
                    centroDeCusto._Codigo = dr["codigo"].ToString();
                    centroDeCusto._DataCadastro = dr["dataCadastro"].ToString();
                    centroDeCusto._Descricao = dr["descricao"].ToString();
                }
                else
                {
                    centroDeCusto = null;
                }
                dr.Close();
                return centroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse centro de custo pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um centro de custo pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>Retorna uma Lista com os atributos do centro de custo preenchidas.</returns>
        public IList<CentroDeCusto> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CentroDeCusto WHERE codigo like @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<CentroDeCusto> listaCentroDeCusto = new List<CentroDeCusto>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CentroDeCusto centroDeCusto = new CentroDeCusto();
                        centroDeCusto._CentroDeCustoID = (int)dr["centroDeCustoID"];
                        centroDeCusto._Codigo = dr["codigo"].ToString();
                        centroDeCusto._DataCadastro = dr["dataCadastro"].ToString();
                        centroDeCusto._Descricao = dr["descricao"].ToString();

                        listaCentroDeCusto.Add(centroDeCusto);
                    }
                }
                else
                {
                    listaCentroDeCusto = null;
                }
                dr.Close();
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse centro de custo pelo código  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um centro de custo pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com o valor da descrição.</param>
        /// <returns>Retorna uma Lista com os atributos do centro de custo preenchidas.</returns>
        public IList<CentroDeCusto> BuscarPorDescricao(string descricao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CentroDeCusto WHERE descricao like @descricao";

                cmd.Parameters.AddWithValue("@descricao", descricao + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<CentroDeCusto> listaCentroDeCusto = new List<CentroDeCusto>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CentroDeCusto centroDeCusto = new CentroDeCusto();
                        centroDeCusto._CentroDeCustoID = (int)dr["centroDeCustoID"];
                        centroDeCusto._Codigo = dr["codigo"].ToString();
                        centroDeCusto._DataCadastro = dr["dataCadastro"].ToString();
                        centroDeCusto._Descricao = dr["descricao"].ToString();

                        listaCentroDeCusto.Add(centroDeCusto);
                    }
                }
                else
                {
                    listaCentroDeCusto = null;
                }
                dr.Close();
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar esse centro de custo pela descrição " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os centros de custo da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os centros de custo e seus atributos.</returns>
        public IList<CentroDeCusto> BuscarTodosCentrosDeCusto()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM CentroDeCusto";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<CentroDeCusto> listaCentroDeCusto = new List<CentroDeCusto>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        CentroDeCusto centroDeCusto = new CentroDeCusto();
                        centroDeCusto._CentroDeCustoID = (int)dr["centroDeCustoID"];
                        centroDeCusto._Codigo = dr["codigo"].ToString();
                        centroDeCusto._DataCadastro = dr["dataCadastro"].ToString();
                        centroDeCusto._Descricao = dr["descricao"].ToString();

                        listaCentroDeCusto.Add(centroDeCusto);
                    }
                }
                else
                {
                    listaCentroDeCusto = null;
                }
                dr.Close();
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todos os centros de custo " + ex.Message);
            }
        }
    }
}
