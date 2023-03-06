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
    /// Classe com os comandos CRUD da requisição.
    /// </summary>
    public class RequisicaoDAO
    {

        /// <summary>
        /// Método para reiniciar o id da requisicao.
        /// </summary>
        /// <param name="requisicao">Variável do tipo requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da requisição.</returns>
        public void ResetarID(int requisicaoCodigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DBCC CHECKIDENT('Requisicao', RESEED, @requisicaoID)";

                cmd.Parameters.AddWithValue("@requisicaoID", requisicaoCodigo);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível resetar esse id " + ex.Message);
            }

        }

        /// <summary>
        /// Método para gravar uma requisição.
        /// </summary>
        /// <param name="requisicao">Variável do tipo requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da requisição.</returns>
        public int Salvar(Requisicao requisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Requisicao (codigo, dataCadastro, horaCadastro, requisicaoObservacao, enderecoID, usuarioID, requisitanteID, situacaoID)"+
                    " output inserted.requisicaoID values(@codigo, @dataCadastro, @horaCadastro, @requisicaoObservacao, @enderecoID, @usuarioID, @requisitanteID, @situacaoID)";

                cmd.Parameters.AddWithValue("@codigo", requisicao._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", requisicao._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", requisicao._HoraCadastro);
                cmd.Parameters.AddWithValue("@requisicaoObservacao", requisicao._RequisicaoObservacao);
                cmd.Parameters.AddWithValue("@enderecoID", requisicao._Endereco._EnderecoID);
                cmd.Parameters.AddWithValue("@usuarioID", requisicao._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@requisitanteID", requisicao._Requisitante._RequisitanteID);
                cmd.Parameters.AddWithValue("@situacaoID", requisicao._Situacao._SituacaoID);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma requisição.
        /// </summary>
        /// <param name="requisicao">Variável do tipo requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da requisição.</returns>
        public int Atualizar(Requisicao requisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Requisicao SET codigo=@codigo, dataCadastro=@dataCadastro, horaCadastro=@horaCadastro, requisicaoObservacao=@requisicaoObservacao,"+
                    " enderecoID=@enderecoID, usuarioID=@usuarioID, requisitanteID=@requisitanteID, situacaoID=@situacaoID"+
                    " output inserted.requisicaoID WHERE requisicaoID=@requisicaoID";

                cmd.Parameters.AddWithValue("@requisicaoID", requisicao._RequisicaoID);
                cmd.Parameters.AddWithValue("@codigo", requisicao._Codigo);
                cmd.Parameters.AddWithValue("@dataCadastro", requisicao._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", requisicao._HoraCadastro);
                cmd.Parameters.AddWithValue("@requisicaoObservacao", requisicao._RequisicaoObservacao);
                cmd.Parameters.AddWithValue("@enderecoID", requisicao._Endereco._EnderecoID);
                cmd.Parameters.AddWithValue("@usuarioID", requisicao._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@requisitanteID", requisicao._Requisitante._RequisitanteID);
                cmd.Parameters.AddWithValue("@situacaoID", requisicao._Situacao._SituacaoID);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma requisição.
        /// </summary>
        /// <param name="requisicao">Variável do tipo requisição com o valor do id para fazer a exclusão.</param>
        public void Excluir(Requisicao requisicao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Requisicao WHERE requisicaoID = @requisicaoID";

                cmd.Parameters.AddWithValue("@requisicaoID", requisicao._RequisicaoID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa requisição " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma requisição pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da requisição preenchidas.</returns>
        public Requisicao BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE requisicaoID = @requisicaoID";

                cmd.Parameters.AddWithValue("@requisicaoID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Requisicao requisicao = new Requisicao();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    dr.Read();
                    requisicao._RequisicaoID = (int)dr["requisicaoID"];
                    requisicao._Codigo = dr["codigo"].ToString();
                    requisicao._DataCadastro = dr["dataCadastro"].ToString();
                    requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                    requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                    requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                    requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                    requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                    requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);
                }
                else
                {
                    requisicao = null;
                }
                dr.Close();
                return requisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisição pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar a ultima requisição cadastrada.
        /// </summary>
        /// <returns>Retorna uma variável com os atributos da requisição preenchidas.</returns>
        public Requisicao BuscarUltimaRequisicaoCadastrada()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT TOP 1 * FROM Requisicao ORDER BY requisicaoID DESC";

                SqlDataReader dr = Conexao.selecionar(cmd);

                Requisicao requisicao = new Requisicao();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    dr.Read();
                    requisicao._RequisicaoID = (int)dr["requisicaoID"];
                    requisicao._Codigo = dr["codigo"].ToString();
                    requisicao._DataCadastro = dr["dataCadastro"].ToString();
                    requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                    requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                    requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                    requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                    requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                    requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);
                }
                else
                {
                    requisicao = null;
                }
                dr.Close();
                return requisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar a ultima requisicao cadastrada " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorCodigo(string codigo)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE codigo = @codigo";

                cmd.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo código " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo código e pela área do usuário.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código da requisição.</param>
        /// <param name="areaID">Variável com o valor do id da áera do usuário.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorCodigoPorArea(string codigo, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and codigo = @codigo";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@codigo", codigo);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo código e pela área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data do cadastro.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorDataCadastro(string dataCadastro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE dataCadastro = @dataCadastro";

                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela data da requisição " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data do cadastro e pela área do usuário.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data da requisição.</param>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorDataCadastroPorArea(string dataCadastro, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.AreaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.dataCadastro = @dataCadastro";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela data da requisição e pela área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data do cadastro.
        /// </summary>
        /// <param name="dataInicial">Variável com o valor da data inicial da requisição.</param>
        /// <param name="dataFinal">Variável com o valor da data final da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarDataCadastroPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo between " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data incial, data final e pela área do usuário.
        /// </summary>
        /// <param name="dataInicial">Variável com o valor da data inicial da requisição.</param>
        /// <param name="dataFinal">Variável com o valor da data da final requisição.</param>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarDataCadastroPorBetweenPorArea(string dataInicial, string dataFinal, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo between e pela área do usuário " + ex.Message);
            }
        }


        /// <summary>
        /// Método para buscar uma requisição pela situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor da situação da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", situacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela situação e pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="situacaoID">Variável com o valor da situação da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorSituacaoPorArea(int situacaoID, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@situacaoID", situacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação e pelo id da área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do usuário da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo usuário e pela área do usuario.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="usuarioID">Variável com o valor do id do usuário da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorUsuarioPorArea(int usuarioID, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo usuário e pela área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo Requisitante.
        /// </summary>
        /// <param name="requisitanteID">Variável com o valor do requisitante da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorRequisitante(int requisitanteID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE requisitanteID = @requisitanteID";

                cmd.Parameters.AddWithValue("@requisitanteID", requisitanteID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo requisitante " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo Requisitante e pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="requisitanteID">Variável com o valor do  id do requisitante da requisição.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<Requisicao> BuscarPorRequisitantePorArea(int requisitanteID, int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.requisitanteID = @requisitanteID";

                cmd.Parameters.AddWithValue("@areaID", areaID);
                cmd.Parameters.AddWithValue("@requisitanteID", requisitanteID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pelo requisitante e pela área do usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situação em aberto ou pendente.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesAbertasOuPendentes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE situacaoID BETWEEN 1 and 2";
                
                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação em aberta ou pendente " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situações em aberto.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesEmAberto()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE situacaoID = 1";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação em aberto " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situações pendentes.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesPendentes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE situacaoID = 2";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situações pendentes " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situações finalizadas.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesFinalizadas()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao WHERE situacaoID = 3";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situações finalizadas " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situação em aberto ou pendente por Área.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesAbertasOuPendentesPorArea(int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID"+
                    " and Usuario.areaID = @areaID and Requisicao.situacaoID BETWEEN 1 and 2";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação em aberta ou pendente por área " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situação em aberto.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesEmAbertoPorArea(int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID" +
                    " and Usuario.areaID = @areaID and Requisicao.situacaoID = 1";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação em aberto por área " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situação pendente.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesPendentesPorArea(int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID" +
                    " and Usuario.areaID = @areaID and Requisicao.situacaoID = 2";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação pendente por área " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisições com situação finalizada.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesFinalizadasPorArea(int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID" +
                    " and Usuario.areaID = @areaID and Requisicao.situacaoID = 3";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa requisicao pela situação finalizada por área " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as requisições da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarTodasRequisicoes()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as requisições " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as requisições da base de dados pelo id da área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarTodasRequisicoesPorArea(int areaID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Requisicao, Usuario, Area WHERE Requisicao.usuarioID = Usuario.usuarioID and Usuario.areaID = Area.areaID" +
                    " and Usuario.areaID = @areaID";

                cmd.Parameters.AddWithValue("@areaID", areaID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (dr.HasRows)
                {
                    EnderecoDAO enderecoDAO = new EnderecoDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    RequisitanteDAO requisitanteDAO = new RequisitanteDAO();
                    SituacaoDAO situacaoDAO = new SituacaoDAO();

                    while (dr.Read())
                    {
                        Requisicao requisicao = new Requisicao();
                        requisicao._RequisicaoID = (int)dr["requisicaoID"];
                        requisicao._Codigo = dr["codigo"].ToString();
                        requisicao._DataCadastro = dr["dataCadastro"].ToString();
                        requisicao._HoraCadastro = dr["horaCadastro"].ToString();
                        requisicao._RequisicaoObservacao = dr["requisicaoObservacao"].ToString();
                        requisicao._Endereco = enderecoDAO.BuscarPorID((int)dr["enderecoID"]);
                        requisicao._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        requisicao._Requisitante = requisitanteDAO.BuscarPorID((int)dr["requisitanteID"]);
                        requisicao._Situacao = situacaoDAO.BuscarPorID((int)dr["situacaoID"]);

                        listaRequisicao.Add(requisicao);
                    }
                }
                else
                {
                    listaRequisicao = null;
                }
                dr.Close();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as requisições pela área do usuário " + ex.Message);
            }
        }
    }
}
