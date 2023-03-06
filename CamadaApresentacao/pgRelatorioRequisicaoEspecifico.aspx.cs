using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CamadaNegocio.MODEL;
using CamadaNegocio.BO;

namespace CamadaApresentacao
{
    public partial class pgRelatorioRequisicaoEspecifico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region (Métodos Auxiliáres)
       
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        
        public void CalcularValorTotalGeralItemRequisicao()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemRequisicao.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[7].Text != null && row.Cells[7].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[7].Text);
                    }

                }
            }
            lblValorTotalGeral.Text = ValorTotal.ToString("C2");
        }

        public void LimparFormularioRelatorio()
        {
            lblRequisicaoID.Text = string.Empty;
            lblDataCadastro.Text = string.Empty;
            lblCodigo.Text = string.Empty;

            lblRequisitanteCodigo.Text = string.Empty;
            lblRequisitante.Text = string.Empty;

            lblEnderecoCodigo.Text = string.Empty;
            lblEndereco.Text = string.Empty;

            txtRequisicaoObservacao.Text = string.Empty;

            gvItemRequisicao.DataSource = null;
            gvItemRequisicao.DataBind();

            lblValorTotalGeral.Text = string.Empty;
        }
        #endregion

        #region (Métodos Principais)

        //Buscar Requisição
        protected void lkbBuscarRequisicao_Click(object sender, EventArgs e)
        {
            try
            {
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaRequisicao = requisicaoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaRequisicao = requisicaoBO.BuscarPorDataCadastro(txtBuscarPorData.Text);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaRequisicao = requisicaoBO.BuscarDataCadastroPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvRequisicao.DataSource = listaRequisicao;
                    gvRequisicao.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                }
                else
                {
                    listaRequisicao = requisicaoBO.BuscarTodasRequisicoes();
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
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                int situacaoID = Convert.ToInt32(gvBuscarRequisicaoPorSituacao.SelectedDataKey.Value);
                listaRequisicao = requisicaoBO.BuscarPorSituacao(situacaoID);

                gvRequisicao.DataSource = listaRequisicao;
                gvRequisicao.DataBind();

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

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                    gvBuscarRequisicaoPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarRequisicaoPorUsuario.DataSource = listaUsuario;
                    gvBuscarRequisicaoPorUsuario.DataBind();
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
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                int usuarioID = Convert.ToInt32(gvBuscarRequisicaoPorUsuario.SelectedDataKey.Value);
                listaRequisicao = requisicaoBO.BuscarPorUsuario(usuarioID);

                gvRequisicao.DataSource = listaRequisicao;
                gvRequisicao.DataBind();

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
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                int requisitanteID = Convert.ToInt32(gvBuscarRequisicaoPorRequisitante.SelectedDataKey.Value);
                listaRequisicao = requisicaoBO.BuscarPorRequisitante(requisitanteID);

                gvRequisicao.DataSource = listaRequisicao;
                gvRequisicao.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisicaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //GridView para buscar requisição e jogar os dados nas labaels
        protected void gvRequisicao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Requisicao requisicao = new Requisicao();
                RequisicaoBO requisicaoBO = new RequisicaoBO();

                int requisicaoID = Convert.ToInt32(gvRequisicao.SelectedDataKey.Value);
                requisicao = requisicaoBO.BuscarPorID(requisicaoID);

                lblRequisicaoID.Text = requisicao._RequisicaoID.ToString();
                lblDataCadastro.Text = requisicao._DataCadastro;
                lblCodigo.Text = requisicao._Codigo;

                lblRequisitanteCodigo.Text = requisicao._Requisitante._Codigo;
                lblRequisitante.Text = requisicao._Requisitante._RequisitanteNome;

                lblEnderecoCodigo.Text = requisicao._Endereco._Codigo;
                lblEndereco.Text = requisicao._Endereco._EnderecoDescricao;

                txtRequisicaoObservacao.Text = requisicao._RequisicaoObservacao;

                //mostar todos os itens da requisição.
                IList<ItemRequisicao> listaItemRequisicao = new List<ItemRequisicao>();
                ItemRequisicaoBO itemRequisicaoBO = new ItemRequisicaoBO();

                listaItemRequisicao = itemRequisicaoBO.BuscarItensDaRequisicao(requisicaoID);
                gvItemRequisicao.DataSource = listaItemRequisicao;
                gvItemRequisicao.DataBind();

                //calcular valor total geral dos detalhes do item da requisição
                CalcularValorTotalGeralItemRequisicao();
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

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
                      
    }
}