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
    /// Classe que faz a validação dos dados do centro de custo.
    /// </summary>
    public class CentroDeCustoBO
    {
        /// <summary>
        /// Variável do tipo centro de custo com os atributos para serem preenchidos.
        /// </summary>
        CentroDeCusto centroDeCusto;
        /// <summary>
        /// Váriavel da classe centroDeCustoDAO para chamar os métodos da classe DAO.
        /// </summary>
        CentroDeCustoDAO centroDeCustoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do centro de custo.
        /// </summary>
        IList<CentroDeCusto> listaCentroDeCusto;

        /// <summary>
        /// Método que faz a Validação dos Dados do centro de custo.
        /// </summary>
        /// <param name="centroDeCusto">Atributo do tipo centro de custo com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(CentroDeCusto centroDeCusto)
        {
            if (string.IsNullOrEmpty(centroDeCusto._Codigo))
            {
                throw new Exception("Campo CÓDIGO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(centroDeCusto._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(centroDeCusto._Descricao))
            {
                throw new Exception("Campo CENTRO DE CUSTO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir um centro de custo sem que o seu id seja informado.
        /// </summary>
        /// <param name="centroDeCusto">Atributo do tipo centro de custo com os atributos que serão validados.</param>
        public void ValidacaoExcluir(CentroDeCusto centroDeCusto)
        {
            if (centroDeCusto._CentroDeCustoID.Equals(0))
            {
                throw new Exception("Selecione um CENTRO DE CUSTO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar um centro de custo.
        /// </summary>
        /// <param name="centroDeCusto">Variável do tipo centro de custo com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(CentroDeCusto centroDeCusto)
        {
            try
            {
                ValidacaoSalvar(centroDeCusto);

                centroDeCustoDAO = new CentroDeCustoDAO();

                if (centroDeCusto._CentroDeCustoID != 0)
                {
                    centroDeCustoDAO.Atualizar(centroDeCusto);
                }
                else
                {
                    centroDeCustoDAO.Salvar(centroDeCusto);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(centroDeCusto);

                centroDeCustoDAO = new CentroDeCustoDAO();
                centroDeCustoDAO.Excluir(centroDeCusto);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um centro de custo pelo seu id(primary key).
        /// </summary>
        /// <param name="id">Atributo com o valor do id.</param>
        /// <returns>Retorna uma variável com os atributos do centro de custo preenchidos.</returns>
        public CentroDeCusto BuscarPorID(int id)
        {
            try
            {
                centroDeCusto = new CentroDeCusto();
                centroDeCustoDAO = new CentroDeCustoDAO();

                centroDeCusto = centroDeCustoDAO.BuscarPorID(id);
                return centroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um centro de custo pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o valor do código.</param>
        /// <returns>retorna uma lista com os atributos daquele centro de custo que foi consultado.</returns>
        public IList<CentroDeCusto> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaCentroDeCusto = new List<CentroDeCusto>();
                centroDeCustoDAO = new CentroDeCustoDAO();

                listaCentroDeCusto = centroDeCustoDAO.BuscarPorCodigo(codigo);
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar um centro de custo pela descrição.
        /// </summary>
        /// <param name="descricao">Variável com a descrição do centro de custo.</param>
        /// <returns>retorna uma lista com os atributos daquele centro de custo que foi consultado.</returns>
        public IList<CentroDeCusto> BuscarPorDescricao(string descricao)
        {
            try
            {
                listaCentroDeCusto = new List<CentroDeCusto>();
                centroDeCustoDAO = new CentroDeCustoDAO();

                listaCentroDeCusto = centroDeCustoDAO.BuscarPorDescricao(descricao);
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                listaCentroDeCusto = new List<CentroDeCusto>();
                centroDeCustoDAO = new CentroDeCustoDAO();

                listaCentroDeCusto = centroDeCustoDAO.BuscarTodosCentrosDeCusto();
                return listaCentroDeCusto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
