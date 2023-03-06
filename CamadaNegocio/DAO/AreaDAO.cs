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
    /// Classe com os comandos CRUD da área.
    /// </summary>
    public class AreaDAO
    {
        /// <summary>
        /// Método para Gravar uma área.
        /// </summary>
        /// <param name="area">Variável do tipo área com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Area area)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Area (areaNome, dataCadastro) values(@areaNome, @dataCadastro)";

                cmd.Parameters.AddWithValue("@areaNome", area._AreaNome);
                cmd.Parameters.AddWithValue("@dataCadastro", area._DataCadastro);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa área " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma área.
        /// </summary>
        /// <param name="area">Variável do tipo área com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Area area)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Area SET areaNome=@areaNome, dataCadastro=@dataCadastro WHERE areaID=@areaID";

                cmd.Parameters.AddWithValue("@areaID", area._AreaID);
                cmd.Parameters.AddWithValue("@areaNome", area._AreaNome);
                cmd.Parameters.AddWithValue("@dataCadastro", area._DataCadastro);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa área " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma área.
        /// </summary>
        /// <param name="area">Variável do tipo área com o valor do id para fazer a exclusão.</param>
        public void Excluir(Area area)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Area WHERE areaID = @areaID";

                cmd.Parameters.AddWithValue("@areaID", area._AreaID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa área " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma área pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da área preenchidas.</returns>
        public Area BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Area WHERE areaID = @areaID";

                cmd.Parameters.AddWithValue("@areaID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Area area = new Area();

                if (dr.HasRows)
                {
                    dr.Read();
                    area._AreaID = (int)dr["areaID"];
                    area._AreaNome = dr["areaNome"].ToString();
                    area._DataCadastro = dr["dataCadastro"].ToString();
                }
                else
                {
                    area = null;
                }
                dr.Close();
                return area;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa área pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma área pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o valor do nome.</param>
        /// <returns>Retorna uma Lista com os atributos da área preenchidas.</returns>
        public IList<Area> BuscarPorNome(string nome)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Area WHERE areaNome like @areaNome";

                cmd.Parameters.AddWithValue("@areaNome", nome + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Area> listaArea = new List<Area>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Area area = new Area();
                        area._AreaID = (int)dr["areaID"];
                        area._AreaNome = dr["areaNome"].ToString();
                        area._DataCadastro = dr["dataCadastro"].ToString();

                        listaArea.Add(area);
                    }
                }
                else
                {
                    listaArea = null;
                }
                dr.Close();
                return listaArea;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa área pelo nome  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as área da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos as áreas e seus atributos.</returns>
        public IList<Area> BuscarTodasAreas()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Area";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Area> listaArea = new List<Area>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Area area = new Area();
                        area._AreaID = (int)dr["areaID"];
                        area._AreaNome = dr["areaNome"].ToString();
                        area._DataCadastro = dr["dataCadastro"].ToString();

                        listaArea.Add(area);
                    }
                }
                else
                {
                    listaArea = null;
                }
                dr.Close();
                return listaArea;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as áreas " + ex.Message);
            }
        }
    }
}
