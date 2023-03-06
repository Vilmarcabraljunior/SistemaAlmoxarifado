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
    /// Classe que faz a validação dos dados da requisição.
    /// </summary>
    public class RequisicaoBO
    {
        /// <summary>
        /// Variável do tipo requisição com os atributos para serem preenchidos.
        /// </summary>
        Requisicao requisicao;
        /// <summary>
        /// Váriavel da classe requisicaoDAO para chamar os métodos da classe DAO.
        /// </summary>
        RequisicaoDAO requisicaoDAO;
        /// <summary>
        /// Variável do tipo Lista para retornar os dados da requisição.
        /// </summary>
        IList<Requisicao> listaRequisicao;

        /// <summary>
        /// Método que faz a Validação dos Dados da requisição.
        /// </summary>
        /// <param name="requisicao">Atributo do tipo requisição com os atributos que serão validados.</param>
        #region Métodos Auxiliares
        public void ValidacaoSalvar(Requisicao requisicao)
        {
            if (string.IsNullOrEmpty(requisicao._Codigo))
            {
                throw new Exception("Campo CÓDIGO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(requisicao._DataCadastro))
            {
                throw new Exception("Campo DATA DO CADASTRO é Obrigatório.");
            }
            else if (string.IsNullOrEmpty(requisicao._HoraCadastro))
            {
                throw new Exception("Campo HORA DO CADASTRO é Obrigatória.");
            }

            else if (requisicao._Endereco._EnderecoID.Equals(0))
            {
                throw new Exception("Selecione o ENDEREÇO.");
            }
            else if (requisicao._Usuario._UsuarioID.Equals(0))
            {
                throw new Exception("Selecione o USUÁRIO.");
            }
            else if (requisicao._Requisitante._RequisitanteID.Equals(0))
            {
                throw new Exception("Selecione o REQUISITANTE.");
            }
            else if (requisicao._Situacao._SituacaoID.Equals(0))
            {
                throw new Exception("Selecione a SITUAÇÃO.");
            }
        }
        /// <summary>
        /// Método que não deixa excluir uma requisição sem que o seu id seja informado.
        /// </summary>
        /// <param name="requisicao">Atributo do tipo requisição com os atributos que serão validados.</param>
        public void ValidacaoExcluir(Requisicao requisicao)
        {
            if (requisicao._RequisicaoID.Equals(0))
            {
                throw new Exception("Selecione uma REQUISIÇÃO para efetuar a Exclusão.");
            }
        }
        #endregion

        /// <summary>
        /// Método para gravar uma requisição.
        /// </summary>
        /// <param name="requisicao">Variável do tipo requisição com os atributos preenchidos para serem gravados na base de dados.</param>
        /// <returns>Retorna o valor do id da requisição.</returns>
        public int Salvar(Requisicao requisicao)
        {
            try
            {
                ValidacaoSalvar(requisicao);

                requisicaoDAO = new RequisicaoDAO();

                if (requisicao._RequisicaoID != 0)
                {
                    return requisicaoDAO.Atualizar(requisicao);
                }
                else
                {
                    return requisicaoDAO.Salvar(requisicao);
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
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
                ValidacaoExcluir(requisicao);

                requisicaoDAO = new RequisicaoDAO();
                requisicaoDAO.Excluir(requisicao);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                requisicao = new Requisicao();
                requisicaoDAO = new RequisicaoDAO();

                requisicao = requisicaoDAO.BuscarPorID(id);
                return requisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                requisicao = new Requisicao();
                requisicaoDAO = new RequisicaoDAO();

                requisicao = requisicaoDAO.BuscarUltimaRequisicaoCadastrada();
                return requisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo código.
        /// </summary>
        /// <param name="codigo">Variável com o código.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorCodigo(string codigo)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorCodigo(codigo);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo código e pela área do usuário.
        /// </summary>
        /// <param name="codigo">Variável com o código.</param>
        /// <param name="areaID">Variável com o valor do id da áera do usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorCodigoPorArea(string codigo, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorCodigoPorArea(codigo, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorDataCadastro(string dataCadastro)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorDataCadastro(dataCadastro);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data e pela área do usuário.
        /// </summary>
        /// <param name="dataCadastro">Variável com a data.</param>
        /// <param name="areaID">Variável com o valor do id da áera do usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorDataCadastroPorArea(string dataCadastro, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorDataCadastroPorArea(dataCadastro, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data inicial e data final.
        /// </summary>
        /// <param name="dataInicial">Variável com a data inicial da requisição.</param>
        /// <param name="dataFinal">Variável com a data final da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarDataCadastroPorBetween(string dataInicial, string dataFinal)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarDataCadastroPorBetween(dataInicial, dataFinal);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela data inicial, final e área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o id da área do usuário.</param>
        /// <param name="dataInicial">Variável com a data inicial da requisição.</param>
        /// <param name="dataFinal">Variável com a data final da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarDataCadastroPorBetweenPorArea(string dataInicial, string dataFinal, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarDataCadastroPorBetweenPorArea(dataInicial, dataFinal, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela situação.
        /// </summary>
        /// <param name="situacao">Variável com a situação.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorSituacao(int situacaoID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorSituacao(situacaoID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pela situação.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <param name="situacao">Variável com o valor do id da situação da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorSituacaoPorArea(int situacaoID, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorSituacaoPorArea(situacaoID, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo usuário.
        /// </summary>
        /// <param name="usuarioID">Variável com o usuário.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorUsuario(int usuarioID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorUsuario(usuarioID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo usuário e pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário</param>
        /// <param name="usuarioID">Variável com o valor do id do usuário da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorUsuarioPorArea(int usuarioID, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorUsuarioPorArea(usuarioID, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo requisitante.
        /// </summary>
        /// <param name="requisitanteID">Variável com o requisitante.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorRequisitante(int requisitanteID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisitante(requisitanteID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar uma requisição pelo requisitante e pela área do usuário.
        /// </summary>
        /// <param name="areaID">Variável com o id da área do usuário.</param>
        /// <param name="requisitanteID">Variável com o valor do id do requisitante da requisição.</param>
        /// <returns>retorna uma lista com os atributos daquela requisição que foi consultada.</returns>
        public IList<Requisicao> BuscarPorRequisitantePorArea(int requisitanteID, int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisitantePorArea(requisitanteID, areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação em aberto ou pendente.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesAbertasOuPendentes()
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesAbertasOuPendentes();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação em aberto.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesEmAberto()
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesEmAberto();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situações pendentes.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesPendentes()
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesPendentes();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situações finalizadas.
        /// </summary>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesFinalizadas()
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesFinalizadas();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação em abserto ou pendente por area/setor.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesAbertasOuPendentesPorArea(int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesAbertasOuPendentesPorArea(areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação em abserto por area/setor.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesEmAbertoPorArea(int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesEmAbertoPorArea(areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação Pendente por area/setor.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesPendentesPorArea(int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesPendentesPorArea(areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar as requisiçãoes com situação finalizada por area/setor.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarPorRequisicoesFinalizadasPorArea(int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarPorRequisicoesFinalizadasPorArea(areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarTodasRequisicoes();
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Método para buscar todas as requisições da base de dados e pela área do usúário.
        /// </summary>
        /// <param name="areaID">Variável com o valor do id da área do usuário.</param>
        /// <returns>Retorna uma lista com todas as requisições e seus atributos.</returns>
        public IList<Requisicao> BuscarTodasRequisicoesPorArea(int areaID)
        {
            try
            {
                listaRequisicao = new List<Requisicao>();
                requisicaoDAO = new RequisicaoDAO();

                listaRequisicao = requisicaoDAO.BuscarTodasRequisicoesPorArea(areaID);
                return listaRequisicao;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
