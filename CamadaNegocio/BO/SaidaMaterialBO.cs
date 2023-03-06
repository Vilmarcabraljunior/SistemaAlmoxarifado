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
    /// Classe que faz a validação dos dados da saída de material.
    /// </summary>
    public class SaidaMaterialBO
    {
        /// <summary>
        /// Variável do tipo saída de material com os atributos para serem preenchidos.
        /// </summary>
        SaidaMaterial saidaMaterial;
        /// <summary>
        /// Váriavel da classe saidaMaterialDAO para chamar os métdos da classe DAO.
        /// </summary>
        SaidaMaterialDAO saidaMaterialDAO;
        /// <summary>
        /// Variável do tipo Lista para retorna os dados da saída de material.
        /// </summary>
        IList<SaidaMaterial> listaSaidaMaterial;

        /// <summary>
        /// Método que faz a Validação dos Dados da saída de material.
        /// </summary>
        /// <param name="saidaMaterial">Atributo do tipo saida de material com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(SaidaMaterial saidaMaterial)
        {
            if (string.IsNullOrEmpty(saidaMaterial._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(saidaMaterial._HoraCadastro))
            {
                throw new Exception("Campo HORA DO CADASTRO é Obrigatória.");
            }

            else if (saidaMaterial._Usuario._UsuarioID.Equals(0))
            {
                throw new Exception("Selecione o USUÁRIO.");
            }
            else if (saidaMaterial._Requisitante._RequisitanteID.Equals(0))
            {
                throw new Exception("Selecione o REQUISITANTE.");
            }
            else if (saidaMaterial._CentroDeCusto._CentroDeCustoID.Equals(0))
            {
                throw new Exception("Selecione o CENTRO DE CUSTO.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma saída de material sem que o seu id seja informado.
        /// </summary>
        /// <param name="saidaMaterial">Atributo do tipo saida de material com os atributos que serão validados.</param>
        public void ValidacaoExcluir(SaidaMaterial saidaMaterial)
        {
            if (saidaMaterial._SaidaMaterialID.Equals(0))
            {
                throw new Exception("Selecione uma SAÍDA DE MATERIAL para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma saída de material.
        /// </summary>
        /// <param name="saidaMaterial">Variável do tipo saída de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da saída de material.</returns>
        public int Salvar(SaidaMaterial saidaMaterial)
        {
            try
            {
                ValidacaoSalvar(saidaMaterial);

                saidaMaterialDAO = new SaidaMaterialDAO();

                if (saidaMaterial._SaidaMaterialID != 0)
                {
                    return saidaMaterialDAO.Atualizar(saidaMaterial);
                }
                else
                {
                    return saidaMaterialDAO.Salvar(saidaMaterial);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(saidaMaterial);

                saidaMaterialDAO = new SaidaMaterialDAO();
                saidaMaterialDAO.Excluir(saidaMaterial);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                saidaMaterial = new SaidaMaterial();
                saidaMaterialDAO = new SaidaMaterialDAO();

                saidaMaterial = saidaMaterialDAO.BuscarPorID(id);
                return saidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pela data.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data.</param>
        /// <returns>retorna uma lista com os atributos daquela saída de material que foi consultada.</returns>
        public IList<SaidaMaterial> BuscarPorSaidaData(string dataCadastro)
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarPorSaidaData(dataCadastro);
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pela data.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data.</param>
        /// <returns>retorna uma lista com os atributos daquela saída de material que foi consultada.</returns>
        public IList<SaidaMaterial> BuscarSaidaDataPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarSaidaDataPorBetween(dataInicial, dataFinal);
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id da situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor do id da situação.</param>
        /// <returns>retorna uma lista com os atributos daquela saída de material que foi consultada.</returns>
        public IList<SaidaMaterial> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarPorSituacao(situacaoID);
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id do usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do id do usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela saída de material que foi consultada.</returns>
        public IList<SaidaMaterial> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarPorUsuario(usuarioID);
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma saída de material pelo id do requisitante.
        /// </summary>
        /// <param name="requisitanteID">Variável com o valor do id do requisitante.</param>
        /// <returns>retorna uma lista com os atributos daquela saída de material que foi consultada.</returns>
        public IList<SaidaMaterial> BuscarPorRequisitante(int requisitanteID)
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarPorRequisitante(requisitanteID);
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as saídas de materiais da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as saídas de materiais e seus atributos.</returns>
        public IList<SaidaMaterial> BuscarSomatorioSaidaMaterialPorConta()
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarSomatorioSaidaMaterialPorConta();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as saídas de materiais da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as saídas de materiais e seus atributos.</returns>
        public IList<SaidaMaterial> BuscarTodasSaidasMaterial()
        {
            try
            {
                listaSaidaMaterial = new List<SaidaMaterial>();
                saidaMaterialDAO = new SaidaMaterialDAO();

                listaSaidaMaterial = saidaMaterialDAO.BuscarTodasSaidasMaterial();
                return listaSaidaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
