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
    /// Classe que faz a validação dos dados da área.
    /// </summary>
    public class AreaBO
    {
        /// <summary>
        /// Variável do tipo área com os atributos para serem preenchidos.
        /// </summary>
        Area area;
        /// <summary>
        /// Váriavel da classe areaDAO para chamar os métdos da classe DAO.
        /// </summary>
        AreaDAO areaDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados do area.
        /// </summary>
        IList<Area> listaArea;

        /// <summary>
        /// Método que faz a Validação dos Dados da Área.
        /// </summary>
        /// <param name="area">Atributo do tipo área com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Area area)
        {
            if (string.IsNullOrEmpty(area._AreaNome))
            {
                throw new Exception("Campo NOME DA ÁREA é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(area._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma área sem que o seu id seja informado.
        /// </summary>
        /// <param name="area">Atributo do tipo área com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Area area)
        {
            if (area._AreaID.Equals(0))
            {
                throw new Exception("Selecione uma ÁREA para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma área.
        /// </summary>
        /// <param name="area">Variável do tipo área com os atributos preenchidos para serem gravados na base de dados.</param>
        public void Salvar(Area area)
        {
            try
            {
                ValidacaoSalvar(area);

                areaDAO = new AreaDAO();

                if (area._AreaID != 0)
                {
                    areaDAO.Atualizar(area);
                }
                else
                {
                    areaDAO.Salvar(area);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(area);

                areaDAO = new AreaDAO();
                areaDAO.Excluir(area);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                area = new Area();
                areaDAO = new AreaDAO();

                area = areaDAO.BuscarPorID(id);
                return area;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma área pelo nome.
        /// </summary>
        /// <param name="nome">Variável com o nome da área.</param>
        /// <returns>retorna uma lista com os atributos daquela área que foi consultada.</returns>
        public IList<Area> BuscarPorNome(string nome)
        {
            try
            {
                listaArea = new List<Area>();
                areaDAO = new AreaDAO();

                listaArea = areaDAO.BuscarPorNome(nome);
                return listaArea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as áreas da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as áreas e seus atributos.</returns>
        public IList<Area> BuscarTodasAreas()
        {
            try
            {
                listaArea = new List<Area>();
                areaDAO = new AreaDAO();

                listaArea = areaDAO.BuscarTodasAreas();
                return listaArea;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
