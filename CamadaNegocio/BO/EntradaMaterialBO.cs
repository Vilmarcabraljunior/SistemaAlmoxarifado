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
    /// Classe que faz a validação dos dados da entrada de material.
    /// </summary>
    public class EntradaMaterialBO
    {
        /// <summary>
        /// Variável do tipo entrada de material com os atributos para serem preenchidos.
        /// </summary>
        EntradaMaterial entradaMaterial;
        /// <summary>
        /// Váriavel da classe entradaMaterialDAO para chamar os métodos da classe DAO.
        /// </summary>
        EntradaMaterialDAO entradaMaterialDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados da entrada de material.
        /// </summary>
        IList<EntradaMaterial> listaEntradaMaterial;

        /// <summary>
        /// Método que faz a Validação dos Dados da entrada de material.
        /// </summary>
        /// <param name="entradaMaterial">Atributo do tipo entrada de material com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(EntradaMaterial entradaMaterial)
        {
            if (string.IsNullOrEmpty(entradaMaterial._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(entradaMaterial._HoraCadastro))
            {
                throw new Exception("Campo HORA DO CADASTRO é Obrigatório.");
            }

            else if (entradaMaterial._Fornecedor._FornecedorID.Equals(0))
            {
                throw new Exception("Selecione o FORNECEDOR.");
            }
            else if (entradaMaterial._Usuario._UsuarioID.Equals(0))
            {
                throw new Exception("Selecione o USUÁRIO.");
            }
            else if (entradaMaterial._Processo._ProcessoID.Equals(0))
            {
                throw new Exception("Selecione o PROCESSO.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma entrada de material sem que o seu id seja informado.
        /// </summary>
        /// <param name="entradaMaterial">Atributo do tipo entrada de material com os atributos que serão validados.</param>
        public void ValidacaoExcluir(EntradaMaterial entradaMaterial)
        {
            if (entradaMaterial._EntradaMaterialID.Equals(0))
            {
                throw new Exception("Selecione uma ENTRADA DE MATERIAL para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para Gravar uma entrada de material.
        /// </summary>
        /// <param name="entradaMaterial">Variável do tipo entrada de material com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da entrada de material.</returns>
        public int Salvar(EntradaMaterial entradaMaterial)
        {
            try
            {
                ValidacaoSalvar(entradaMaterial);

                entradaMaterialDAO = new EntradaMaterialDAO();

                if (entradaMaterial._EntradaMaterialID != 0)
                {
                    return entradaMaterialDAO.Atualizar(entradaMaterial);
                }
                else
                {
                    return entradaMaterialDAO.Salvar(entradaMaterial);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(entradaMaterial);

                entradaMaterialDAO = new EntradaMaterialDAO();
                entradaMaterialDAO.Excluir(entradaMaterial);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                entradaMaterial = new EntradaMaterial();
                entradaMaterialDAO = new EntradaMaterialDAO();

                entradaMaterial = entradaMaterialDAO.BuscarPorID(id);
                return entradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pela data da entrada.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data de entrada.</param>
        /// <returns>retorna uma lista com os atributos daquela entrada de material que foi consultada.</returns>
        public IList<EntradaMaterial> BuscarPorEntradaData(string dataCadastro)
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarPorEntradaData(dataCadastro);
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pela data da entrada.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data de entrada.</param>
        /// <returns>retorna uma lista com os atributos daquela entrada de material que foi consultada.</returns>
        public IList<EntradaMaterial> BuscarEntradaDataPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarEntradaDataPorBetween(dataInicial, dataFinal);
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pelo id do fornecedor.
        /// </summary>
        /// <param name="fornecedorID">Variável com o valor do id do fornecedor.</param>
        /// <returns>retorna uma lista com os atributos daquela entrada de material que foi consultada.</returns>
        public IList<EntradaMaterial> BuscarPorFornecedor(int fornecedorID)
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarPorFornecedor(fornecedorID);
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pelo id da situação.
        /// </summary>
        /// <param name="situacaoID">Variável com o valor do id da situação.</param>
        /// <returns>retorna uma lista com os atributos daquela entrada de material que foi consultada.</returns>
        public IList<EntradaMaterial> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarPorSituacao(situacaoID);
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma entrada de material pelo id do usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o valor do id do usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela entrada de material que foi consultada.</returns>
        public IList<EntradaMaterial> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarPorUsuario(usuarioID);
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as entradas de material e seus itens da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as entradas de material e seus itens.</returns>
        public IList<EntradaMaterial> BuscarTodasEntradasMaterialComItens()
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarTodasEntradasMaterialComItens();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as entradas de material da base de dados.
        /// </summary>
        /// <returns>Retorna uma lista com todas as entradas de material e seus atributos.</returns>
        public IList<EntradaMaterial> BuscarTodasEntradasMaterial()
        {
            try
            {
                listaEntradaMaterial = new List<EntradaMaterial>();
                entradaMaterialDAO = new EntradaMaterialDAO();

                listaEntradaMaterial = entradaMaterialDAO.BuscarTodasEntradasMaterial();
                return listaEntradaMaterial;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
