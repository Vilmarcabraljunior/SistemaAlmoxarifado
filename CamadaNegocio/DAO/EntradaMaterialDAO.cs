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
    /// Classe com os comandos CRUD da entrada de materiais.
    /// </summary>
    public class EntradaMaterialDAO
    {
        /// <summary>
        /// Método para Gravar uma entrada de material.
        /// </summary>
        /// <param name="entradaMaterial">Variável do tipo entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da entrada de material.</returns>
        public int Salvar(EntradaMaterial entradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO EntradaMaterial (dataCadastro, horaCadastro, observacao, fornecedorID, usuarioID, processoID)"+
                    " output inserted.entradaMaterialID values(@dataCadastro, @horaCadastro, @observacao, @fornecedorID, @usuarioID, @processoID)";

                cmd.Parameters.AddWithValue("@dataCadastro", entradaMaterial._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", entradaMaterial._HoraCadastro);
                cmd.Parameters.AddWithValue("@observacao", entradaMaterial._Observacao);
                cmd.Parameters.AddWithValue("@fornecedorID", entradaMaterial._Fornecedor._FornecedorID);
                cmd.Parameters.AddWithValue("@usuarioID", entradaMaterial._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@processoID", entradaMaterial._Processo._ProcessoID);



                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma entrada de material.
        /// </summary>
        /// <param name="entradaMaterial">Variável do tipo entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da entrada de material.</returns>
        public int Atualizar(EntradaMaterial entradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE EntradaMaterial SET dataCadastro=@dataCadastro, horaCadastro=@horaCadastro, observacao=@observacao," +
                    " fornecedorID=@fornecedorID, usuarioID=@usuarioID, processoID=@processoID output inserted.entradaMaterialID WHERE entradaMaterialID=@entradaMaterialID";

                cmd.Parameters.AddWithValue("@entradaMaterialID", entradaMaterial._EntradaMaterialID);
                cmd.Parameters.AddWithValue("@dataCadastro", entradaMaterial._DataCadastro);
                cmd.Parameters.AddWithValue("@horaCadastro", entradaMaterial._HoraCadastro);
                cmd.Parameters.AddWithValue("@observacao", entradaMaterial._Observacao);
                cmd.Parameters.AddWithValue("@fornecedorID", entradaMaterial._Fornecedor._FornecedorID);
                cmd.Parameters.AddWithValue("@usuarioID", entradaMaterial._Usuario._UsuarioID);
                cmd.Parameters.AddWithValue("@processoID", entradaMaterial._Processo._ProcessoID);

                return Conexao.manterCrudRetornaID(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma entrada de material.
        /// </summary>
        /// <param name="entradaMaterial">Variável do tipo entrada de material com o valor do id para fazer a exclusão.</param>
        public void Excluir(EntradaMaterial entradaMaterial)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM EntradaMaterial WHERE entradaMaterialID = @entradaMaterialID";

                cmd.Parameters.AddWithValue("@entradaMaterialID", entradaMaterial._EntradaMaterialID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa entrada de material " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma entrada de material pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da entrada de material preenchidas.</returns>
        public EntradaMaterial BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE entradaMaterialID = @entradaMaterialID";

                cmd.Parameters.AddWithValue("@entradaMaterialID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                EntradaMaterial entradaMaterial = new EntradaMaterial();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    dr.Read();
                    entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                    entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                    entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                    entradaMaterial._Observacao = dr["observacao"].ToString();
                    entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                    entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                    entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);
                }
                else
                {
                    entradaMaterial = null;
                }
                dr.Close();
                return entradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pela data de entrada.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data de entrada.</param>
        /// <returns>Retorna uma Lista com os atributos da entrada de material preenchidas.</returns>
        public IList<EntradaMaterial> BuscarPorEntradaData(string dataCadastro)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE dataCadastro = @dataCadastro";

                cmd.Parameters.AddWithValue("@dataCadastro", dataCadastro);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material pela data da entrada  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pela data de entrada.
        /// </summary>
        /// <param name="dataCadastro">Variável com o valor da data de entrada.</param>
        /// <returns>Retorna uma Lista com os atributos da entrada de material preenchidas.</returns>
        public IList<EntradaMaterial> BuscarEntradaDataPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE dataCadastro BETWEEN @dataInicial AND @dataFinal";

                cmd.Parameters.AddWithValue("@dataInicial", Convert.ToDateTime(dataInicial));
                cmd.Parameters.AddWithValue("@dataFinal", Convert.ToDateTime(dataFinal));

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material por between  " + ex.Message);
            }
        }
 
        /// <summary>
        /// Método para buscar uma entrada de material pel id do fornecedor.
        /// </summary>
        /// <param name="fornecedorID">Variável com o valor do id do fornecedor.</param>
        /// <returns>Retorna uma Lista com os atributos da entrada de material preenchidas.</returns>
        public IList<EntradaMaterial> BuscarPorFornecedor(int fornecedorID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE fornecedorID = @fornecedorID";

                cmd.Parameters.AddWithValue("@fornecedorID", fornecedorID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material pelo id do fornecedor  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pela situação.
        /// </summary>
        /// <param name="situacao">Variável com o valor da situação da entrada de material.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<EntradaMaterial> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE situacaoID = @situacaoID";

                cmd.Parameters.AddWithValue("@situacaoID", situacaoID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material pela situação " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pelo usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do usuário da entrada de material.</param>
        /// <returns>Retorna uma Lista com os atributos da requisição preenchidas.</returns>
        public IList<EntradaMaterial> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial WHERE usuarioID = @usuarioID";

                cmd.Parameters.AddWithValue("@usuarioID", usuarioID);

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa entrada de material pelo usuário " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as entradas de material e seus itens da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos as entradas de material e seus itens.</returns>
        public IList<EntradaMaterial> BuscarTodasEntradasMaterialComItens()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();
                    ItemEntradaMaterialDAO itemEntradaMaterialDAO = new ItemEntradaMaterialDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);
                        entradaMaterial._ListaItemEntradaMaterial = itemEntradaMaterialDAO.BuscarItensDaEntradaMaterial((int)dr["entradaMaterialID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as entradas de material e seus itens " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as entradas de material da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos as entradas de material e seus atributos.</returns>
        public IList<EntradaMaterial> BuscarTodasEntradasMaterial()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM EntradaMaterial";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (dr.HasRows)
                {
                    FornecedorDAO fornecedorDAO = new FornecedorDAO();
                    UsuarioDAO usuarioDAO = new UsuarioDAO();
                    ProcessoDAO processoDAO = new ProcessoDAO();

                    while (dr.Read())
                    {
                        EntradaMaterial entradaMaterial = new EntradaMaterial();
                        entradaMaterial._EntradaMaterialID = (int)dr["entradaMaterialID"];
                        entradaMaterial._DataCadastro = dr["dataCadastro"].ToString();
                        entradaMaterial._HoraCadastro = dr["horaCadastro"].ToString();
                        entradaMaterial._Observacao = dr["observacao"].ToString();
                        entradaMaterial._Fornecedor = fornecedorDAO.BuscarPorID((int)dr["fornecedorID"]);
                        entradaMaterial._Usuario = usuarioDAO.BuscarPorID((int)dr["usuarioID"]);
                        entradaMaterial._Processo = processoDAO.BuscarPorID((int)dr["processoID"]);

                        listaEntradaMaterial.Add(entradaMaterial);
                    }
                }
                else
                {
                    listaEntradaMaterial = null;
                }
                dr.Close();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as entradas de material " + ex.Message);
            }
        }
    }
}
