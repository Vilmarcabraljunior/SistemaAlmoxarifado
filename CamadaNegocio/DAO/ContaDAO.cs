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
    /// Classe com os comandos CRUD da conta.
    /// </summary>
    public class ContaDAO
    {
        /// <summary>
        /// Método para Gravar uma conta.
        /// </summary>
        /// <param name="conta">Variável do tipo conta com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Conta conta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "INSERT INTO Conta (contaDescricao, contaNumero, dataCadastro, contaFuncao, tipoConta) values(@contaDescricao, @contaNumero, @dataCadastro, @contaFuncao, @tipoConta)";

                cmd.Parameters.AddWithValue("@contaDescricao", conta._ContaDescricao);
                cmd.Parameters.AddWithValue("@contaNumero", conta._ContaNumero);
                cmd.Parameters.AddWithValue("@dataCadastro", conta._DataCadastro);
                cmd.Parameters.AddWithValue("@contaFuncao", conta._ContaFuncao);
                cmd.Parameters.AddWithValue("@tipoConta", conta._TipoConta);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível salvar essa conta " + ex.Message);
            }

        }

        /// <summary>
        /// Método para atualizar uma conta.
        /// </summary>
        /// <param name="conta">Variável do tipo conta com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Atualizar(Conta conta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "UPDATE Conta SET contaDescricao=@contaDescricao, contaNumero=@contaNumero, dataCadastro=@dataCadastro,"+
                    " contaFuncao=@contaFuncao, tipoConta=@tipoConta WHERE contaID=@contaID";

                cmd.Parameters.AddWithValue("@contaID", conta._ContaID);
                cmd.Parameters.AddWithValue("@contaDescricao", conta._ContaDescricao);
                cmd.Parameters.AddWithValue("@contaNumero", conta._ContaNumero);
                cmd.Parameters.AddWithValue("@dataCadastro", conta._DataCadastro);
                cmd.Parameters.AddWithValue("@contaFuncao", conta._ContaFuncao);
                cmd.Parameters.AddWithValue("@tipoConta", conta._TipoConta);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível atualizar essa conta " + ex.Message);
            }

        }

        /// <summary>
        /// Método para excluir uma conta.
        /// </summary>
        /// <param name="conta">Variável do tipo conta com o valor do id para fazer a exclusão.</param>
        public void Excluir(Conta conta)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "DELETE FROM Conta WHERE contaID = @contaID";

                cmd.Parameters.AddWithValue("@contaID", conta._ContaID);

                Conexao.manterCrud(cmd);
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível excluir essa conta " + ex.Message);
            }

        }

        /// <summary>
        /// Método para buscar uma conta pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos da conta preenchidas.</returns>
        public Conta BuscarPorID(int id)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Conta WHERE contaID = @contaID";

                cmd.Parameters.AddWithValue("@contaID", id);

                SqlDataReader dr = Conexao.selecionar(cmd);

                Conta conta = new Conta();

                if (dr.HasRows)
                {
                    dr.Read();
                    conta._ContaID = (int)dr["contaID"];
                    conta._ContaDescricao = dr["contaDescricao"].ToString();
                    conta._ContaNumero = dr["contaNumero"].ToString();
                    conta._DataCadastro = dr["dataCadastro"].ToString();
                    conta._ContaFuncao = dr["contaFuncao"].ToString();
                    conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), dr["tipoConta"].ToString());
                }
                else
                {
                    conta = null;
                }
                dr.Close();
                return conta;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa conta pelo id " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma conta pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com o valor da descrição.</param>
        /// <returns>Retorna uma Lista com os atributos da conta preenchidas.</returns>
        public IList<Conta> BuscarPorDescricao(string descricao)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Conta WHERE contaDescricao like @contaDescricao";

                cmd.Parameters.AddWithValue("@contaDescricao", descricao + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Conta> listaConta = new List<Conta>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Conta conta = new Conta();
                        conta._ContaID = (int)dr["contaID"];
                        conta._ContaDescricao = dr["contaDescricao"].ToString();
                        conta._ContaNumero = dr["contaNumero"].ToString();
                        conta._DataCadastro = dr["dataCadastro"].ToString();
                        conta._ContaFuncao = dr["contaFuncao"].ToString();
                        conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), dr["tipoConta"].ToString());

                        listaConta.Add(conta);
                    }
                }
                else
                {
                    listaConta = null;
                }
                dr.Close();
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa conta pela descrição  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma conta pelo número.
        /// </summary>
        /// <param name="numero">Variável com o valor do número.</param>
        /// <returns>Retorna uma Lista com os atributos da conta preenchidas.</returns>
        public IList<Conta> BuscarPorNumero(string numero)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Conta WHERE contaNumero like @contaNumero";

                cmd.Parameters.AddWithValue("@contaNumero", numero + "%");

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Conta> listaConta = new List<Conta>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Conta conta = new Conta();
                        conta._ContaID = (int)dr["contaID"];
                        conta._ContaDescricao = dr["contaDescricao"].ToString();
                        conta._ContaNumero = dr["contaNumero"].ToString();
                        conta._DataCadastro = dr["dataCadastro"].ToString();
                        conta._ContaFuncao = dr["contaFuncao"].ToString();
                        conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), dr["tipoConta"].ToString());

                        listaConta.Add(conta);
                    }
                }
                else
                {
                    listaConta = null;
                }
                dr.Close();
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar essa conta pelo número  " + ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as contas da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as contas e seus atributos.</returns>
        public IList<Conta> BuscarTodasContas()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT * FROM Conta";

                SqlDataReader dr = Conexao.selecionar(cmd);

                IList<Conta> listaConta = new List<Conta>();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Conta conta = new Conta();
                        conta._ContaID = (int)dr["contaID"];
                        conta._ContaDescricao = dr["contaDescricao"].ToString();
                        conta._ContaNumero = dr["contaNumero"].ToString();
                        conta._DataCadastro = dr["dataCadastro"].ToString();
                        conta._ContaFuncao = dr["contaFuncao"].ToString();
                        conta._TipoConta = (TipoConta)Enum.Parse(typeof(TipoConta), dr["tipoConta"].ToString());

                        listaConta.Add(conta);
                    }
                }
                else
                {
                    listaConta = null;
                }
                dr.Close();
                return listaConta;
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível buscar todas as contas " + ex.Message);
            }
        }
    }
}
