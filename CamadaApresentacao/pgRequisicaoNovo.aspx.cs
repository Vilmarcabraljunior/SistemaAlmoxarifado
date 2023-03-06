using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;
using CamadaNegocio.DAO;

namespace CamadaApresentacao
{
    public partial class pgRequisicaoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDataCadastroRequisitante.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroEndereco.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroSituacao.Text = DateTime.Now.ToLongDateString();

            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();

            //Métódo que atualiza as informaçãos do panel do gridview.
            AtualizarTelaPrincialGridView();

            //Métódo que atualiza os contadores da tela de requisição.
            AtualizarContadoresDaRequisicao();

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            //ProdutoBO produtoBO = new ProdutoBO();
            //produtoBO.AtualizarPrecoUnitarioMedioEstoque();

            try
            {
                //Verificando o nivel de acesso do usuário para definir o readonly do txtquantidadeatendida
                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel0)
                {
                    txtQuantidadeAtendida.Visible = false;
                    lblQuantidadeAtendidaRotulo.Visible = false;
                    lkbBuscarSituacaoModal.Visible = false;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel1)
                {
                    txtQuantidadeAtendida.Visible = true;
                    lblQuantidadeAtendidaRotulo.Visible = true;
                    lkbBuscarSituacaoModal.Visible = true;
                    lkbNovaSituacaoModal.Visible = false;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    txtQuantidadeAtendida.Visible = false;
                    lblQuantidadeAtendidaRotulo.Visible = false;
                    lkbBuscarSituacaoModal.Visible = false;
                    lkbNovaSituacaoModal.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvRequisicao.DataSource = null;
            gvRequisicao.DataBind();
        }

        public void LimparFormulario()
        {
            lblRequisicaoNovoTitulo.Text = "Nova Requisição";
            lblRequisicaoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdRequisicaoID.Value = "0";
            txtDataCadastroRequisicao.Text = DateTime.Now.ToShortDateString();
            txtRequisicaoCodigo.Text = string.Empty;

            hdRequisitanteID.Value = "0";
            txtRequisitanteCodigo.Text = string.Empty;
            txtRequisitanteNome.Text = string.Empty;

            hdEnderecoID.Value = "0";
            txtEnderecoCodigo.Text = string.Empty;
            txtEnderecoDescricao.Text = string.Empty;

            hdSituacaoID.Value = "0";
            txtSituacaoNome.Text = string.Empty;

            txtRequisicaoObservacao.Text = string.Empty;

            hdUsuarioID.Value = "0";

            gvItemRequisicao.DataSource = null;
            gvItemRequisicao.DataBind();
        }

        public void LimparFormularioDetalhes()
        {
            hdDetalhesRequisicaoID.Value = "0";
            lblDataCadastroRequisicao.Text = DateTime.Now.ToShortDateString();
            lblRequisicaoCodigo.Text = string.Empty;

            lblRequisitanteCodigo.Text = string.Empty;
            lblRequisitanteNome.Text = string.Empty;

            lblEnderecoCodigo.Text = string.Empty;
            lblEnderecoDescricao.Text = string.Empty;

            lblSituacaoNome.Text = string.Empty;

            txtRequisicaoObservacaoDetalhes.Text = string.Empty;

            lblUsuarioNome.Text = string.Empty;
            lblUsuarioArea.Text = string.Empty;

            gvItemRequisicaoDetalhes.DataSource = null;
            gvItemRequisicaoDetalhes.DataBind();

            lblValorTotalGeralDetalhes.Text = string.Empty;
        }

        public void LimparFormularioRequisitante()
        {
            hdRequisitanteModalID.Value = "0";
            txtDataCadastroRequisitante.Text = DateTime.Now.ToLongDateString();
            txtRequisitanteCodigoModal.Text = string.Empty;
            txtRequisitanteNomeModal.Text = string.Empty;
        }

        public void LimparFormularioEndereco()
        {
            hdEnderecoModalID.Value = "0";
            txtDataCadastroEndereco.Text = DateTime.Now.ToLongDateString();
            txtEnderecoCodigoModal.Text = string.Empty;
            txtEnderecoDescricaoModal.Text = string.Empty;
        }

        public void LimparFormularioSituacao()
        {
            hdSituacaoModalID.Value = "0";
            txtDataCadastroSituacao.Text = DateTime.Now.ToLongDateString();
            txtSituacaoNomeModal.Text = string.Empty;
        }

