using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadaNegocio.MODEL;
using CamadaNegocio.DAO;

namespace CamadaNegocio.BO
{
    /// <summary>
    /// Classe que faz a validação dos dados do processo.
    /// </summary>
    public class ProcessoBO
    {
        /// <summary>
        /// Variável do tipo processo com os atributos para serem preenchidos.
        /// </summary>
        Processo processo;
        /// <summary>
        /// Váriavel da classe processoDAO para chamar os métodos da classe DAO.
        /// </summary>
        ProcessoDAO processoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do processo.
        /// </summary>
        IList<Processo> listaProcesso;

        /// <summary>
        /// Método que faz a Validação dos Dados do Processo.
        /// </summary>
        /// <param name="processo">Atributo do tipo processo com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Processo processo)
        {
            if (string.IsNullOrEmpty(processo._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(processo._ProcessoData))
            {
                throw new Exception("Campo DATA DO PROCESSO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(processo._ProcessoNumero))
            {
                throw new Exception("Campo NÚMERO DO PROCESSO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um processo sem que o seu id seja informado.
        /// </summary>
        /// <param name="processo">Atributo do tipo processo com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Processo processo)
        {
            if (processo._ProcessoID.Equals(0))
            {
                throw new Exception("Selecione um PROCESSO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um processo.
        /// </summary>
        /// <param name="processo">Variável do tipo processo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Processo processo)
        {
            try
            {
                ValidacaoSalvar(processo);

                processoDAO = new ProcessoDAO();

                if (processo._ProcessoID != 0)
                {
                    processoDAO.Atualizar(processo);
                }
                else
                {
                    processoDAO.Salvar(processo);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para excluir um processo.
        /// </summary>
        /// <param name="processo">Variável do tipo processo com o valor do id para fazer a exclusão.</param>
        public void Excluir(Processo processo)
        {
            try
            {
                ValidacaoExcluir(processo);

                processoDAO = new ProcessoDAO();
                processoDAO.Excluir(processo);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um processo pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do processo preenchidas.</returns>
        public Processo BuscarPorID(int id)
        {
            try
            {
                processo = new Processo();
                processoDAO = new ProcessoDAO();

                processo = processoDAO.BuscarPorID(id);
                return processo;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um processo pela data.
        /// </summary>
        /// <param name="data">Variável com a data.</param>
        /// <returns>retorna uma lista com os atributos daquele processo que foi consultado.</returns>
        public IList<Processo> BuscarPorData(string data)
        {
            try
            {
                listaProcesso = new List<Processo>();
                processoDAO = new ProcessoDAO();

                listaProcesso = processoDAO.BuscarPorData(data);
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um processo pelo número.
        /// </summary>
        /// <param name="numero">Variável com o número.</param>
        /// <returns>retorna uma lista com os atributos daquele processo que foi consultado.</returns>
        public IList<Processo> BuscarPorNumero(string numero)
        {
            try
            {
                listaProcesso = new List<Processo>();
                processoDAO = new ProcessoDAO();

                listaProcesso = processoDAO.BuscarPorNumero(numero);
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todos os processos da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todos os processos e seus atributos.</returns>
        public IList<Processo> BuscarTodosProcessos()
        {
            try
            {
                listaProcesso = new List<Processo>();
                processoDAO = new ProcessoDAO();

                listaProcesso = processoDAO.BuscarTodosProcessos();
                return listaProcesso;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
