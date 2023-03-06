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
    /// Classe com os comandos CRUD da saída de material.
    /// </summary>
    public class SaidaMaterialDAO
    {
        /// <summary>
        /// Método para Gravar uma saída de material.
        /// </summary>
        /// <param name="saidaMaterial">Variável do tipo saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da saída de material.</returns>
        public int Salvar(SaidaMaterial saidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO SaidaMaterial (dataCadastro, horaCadastro, observacao, usuarioID, requisitanteID, centroDeCustoID)" +
                    " output inserted.saidaMaterialID values(@dataCadastro, @horaCadastro, @observacao, @usuarioID, @requisitanteID, @centroDeCustoID)";

                cmd.Parameters.AddWithValue("@dataCadastro", saidaMaterial._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", saidaMaterial._HoraCadastro);
                cmd.Parameters.AddWithValue("@observacao", saidaMaterial._Observacao);
                cmd.Parameters.AddWithValue("@usuarioID", saidaMaterial._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@requisitanteID", saidaMaterial._Requisitante._RequisitanteID);
                cmd.Parameters.AddWithValue("@centroDeCustoID", saidaMaterial._CentroDeCusto._CentroDeCustoID);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa saída de material " + ex.Message);
            }
        }

        /// <summary>
        /// Método para atualizar uma saída de material.
        /// </summary>
        /// <param name="saidaMaterial">Variável do tipo saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da saída de material.</returns>
        public int Atualizar(SaidaMaterial saidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE SaidaMaterial SET dataCadastro=@dataCadastro, horaCadastro=@horaCadastro, observacao=@observacao, usuarioID=@usuarioID, requisitanteID=@requisitanteID, centroDeCustoID=@centroDeCustoID" +
                    " output inserted.saidaMaterialID WHERE saidaMaterialID=@saidaMaterialID";

                cmd.Parameters.AddWithValue("@saidaMaterialID", saidaMaterial._SaidaMaterialID);
                cmd.Parameters.AddWithValue("@dataCadastro", saidaMaterial._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", saidaMaterial._HoraCadastro);
                cmd.Parameters.AddWithValue("@observacao", saidaMaterial._Observacao);
                cmd.Parameters.AddWithValue("@usuarioID", saidaMaterial._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@requisitanteID", saidaMaterial._Requisitante._RequisitanteID);
                cmd.Parameters.AddWithValue("@centroDeCustoID", saidaMaterial._CentroDeCusto._CentroDeCustoID);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa saída de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma saída de material.
        /// </summary>
        /// <param name="saidaMaterial">Variável do tipo saída de material com o valor do id para fazer a exclusão.</param>
        public void Excluir(SaidaMaterial saidaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM SaidaMaterial WHERE saidaMaterialID = @saidaMaterialID";

                cmd.Parameters.AddWithValue("@saidaMaterialID", saidaMaterial._SaidaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa saída de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma saída de material pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da saída de material preenchidas.</returns>
        public SaidaMaterial BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE saidaMaterialID = @saidaMaterialID";

                cmd.Parameters.AddWithValue("@saidaMaterialID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                SaidaMaterial saidaMaterial = new SaidaMaterial();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    dr.Read();
                    saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                    saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                    saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                    saidaMaterial._Observacao = dr["observacao"].ToString();
                    saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                    saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                    saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);
                }
                else
                {
                    saidaMaterial = null;
                }
                dr.Close();
                return saidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pela data da saída.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data da saída.</param>
        /// <returns>Retorna uma Lista com os atributos da saída de material preenchidas.</returns>
        public IList<SaidaMaterial> BuscarPorSaidaData(string dataCadastro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE dataCadastro = @dataCadastro";

                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material pela data da saída  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pela data da saída.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data da saída.</param>
        /// <returns>Retorna uma Lista com os atributos da saída de material preenchidas.</returns>
        public IList<SaidaMaterial> BuscarSaidaDataPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material por between " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id da situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor do id da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da saída de material preenchidas.</returns>
        public IList<SaidaMaterial> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", situacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material pelo id da situação  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id do usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do id do usuario.</param>
        /// <returns>Retorna uma Lista com os atributos da saída de material preenchidas.</returns>
        public IList<SaidaMaterial> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material pelo id do usuário  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id do requisitante.
        /// </summary>
        /// <param name="requisitanteID">Variável com o valor do id do requisitante.</param>
        /// <returns>Retorna uma Lista com os atributos da saída de material preenchidas.</returns>
        public IList<SaidaMaterial> BuscarPorRequisitante(int requisitanteID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial WHERE requisitanteID = @requisitanteID";

                cmd.Parameters.AddWithValue("@requisitanteID", requisitanteID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa saída de material pelo id do requisitante  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as saídas de material da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as saídas de material e seus atributos.</returns>
        public IList<SaidaMaterial> BuscarSomatorioSaidaMaterialPorConta()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select Conta.contaNumero ,Conta.contaDescricao, SUM(Produto.produtoValorTotal) from SaidaMaterial, ItemSaidaMaterial, Produto, Conta"+
                    "WHERE SaidaMaterial.saidaMaterialID = ItemSaidaMaterial.saidaMaterialID and ItemSaidaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID"+
                    " GROUP BY Conta.contaNumero, Conta.contaDescricao ORDER BY Conta.contaNumero";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as saídas de material " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as saídas de material da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as saídas de material e seus atributos.</returns>
        public IList<SaidaMaterial> BuscarTodasSaidasMaterial()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM SaidaMaterial";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (dr.HasRows)
                {
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    CentroDeCustoDAO centroDeCustoDAO = new CentroDeCustoDAO();

                    while (dr.Read())
                    {
                        SaidaMaterial saidaMaterial = new SaidaMaterial();
                        saidaMaterial._SaidaMaterialID = (int)dr["saidaMaterialID"];
                        saidaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        saidaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        saidaMaterial._Observacao = dr["observacao"].ToString();
                        saidaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        saidaMaterial._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        saidaMaterial._CentroDeCusto = centroDeCustoDAO.BuscarPorID((int)dr["centroDeCustoID"]);

                        listaSaidaMaterial.Add(saidaMaterial);
                    }
                }
                else
                {
                    listaSaidaMaterial = null;
                }
                dr.Close();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as saídas de material " + ex.Message);
            }
        }
    }
}