        public void ValidacaoSalvarProduto()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                Mensagem("Campo CÓDIGO DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtDataCadastroProduto.Text))
            {
                Mensagem("Campo DATA DO CADASTRO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtProdutoNome.Text))
            {
                Mensagem("Campo NOME DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }

            else if (hdContaID.Value == "0")
            {
                Mensagem("Selecione uma CONTA.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (hdUnidadeID.Value == "0")
            {
                Mensagem("Selecione uma UNIDADE.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
        }

        public void LimparFormularioProduto()
        {
            hdProdutoID.Value = "0";
            txtCodigo.Text = string.Empty;
            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNome.Text = string.Empty;
            txtProdutoPrecoUnitario.Text = string.Empty;
            txtQuantidadeAtendida.Text = "0";
            txtQuantidadeSolicitada.Text = "0";

            hdContaID.Value = "0";
            txtConta.Text = string.Empty;
            txtContaNumero.Text = string.Empty;

            hdUnidadeID.Value = "0";
            txtUnidadeDescricao.Text = string.Empty;
        }

        public void LimparFormularioConta()
        {
            hdContaModalID.Value = "0";
            txtContaDescricao.Text = string.Empty;
            txtContaNumeroModal.Text = string.Empty;
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
        }

        public void LimparFormularioUnidade()
        {
            hdUnidadeModalID.Value = "0";
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtUnidadeDescricaoModal.Text = string.Empty;
        }

        public void LimparFormularioNomeProduto()
        {
            hdNomeProdutoID.Value = "0";
            txtCodigoModal.Text = string.Empty;
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNomeModal.Text = string.Empty;
            txtProdutoPrecoUnitarioProdutoNome.Text = string.Empty;

            hdContaIDProdutoNome.Value = "0";
            txtContaProdutoNome.Text = string.Empty;
            txtContaNumeroProdutoNome.Text = string.Empty;

            hdUnidadeIDProdutoNome.Value = "0";
            txtUnidadeDescricaoProdutoNome.Text = string.Empty;
        }

        public void CalcularValorTotalGeralItemRequisicaoDetalhes()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemRequisicaoDetalhes.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[7].Text != null && row.Cells[7].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[7].Text);
                    }

                }
            }
            lblValorTotalGeralDetalhes.Text = ValorTotal.ToString("C2");
        }

        private void BuscarPorRequisicoesAbertasOuPendentes()
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesAbertasOuPendentes();
            gvRequisicaoTelaPrincipal.DataSource = listaRequisicao;
            gvRequisicaoTelaPrincipal.DataBind();
        }

        private void BuscarPorRequisicoesAbertasOuPendentesPorArea(int areaID)
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesAbertasOuPendentesPorArea(areaID);
            gvRequisicaoTelaPrincipal.DataSource = listaRequisicao;
            gvRequisicaoTelaPrincipal.DataBind();
        }

        public void AtualizarTelaPrincialGridView()
        {
            try
            {
                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel0)
                {
                    BuscarPorRequisicoesAbertasOuPendentes();
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel1)
                {
                    BuscarPorRequisicoesAbertasOuPendentes();
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    BuscarPorRequisicoesAbertasOuPendentesPorArea(usuario._Area._AreaID);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        public void BuscarQtdeRequisicoesEmAberto()
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesEmAberto();
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesEmAberto.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesEmAberto.Text = listaRequisicao.Count.ToString();
            }
        }

        public void BuscarQtdeRequisicoesPendentes()
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesPendentes();
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesPendentes.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesPendentes.Text = listaRequisicao.Count.ToString();
            }
        }

        public void BuscarQtdeRequisicoesFinalizadas()
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesFinalizadas();
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesFinalizadas.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesFinalizadas.Text = listaRequisicao.Count.ToString();
            }
        }

        public void BuscarQtdeRequisicoesEmAbertoPorArea(int areaID)
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesEmAbertoPorArea(areaID);
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesEmAberto.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesEmAberto.Text = listaRequisicao.Count.ToString();
            }
        }

        public void BuscarQtdeRequisicoesPendentesPorArea(int areaID)
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesPendentesPorArea(areaID);
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesPendentes.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesPendentes.Text = listaRequisicao.Count.ToString();
            }
        }

        public void BuscarQtdeRequisicoesFinalizadasPorArea(int areaID)
        {
            requisicaoBO = new RequisicaoBO();
            listaRequisicao = new List<Requisicao>();

            listaRequisicao = requisicaoBO.BuscarPorRequisicoesFinalizadasPorArea(areaID);
            if (listaRequisicao == null)
            {
                lblQtdeRequisicoesFinalizadas.Text = "0";
            }
            else
            {
                lblQtdeRequisicoesFinalizadas.Text = listaRequisicao.Count.ToString();
            }
        }

        public void AtualizarContadoresDaRequisicao()
        {
            try
            {
                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel0)
                {
                    BuscarQtdeRequisicoesEmAberto();

                    BuscarQtdeRequisicoesPendentes();

                    BuscarQtdeRequisicoesFinalizadas();

                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel1)
                {

                    BuscarQtdeRequisicoesEmAberto();

                    BuscarQtdeRequisicoesPendentes();

                    BuscarQtdeRequisicoesFinalizadas();

                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {

                    BuscarQtdeRequisicoesEmAbertoPorArea(usuario._Area._AreaID);

                    BuscarQtdeRequisicoesPendentesPorArea(usuario._Area._AreaID);

                    BuscarQtdeRequisicoesFinalizadasPorArea(usuario._Area._AreaID);

                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Requisição

        #region (Eventos Principais)

        Requisicao requisicao;
        RequisicaoBO requisicaoBO;
        IList<Requisicao> listaRequisicao;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            try
            {
                requisicaoBO = new RequisicaoBO();
                requisicao = new Requisicao();

                requisicao = requisicaoBO.BuscarUltimaRequisicaoCadastrada();
                if (requisicao == null)
                {
                    txtRequisicaoCodigo.Text = "1/" + DateTime.Now.Year;
                }
                else
                {
                    RequisicaoDAO dao = new RequisicaoDAO();
                    dao.ResetarID(requisicao._RequisicaoID);
                    
                    int requisicaoCodigo = requisicao._RequisicaoID + 1;
                    txtRequisicaoCodigo.Text = Convert.ToString(requisicaoCodigo + "/" + DateTime.Now.Year);
                }

                txtDataCadastroRequisicao.Text = DateTime.Now.ToShortDateString();

                hdSituacaoID.Value = "1";
                txtSituacaoNome.Text = "Em Aberto";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }


        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                requisicao = new Requisicao();

                requisicao._RequisicaoID = Convert.ToInt32(hdRequisicaoID.Value);
                requisicao._DataCadastro = txtDataCadastroRequisicao.Text;
                requisicao._HoraCadastro = DateTime.Now.ToShortTimeString();
                requisicao._Codigo = txtRequisicaoCodigo.Text;

                requisicao._Requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteID.Value);
                requisicao._Endereco._EnderecoID = Convert.ToInt32(hdEnderecoID.Value);
                requisicao._Situacao._SituacaoID = Convert.ToInt32(hdSituacaoID.Value);

                requisicao._RequisicaoObservacao = txtRequisicaoObservacao.Text;

                if (hdRequisicaoID.Value != "0")
                {
                    requisicao._Usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                }
                else
                {
                    var usuario = (Usuario)Session["UsuarioLogado"];
                    requisicao._Usuario._UsuarioID = usuario._UsuarioID;
                }

                requisicaoBO = new RequisicaoBO();

                //salva e retorna o id para o hiddenfild para gravar os itens da requisição.
                int requisicaoIDRetornador = requisicaoBO.Salvar(requisicao);
                txtRequisicaoID.Text = requisicaoIDRetornador.ToString();

                if (requisicao._RequisicaoID != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemRequisicaoModal();", true);

                    Mensagem("Requisição Atualizada com Sucesso.", this);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemRequisicaoModal();", true);

                    Mensagem("Requisição Salva com Sucesso.", this);
                }

                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                requisicao = new Requisicao();
                requisicaoBO = new RequisicaoBO();

                //Primeiro excluir os itens da requisição para não dar erro de integridade no banco

                //Excluir os itens da requisição
                ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                itemRequisicaoBO.ExcluirItensDaRequisicao(Convert.ToInt32(hdRequisicaoID.Value));

                //excluir uma requisição
                requisicao._RequisicaoID = Convert.ToInt32(hdRequisicaoID.Value);
                requisicaoBO.Excluir(requisicao);

                Mensagem("Requisição Excluída com Sucesso.", this);
                
                LimparFormulario();
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormulario();
        }

        protected void lkbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                requisicaoBO = new RequisicaoBO();
                listaRequisicao = new List<Requisicao>();

                var usuario = (Usuario)Session["UsuarioLogado"];

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaRequisicao = requisicaoBO.BuscarPorCodigoPorArea(txtBuscarPorCodigo.Text, usuario._Area._AreaID);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }
                    else
                    {
                        listaRequisicao = requisicaoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaRequisicao = requisicaoBO.BuscarPorDataCadastroPorArea(txtBuscarPorData.Text, usuario._Area._AreaID);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }
                    else
                    {
                        listaRequisicao = requisicaoBO.BuscarPorDataCadastro(txtBuscarPorData.Text);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaRequisicao = requisicaoBO.BuscarDataCadastroPorBetweenPorArea(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text, usuario._Area._AreaID);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }
                    else
                    {
                        listaRequisicao = requisicaoBO.BuscarDataCadastroPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                }
                else
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaRequisicao = requisicaoBO.BuscarTodasRequisicoesPorArea(usuario._Area._AreaID);
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }
                    else
                    {
                        listaRequisicao = requisicaoBO.BuscarTodasRequisicoes();
                        gvRequisicao.DataSource = listaRequisicao;
                        gvRequisicao.DataBind();
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarRequisicaoPorSituacao_Click(object sender, EventArgs e)
        {
            try
            {
                SituacaoBO situacaoBO = new SituacaoBO();
                IList<Situacao> listaSituacao = new List<Situacao>();

                if (!string.IsNullOrEmpty(txtBuscarPorSituacao.Text))
                {
                    listaSituacao = situacaoBO.BuscarPorNome(txtBuscarPorSituacao.Text);
                    gvBuscarRequisicaoPorSituacao.DataSource = listaSituacao;
                    gvBuscarRequisicaoPorSituacao.DataBind();

                    txtBuscarPorSituacao.Text = string.Empty;
                }
                else
                {
                    listaSituacao = situacaoBO.BuscarTodasSituacoes();
                    gvBuscarRequisicaoPorSituacao.DataSource = listaSituacao;
                    gvBuscarRequisicaoPorSituacao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarRequisicaoPorSituacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarRequisicaoPorSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                requisicaoBO = new RequisicaoBO();
                listaRequisicao = new List<Requisicao>();

                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    int situacaoID = Convert.ToInt32(gvBuscarRequisicaoPorSituacao.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorSituacaoPorArea(situacaoID, usuario._Area._AreaID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }
                else
                {
                    int situacaoID = Convert.ToInt32(gvBuscarRequisicaoPorSituacao.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorSituacao(situacaoID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarRequisicaoPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                var usuario = (Usuario)Session["UsuarioLogado"];

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaUsuario = usuarioBO.BuscarPorNomePorArea(txtBuscarPorUsuario.Text, usuario._Area._AreaID);
                        gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                        gvBuscarRequisicaoPorUsuario.DataBind();
                    }
                    else
                    {
                        listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                        gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                        gvBuscarRequisicaoPorUsuario.DataBind();
                    }

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                    {
                        listaUsuario = usuarioBO.BuscarTodosUsuariosPorArea(usuario._Area._AreaID);
                        gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                        gvBuscarRequisicaoPorUsuario.DataBind();
                    }
                    else
                    {
                        listaUsuario = usuarioBO.BuscarTodosUsuarios();
                        gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                        gvBuscarRequisicaoPorUsuario.DataBind();
                    }
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarRequisicaoPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarRequisicaoPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                requisicaoBO = new RequisicaoBO();
                listaRequisicao = new List<Requisicao>();

                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    int usuarioID = Convert.ToInt32(gvBuscarRequisicaoPorUsuario.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorUsuarioPorArea(usuarioID, usuario._Area._AreaID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }
                else
                {
                    int usuarioID = Convert.ToInt32(gvBuscarRequisicaoPorUsuario.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorUsuario(usuarioID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarRequisicaoPorRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitanteBO requisitanteBO = new RequisitanteBO();
                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarPorRequisitante.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarPorRequisitante.Text);
                    gvBuscarRequisicaoPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarRequisicaoPorRequisitante.DataBind();

                    txtBuscarPorRequisitante.Text = string.Empty;
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    gvBuscarRequisicaoPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarRequisicaoPorRequisitante.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarRequisicaoPorRequisitanteModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarRequisicaoPorRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                requisicaoBO = new RequisicaoBO();
                listaRequisicao = new List<Requisicao>();

                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    int requisitanteID = Convert.ToInt32(gvBuscarRequisicaoPorRequisitante.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorRequisitantePorArea(requisitanteID, usuario._Area._AreaID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }
                else
                {
                    int requisitanteID = Convert.ToInt32(gvBuscarRequisicaoPorRequisitante.SelectedDataKey.Value);
                    listaRequisicao = requisicaoBO.BuscarPorRequisitante(requisitanteID);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvRequisicaoTelaPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                requisicao = new Requisicao();
                requisicaoBO = new RequisicaoBO();

                int requisicaoID = Convert.ToInt32(gvRequisicaoTelaPrincipal.SelectedDataKey.Value);
                requisicao = requisicaoBO.BuscarPorID(requisicaoID);

                hdDetalhesRequisicaoID.Value = requisicao._RequisicaoID.ToString();
                lblDataCadastroRequisicao.Text = requisicao._DataCadastro;
                lblRequisicaoCodigo.Text = requisicao._Codigo;

                lblRequisitanteCodigo.Text = requisicao._Requisitante._Codigo;
                lblRequisitanteNome.Text = requisicao._Requisitante._RequisitanteNome;

                lblEnderecoCodigo.Text = requisicao._Endereco._Codigo;
                lblEnderecoDescricao.Text = requisicao._Endereco._EnderecoDescricao;

                lblSituacaoNome.Text = requisicao._Situacao._SituacaoNome;

                txtRequisicaoObservacaoDetalhes.Text = requisicao._RequisicaoObservacao;

                lblUsuarioNome.Text = requisicao._Usuario._UsuarioNome;
                lblUsuarioArea.Text = requisicao._Usuario._Area._AreaNome;


                //mostar todos os itens da requisição.
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBO.BuscarItensDaRequisicao(requisicaoID);
                gvItemRequisicaoDetalhes.DataSource = listaItemRequisicao;
                gvItemRequisicaoDetalhes.DataBind();

                //calcular valor total geral dos detalhes do item da requisição
                CalcularValorTotalGeralItemRequisicaoDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openRequisicaoDetalhesModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvRequisicaoTelaPrincipal_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i <= gvRequisicaoTelaPrincipal.Rows.Count - 1; i++)
            {
                Label lblSituacao = (Label)gvRequisicaoTelaPrincipal.Rows[i].FindControl("lblSituacao");

                if (lblSituacao.Text == "Em Aberto")
                {
                    gvRequisicaoTelaPrincipal.Rows[i].Cells[6].BackColor = System.Drawing.Color.Yellow;
                    lblSituacao.ForeColor = System.Drawing.Color.Black;
                }
                else if (lblSituacao.Text == "Pendente")
                {
                    gvRequisicaoTelaPrincipal.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red; ;
                    lblSituacao.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        protected void gvRequisicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                requisicao = new Requisicao();
                requisicaoBO = new RequisicaoBO();

                int requisicaoID = Convert.ToInt32(gvRequisicao.SelectedDataKey.Value);
                requisicao = requisicaoBO.BuscarPorID(requisicaoID);

                hdDetalhesRequisicaoID.Value = requisicao._RequisicaoID.ToString();
                lblDataCadastroRequisicao.Text = requisicao._DataCadastro;
                lblRequisicaoCodigo.Text = requisicao._Codigo;

                lblRequisitanteCodigo.Text = requisicao._Requisitante._Codigo;
                lblRequisitanteNome.Text = requisicao._Requisitante._RequisitanteNome;

                lblEnderecoCodigo.Text = requisicao._Endereco._Codigo;
                lblEnderecoDescricao.Text = requisicao._Endereco._EnderecoDescricao;

                lblSituacaoNome.Text = requisicao._Situacao._SituacaoNome;

                var usuario = (Usuario)Session["UsuarioLogado"];
                if (lblSituacaoNome.Text == "Finalizado" && usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)  
                {
                    lkbAtualizarDetalhes.Visible = false;
                }
                else
                {
                    lblValorTotalGeralDetalhes.Visible = true;
                }
                
                txtRequisicaoObservacaoDetalhes.Text = requisicao._RequisicaoObservacao;

                lblUsuarioNome.Text = requisicao._Usuario._UsuarioNome;
                lblUsuarioArea.Text = requisicao._Usuario._Area._AreaNome;


                //mostar todos os itens da requisição.
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBO.BuscarItensDaRequisicao(requisicaoID);
                gvItemRequisicaoDetalhes.DataSource = listaItemRequisicao;
                gvItemRequisicaoDetalhes.DataBind();

                //calcular valor total geral dos detalhes do item da requisição
                CalcularValorTotalGeralItemRequisicaoDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openRequisicaoDetalhesModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvRequisicao_DataBound(object sender, EventArgs e)
        {
            for (int i = 0; i <= gvRequisicao.Rows.Count - 1; i++)
            {
                Label lblSituacao = (Label)gvRequisicao.Rows[i].FindControl("lblSituacao");

                if (lblSituacao.Text == "Em Aberto")
                {
                    gvRequisicao.Rows[i].Cells[5].BackColor = System.Drawing.Color.Yellow;
                    lblSituacao.ForeColor = System.Drawing.Color.Black;
                }
                else if (lblSituacao.Text == "Pendente")
                {
                    gvRequisicao.Rows[i].Cells[5].BackColor = System.Drawing.Color.Red; ;
                    lblSituacao.ForeColor = System.Drawing.Color.White;
                }
                else
                {
                    gvRequisicao.Rows[i].Cells[5].BackColor = System.Drawing.Color.Green; ;
                    lblSituacao.ForeColor = System.Drawing.Color.White;
                }
            }
        }

        #endregion

        #region (Eventos do Detalhes)

        protected void lkbAtualizarDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                lblRequisicaoNovoTitulo.Text = "Atualizar Requisição";
                lblRequisicaoNovoTitulo.CssClass = "fa fa-pencil";

                requisicao = new Requisicao();
                requisicaoBO = new RequisicaoBO();

                requisicao = requisicaoBO.BuscarPorID(Convert.ToInt32(hdDetalhesRequisicaoID.Value));

                hdRequisicaoID.Value = requisicao._RequisicaoID.ToString();
                txtDataCadastroRequisicao.Text = requisicao._DataCadastro;
                txtRequisicaoCodigo.Text = requisicao._Codigo;

                hdRequisitanteID.Value = requisicao._Requisitante._RequisitanteID.ToString();
                txtRequisitanteCodigo.Text = requisicao._Requisitante._Codigo;
                txtRequisitanteNome.Text = requisicao._Requisitante._RequisitanteNome;

                hdEnderecoID.Value = requisicao._Endereco._EnderecoID.ToString();
                txtEnderecoCodigo.Text = requisicao._Endereco._Codigo;
                txtEnderecoDescricao.Text = requisicao._Endereco._EnderecoDescricao;

                hdSituacaoID.Value = requisicao._Situacao._SituacaoID.ToString();
                txtSituacaoNome.Text = requisicao._Situacao._SituacaoNome;

                txtRequisicaoObservacao.Text = requisicao._RequisicaoObservacao;

                hdUsuarioID.Value = requisicao._Usuario._UsuarioID.ToString();

                //mostar todos os itens
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBO.BuscarItensDaRequisicao(Convert.ToInt32(hdRequisicaoID.Value));
                gvItemRequisicao.DataSource = listaItemRequisicao;
                gvItemRequisicao.DataBind();

                LimparFormularioDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemRequisicaoDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoDetalhesModal();", true);
        }

        protected void lkbCancelarDetalhes_Click(object sender, EventArgs e)
        {
            LimparFormularioDetalhes();
        }

        protected void lkbVisualizarRequisicaoDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openRequisicaoDetalhesModal();", true);
        }


        #endregion

        #region (Eventos do timer de atualização do gridview Principal e contadores)

        protected void timerAtualizacaoTelaPrincipal_Tick(object sender, EventArgs e)
        {
            //Métódo que atualiza as informaçãos do panel do gridview.
            AtualizarTelaPrincialGridView();

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AtualizarPrecoUnitarioMedioEstoque();
        }

        protected void TimerAtualizacaoContadores_Tick(object sender, EventArgs e)
        {
            //Métódo que atualiza os contadores da tela de requisição.
            AtualizarContadoresDaRequisicao();
        }

        #endregion


        #region (Eventos ItemRequisição)
        protected void lkbAdicionarItemRequisicaoModal_Click(object sender, EventArgs e)
        {
            try
            {
                //mostar todos os itens
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBO.BuscarItensDaRequisicao(Convert.ToInt32(txtRequisicaoID.Text));
                gvItemRequisicao.DataSource = listaItemRequisicao;
                gvItemRequisicao.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAdicionarItemRequisicaoModal_Click(object sender, EventArgs e)
        {
            txtRequisicaoID.Text = string.Empty;
            hdRequisicaoIDRetornado.Value = "0";

            LimparFormulario();
        }

        //Método para editar um item da requisição
        protected void gvItemRequisicao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Buscar um item da requisição pelo id
                requisicao = new Requisicao();
                ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                int itemRequisicaoID = Convert.ToInt32(gvItemRequisicao.DataKeys[e.RowIndex].Value);
                itemRequisicao = itemRequisicaoBO.BuscarPorID(itemRequisicaoID);


                //Buscar o produto pelo id do produto que veio do item da requisicao
                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto = produtoBO.BuscarPorID(itemRequisicao._Produto._ProdutoID);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastroProduto.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeAtendida.Text = produto._QuantidadeAtendida.ToString();
                txtQuantidadeSolicitada.Text = produto._QuantidadeSolicitada.ToString();

                hdContaID.Value = produto._Conta._ContaID.ToString();
                txtConta.Text = produto._Conta._ContaDescricao;
                txtContaNumero.Text = produto._Conta._ContaNumero;

                hdUnidadeID.Value = produto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = produto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para excluir um item da requisição
        protected void gvItemRequisicao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //exclui um item da requisição
                requisicao = new Requisicao();
                ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                int itemRequisicaoID = Convert.ToInt32(gvItemRequisicao.DataKeys[e.RowIndex].Value);
                itemRequisicao._ItemRequisicaoID = Convert.ToInt32(itemRequisicaoID);
                itemRequisicaoBO.Excluir(itemRequisicao);


                //mostar todos os itens
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBOBuscar = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBOBuscar.BuscarItensDaRequisicao(Convert.ToInt32(txtRequisicaoID.Text));
                gvItemRequisicao.DataSource = listaItemRequisicao;
                gvItemRequisicao.DataBind();


                Mensagem("Produto foi Excluído da Requisição com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        protected void lkbFinalizarAdicionarItemModal_Click(object sender, EventArgs e)
        {
            txtRequisicaoID.Text = string.Empty;
            hdRequisicaoIDRetornado.Value = "0";

            LimparFormulario();

            Mensagem("Finalizado com Sucesso.", this);
        }

        #endregion



        #region (Eventos do Requisitante)
        protected void lkbSalvarRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                Requisitante requisitante = new Requisitante();
                RequisitanteBO requisitanteBO = new RequisitanteBO();

                requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteModalID.Value);
                requisitante._DataCadastro = txtDataCadastroRequisitante.Text;
                requisitante._Codigo = txtRequisitanteCodigoModal.Text;
                requisitante._RequisitanteNome = txtRequisitanteNomeModal.Text;

                requisitanteBO.Salvar(requisitante);

                Mensagem("Requisitante Salvo com Sucesso", this);

                LimparFormularioRequisitante();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        protected void lkbCancelarRequisitante_Click(object sender, EventArgs e)
        {
            LimparFormularioRequisitante();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbVoltarRequisitante_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbBuscarRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitanteBO requisitanteBO = new RequisitanteBO();
                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarRequisitantePorCodigo.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorCodigo(txtBuscarRequisitantePorCodigo.Text);
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        txtBuscarRequisitantePorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        txtBuscarRequisitantePorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarRequisitantePorNome.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarRequisitantePorNome.Text);
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        txtBuscarRequisitantePorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        txtBuscarRequisitantePorNome.Text = string.Empty;

                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Requisitante requisitante = new Requisitante();
                RequisitanteBO requisitanteBO = new RequisitanteBO();

                int id = Convert.ToInt32(gvRequisitante.SelectedDataKey.Value);
                requisitante = requisitanteBO.BuscarPorID(id);

                hdRequisitanteID.Value = requisitante._RequisitanteID.ToString();
                txtRequisitanteCodigo.Text = requisitante._Codigo;
                txtRequisitanteNome.Text = requisitante._RequisitanteNome;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion

        #region (Eventos do Endereço)

        protected void lkbSalvarEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco();
                EnderecoBO enderecoBO = new EnderecoBO();

                endereco._EnderecoID = Convert.ToInt32(hdEnderecoModalID.Value);
                endereco._DataCadastro = txtDataCadastroEndereco.Text;
                endereco._Codigo = txtEnderecoCodigoModal.Text;
                endereco._EnderecoDescricao = txtEnderecoDescricaoModal.Text;

                enderecoBO.Salvar(endereco);

                Mensagem("Endereço Salvo com Sucesso", this);

                LimparFormularioEndereco();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarEndereco_Click(object sender, EventArgs e)
        {
            LimparFormularioEndereco();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbVoltarEndereco_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbBuscarEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                EnderecoBO enderecoBO = new EnderecoBO();
                IList<Endereco> listaEndereco = new List<Endereco>();

                if (!string.IsNullOrEmpty(txtBuscarEnderecoPorCodigo.Text))
                {
                    listaEndereco = enderecoBO.BuscarPorCodigo(txtBuscarEnderecoPorCodigo.Text);
                    if (listaEndereco != null)
                    {
                        gvEndereco.DataSource = listaEndereco;
                        gvEndereco.DataBind();

                        txtBuscarEnderecoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);
                    }
                    else
                    {
                        txtBuscarEnderecoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Endereço Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarEnderecoPorDescricao.Text))
                {
                    listaEndereco = enderecoBO.BuscarPorDescricao(txtBuscarEnderecoPorDescricao.Text);
                    if (listaEndereco != null)
                    {
                        gvEndereco.DataSource = listaEndereco;
                        gvEndereco.DataBind();

                        txtBuscarEnderecoPorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);
                    }
                    else
                    {
                        txtBuscarEnderecoPorDescricao.Text = string.Empty;

                        Mensagem("Nenhum Endereço Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
                else
                {
                    listaEndereco = enderecoBO.BuscarTodosEnderecos();
                    if (listaEndereco != null)
                    {
                        gvEndereco.DataSource = listaEndereco;
                        gvEndereco.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEnderecoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Endereço Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvEndereco_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Endereco endereco = new Endereco();
                EnderecoBO enderecoBO = new EnderecoBO();

                int id = Convert.ToInt32(gvEndereco.SelectedDataKey.Value);
                endereco = enderecoBO.BuscarPorID(id);

                hdEnderecoID.Value = endereco._EnderecoID.ToString();
                txtEnderecoCodigo.Text = endereco._Codigo;
                txtEnderecoDescricao.Text = endereco._EnderecoDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos da Situação)

        protected void lkbSalvarSituacao_Click(object sender, EventArgs e)
        {
            try
            {
                Situacao situacao = new Situacao();
                SituacaoBO situacaoBO = new SituacaoBO();

                situacao._SituacaoID = Convert.ToInt32(hdSituacaoModalID.Value);
                situacao._DataCadastro = txtDataCadastroSituacao.Text;
                situacao._SituacaoNome = txtSituacaoNomeModal.Text;

                situacaoBO.Salvar(situacao);

                Mensagem("Situação Salva com Sucesso", this);

                LimparFormularioSituacao();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarSituacao_Click(object sender, EventArgs e)
        {
            LimparFormularioSituacao();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbVoltarSituacao_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
        }

        protected void lkbBuscarSituacao_Click(object sender, EventArgs e)
        {
            try
            {
                SituacaoBO situacaoBO = new SituacaoBO();
                IList<Situacao> listaSituacao = new List<Situacao>();

                listaSituacao = situacaoBO.BuscarTodasSituacoes();
                if (listaSituacao != null)
                {
                    gvSituacao.DataSource = listaSituacao;
                    gvSituacao.DataBind();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSituacaoModal();", true);
                }
                else
                {
                    Mensagem("Nenhuma Situação Encontrada.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
                }

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvSituacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Situacao situacao = new Situacao();
                SituacaoBO situacaoBO = new SituacaoBO();

                int id = Convert.ToInt32(gvSituacao.SelectedDataKey.Value);
                situacao = situacaoBO.BuscarPorID(id);

                hdSituacaoID.Value = situacao._SituacaoID.ToString();
                txtSituacaoNome.Text = situacao._SituacaoNome;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion



        #region (Eventos do Produto)

        protected void lkbSalvarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacaoSalvarProduto();

                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                Produto produtoVer = new Produto();
                ProdutoBO produtoBOVer = new ProdutoBO();

                produto._ProdutoID = Convert.ToInt32(hdProdutoID.Value);
                produto._Codigo = txtCodigo.Text;
                produto._DataCadastro = txtDataCadastroProduto.Text;
                produto._ProdutoNome = txtProdutoNome.Text;
                produto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitario.Text);
                produto._QuantidadeAtendida = Convert.ToInt32(txtQuantidadeAtendida.Text);
                produto._QuantidadeSolicitada = Convert.ToInt32(txtQuantidadeSolicitada.Text);
                produto._ProdutoValorTotal = Convert.ToDecimal(produto._ProdutoPrecoUnitario * produto._QuantidadeAtendida);

                produto._Conta._ContaID = Convert.ToInt32(hdContaID.Value);
                produto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);

                //verifica se o produto tem estoque vázio
                if (txtQuantidadeAtendida.Text != "0") 
                {
                    produtoVer = produtoBOVer.VarificaSeProdutoTemEstoqueVazio(txtProdutoNome.Text);
                    if (Convert.ToInt32(txtQuantidadeAtendida.Text) > produtoVer._QuantidadeEstoque)
                    {
                        string mensagem = produtoVer._ProdutoNome + " TEM SALDO " + produtoVer._QuantidadeEstoque + " EM ESTOQUE.";
                        Mensagem(mensagem, this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                    else
                    {
                        produtoBO.Salvar(produto);

                        if (produto._ProdutoID == 0)
                        {
                            Mensagem("Produto Salvo com Sucesso.", this);
                        }
                        else
                        {
                            Mensagem("Produto Atualizado com Sucesso.", this);
                        }

                        if (produto._ProdutoID == 0)
                        {
                            //Buscar o último produto do registro para adicionar no item
                            Produto produto2 = new Produto();
                            ProdutoBO produtoBO2 = new ProdutoBO();

                            produto2 = produtoBO2.BuscarPorUltimoProdutoCadastrado();


                            //adicionar os produtos no item
                            requisicao = new Requisicao();
                            ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                            ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                            int produtoID = Convert.ToInt32(produto2._ProdutoID);

                            itemRequisicao._Produto._ProdutoID = produtoID;
                            itemRequisicao._Requisicao._RequisicaoID = Convert.ToInt32(txtRequisicaoID.Text);

                            itemRequisicaoBO.Salvar(itemRequisicao);
                                                       
                        }

                        //mostar todos os itens da requisição
                        IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                        ItemRequisicaoBO itemRequisicaoBOBuscar = new ItemRequisicaoBO();

                        listaItemRequisicao = itemRequisicaoBOBuscar.BuscarItensDaRequisicao(Convert.ToInt32(txtRequisicaoID.Text));
                        gvItemRequisicao.DataSource = listaItemRequisicao;
                        gvItemRequisicao.DataBind();

                        LimparFormularioProduto();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
                    }
                }
                else
                {
                    produtoBO.Salvar(produto);

                    if (produto._ProdutoID == 0)
                    {
                        Mensagem("Produto Salvo com Sucesso.", this);
                    }
                    else
                    {
                        Mensagem("Produto Atualizado com Sucesso.", this);
                    }

                    if (produto._ProdutoID == 0)
                    {
                        //Buscar o último produto do registro para adicionar no item
                        Produto produto2 = new Produto();
                        ProdutoBO produtoBO2 = new ProdutoBO();

                        produto2 = produtoBO2.BuscarPorUltimoProdutoCadastrado();


                        //adicionar os produtos no item
                        requisicao = new Requisicao();
                        ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                        ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                        int produtoID = Convert.ToInt32(produto2._ProdutoID);

                        itemRequisicao._Produto._ProdutoID = produtoID;
                        itemRequisicao._Requisicao._RequisicaoID = Convert.ToInt32(txtRequisicaoID.Text);

                        itemRequisicaoBO.Salvar(itemRequisicao);
                                               
                    }

                    //mostar todos os itens da requisição
                    IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                    ItemRequisicaoBO itemRequisicaoBOBuscar = new ItemRequisicaoBO();

                    listaItemRequisicao = itemRequisicaoBOBuscar.BuscarItensDaRequisicao(Convert.ToInt32(txtRequisicaoID.Text));
                    gvItemRequisicao.DataSource = listaItemRequisicao;
                    gvItemRequisicao.DataBind();

                    LimparFormularioProduto();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
                }
                              
                
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
        }

        protected void lkbBuscarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBO produtoBO = new ProdutoBO();
                IList<Produto> listaProduto = new List<Produto>();

                if (!string.IsNullOrEmpty(txtBuscarProdutoPorCodigo.Text))
                {
                    listaProduto = produtoBO.BuscarPorCodigo(txtBuscarProdutoPorCodigo.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarProdutoPorNome.Text))
                {
                    listaProduto = produtoBO.BuscarPorNome(txtBuscarProdutoPorNome.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
                    }
                }
                else
                {
                    listaProduto = produtoBO.BuscarTodosProdutos();
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //adicionar os produtos no item
                requisicao = new Requisicao();
                ItemRequisicao itemRequisicao = new ItemRequisicao(requisicao);
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                int produtoID = Convert.ToInt32(gvProduto.SelectedDataKey.Value);

                itemRequisicao._Produto._ProdutoID = produtoID;
                itemRequisicao._Requisicao._RequisicaoID = Convert.ToInt32(txtRequisicaoID.Text);

                itemRequisicaoBO.Salvar(itemRequisicao);


                //mostar todos os itens
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBOBuscar = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBOBuscar.BuscarItensDaRequisicao(Convert.ToInt32(txtRequisicaoID.Text));
                gvItemRequisicao.DataSource = listaItemRequisicao;
                gvItemRequisicao.DataBind();

                Mensagem("Produto Adicionado com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemRequisicaoModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemRequisicaoModal();", true);
        }

        #endregion

        #region Eventos da Conta

        protected void lkbSalvarConta_Click(object sender, EventArgs e)
        {
            try
            {
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                conta._ContaID = Convert.ToInt32(hdContaModalID.Value);
                conta._ContaDescricao = txtContaDescricao.Text;
                conta._ContaNumero = txtContaNumeroModal.Text;
                conta._DataCadastro = txtDataCadastroConta.Text;

                contaBO.Salvar(conta);

                Mensagem("Conta Salva com Sucesso.", this);

                LimparFormularioConta();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarConta_Click(object sender, EventArgs e)
        {
            LimparFormularioConta();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarConta_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBO contaBO = new ContaBO();
                IList<Conta> listaConta = new List<Conta>();

                if (!string.IsNullOrEmpty(txtBuscarContaPorNumero.Text))
                {
                    listaConta = contaBO.BuscarPorNumero(txtBuscarContaPorNumero.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorNumero.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorNumero.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else if (!string.IsNullOrEmpty(txtBuscarContaPorDescricao.Text))
                {
                    listaConta = contaBO.BuscarPorDescricao(txtBuscarContaPorDescricao.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
                else
                {
                    listaConta = contaBO.BuscarTodasContas();
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                int id = Convert.ToInt32(gvConta.SelectedDataKey.Value);
                conta = contaBO.BuscarPorID(id);

                hdContaIDProdutoNome.Value = conta._ContaID.ToString();
                txtContaProdutoNome.Text = conta._ContaDescricao;
                txtContaNumeroProdutoNome.Text = conta._ContaNumero;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos da Unidade

        protected void lkbSalvarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                unidade._UnidadeID = Convert.ToInt32(hdUnidadeModalID.Value);
                unidade._DataCadastro = txtDataCadastroUnidade.Text;
                unidade._UnidadeDescricao = txtUnidadeDescricaoModal.Text;

                unidadeBO.Salvar(unidade);

                Mensagem("Unidade Salva com Sucesso.", this);

                LimparFormularioUnidade();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarUnidade_Click(object sender, EventArgs e)
        {
            LimparFormularioUnidade();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                UnidadeBO unidadeBO = new UnidadeBO();
                IList<Unidade> listaUnidade = new List<Unidade>();

                if (!string.IsNullOrEmpty(txtBuscarUnidadePorDescricao.Text))
                {
                    listaUnidade = unidadeBO.BuscarPorDescricao(txtBuscarUnidadePorDescricao.Text);
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else
                {
                    listaUnidade = unidadeBO.BuscarTodasUnidades();
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                int id = Convert.ToInt32(gvUnidade.SelectedDataKey.Value);
                unidade = unidadeBO.BuscarPorID(id);

                hdUnidadeIDProdutoNome.Value = unidade._UnidadeID.ToString();
                txtUnidadeDescricaoProdutoNome.Text = unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do nome do Produto)

        protected void lkbSalvarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                nomeProduto._NomeProdutoID = Convert.ToInt32(hdNomeProdutoID.Value);
                nomeProduto._Codigo = txtCodigoModal.Text;
                nomeProduto._DataCadastro = txtDataCadastroNomeProduto.Text;
                nomeProduto._ProdutoNome = txtProdutoNomeModal.Text;
                nomeProduto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitarioProdutoNome.Text);

                nomeProduto._Conta._ContaID = Convert.ToInt32(hdContaIDProdutoNome.Value);
                nomeProduto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeIDProdutoNome.Value);

                nomeProdutoBO.Salvar(nomeProduto);

                Mensagem("Nome do Produto Salvo com Sucesso.", this);

                LimparFormularioNomeProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarNomeProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioNomeProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbVoltarNomeProduto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbBuscarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();
                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorCodigo.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorCodigo(txtBuscarNomeProdutoPorCodigo.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorNome.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorNome(txtBuscarNomeProdutoPorNome.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else
                {
                    listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                int id = Convert.ToInt32(gvNomeProduto.SelectedDataKey.Value);
                nomeProduto = nomeProdutoBO.BuscarPorID(id);

                txtCodigo.Text = nomeProduto._Codigo;
                txtProdutoNome.Text = nomeProduto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = nomeProduto._ProdutoPrecoUnitario.ToString();

                hdContaID.Value = nomeProduto._Conta._ContaID.ToString();
                txtConta.Text = nomeProduto._Conta._ContaDescricao;
                txtContaNumero.Text = nomeProduto._Conta._ContaNumero;

                hdUnidadeID.Value = nomeProduto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = nomeProduto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #endregion


    }
}