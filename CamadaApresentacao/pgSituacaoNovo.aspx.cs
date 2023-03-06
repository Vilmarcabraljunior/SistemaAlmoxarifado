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
    public partial class pgSituacaoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvSituacao.DataSource = null;
            gvSituacao.DataBind();
        }

        public void LimparFormulario()
        {
            lblSituacaoNovoTitulo.Text = "Nova Situação";
            lblSituacaoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdSituacaoID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtSituacaoNome.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Situação

        Situacao situacao;
        SituacaoBO situacaoBO;
        IList<Situacao> listaSituacao;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSituacaoModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                situacao = new Situacao();

                situacao._SituacaoID = Convert.ToInt32(hdSituacaoID.Value);
                situacao._DataCadastro = txtDataCadastro.Text;
                situacao._SituacaoNome = txtSituacaoNome.Text;

                situacaoBO = new SituacaoBO();
                situacaoBO.Salvar(situacao);

                if (situacao._SituacaoID != 0)
                {
                    if (gvSituacao.Rows.Count == 1)
                    {
                        int id = situacao._SituacaoID;
                        situacao = situacaoBO.BuscarPorID(id);

                        listaSituacao = new List<Situacao>();
                        listaSituacao.Add(situacao);

                        gvSituacao.DataSource = listaSituacao;
                        gvSituacao.DataBind();
                    }
                    else if (gvSituacao.Rows.Count > 1)
                    {
                        listaSituacao = new List<Situacao>();
                        listaSituacao = situacaoBO.BuscarTodasSituacoes();
                        gvSituacao.DataSource = listaSituacao;
                        gvSituacao.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSituacaoModal();", true);

                    Mensagem("Situação Atualizada com Sucesso.", this);
                }
                else
                {
                    Mensagem("Situação Salva com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSituacaoModal();", true);
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
                situacao = new Situacao();
                situacaoBO = new SituacaoBO();

                situacao._SituacaoID = Convert.ToInt32(hdSituacaoID.Value);
                situacaoBO.Excluir(situacao);

                Mensagem("Situação Excluída com Sucesso.", this);

                if (gvSituacao.Rows.Count == 1)
                {
                    int id = situacao._SituacaoID;
                    situacao = situacaoBO.BuscarPorID(id);
                    gvSituacao.DataSource = situacao;
                    gvSituacao.DataBind();
                }
                else if (gvSituacao.Rows.Count > 1)
                {
                    listaSituacao = new List<Situacao>();
                    listaSituacao = situacaoBO.BuscarTodasSituacoes();
                    gvSituacao.DataSource = listaSituacao;
                    gvSituacao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSituacaoModal();", true);

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
                situacaoBO = new SituacaoBO();
                listaSituacao = new List<Situacao>();

                if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaSituacao = situacaoBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvSituacao.DataSource = listaSituacao;
                    gvSituacao.DataBind();

                    txtBuscarPorNome.Text = string.Empty;
                }
                else
                {
                    listaSituacao = situacaoBO.BuscarTodasSituacoes();
                    gvSituacao.DataSource = listaSituacao;
                    gvSituacao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSituacaoModal();", true);
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
                situacao = new Situacao();
                situacaoBO = new SituacaoBO();

                int id = Convert.ToInt32(gvSituacao.SelectedDataKey.Value);
                situacao = situacaoBO.BuscarPorID(id);

                hdSituacaoID.Value = situacao._SituacaoID.ToString();
                txtDataCadastro.Text = situacao._DataCadastro;
                txtSituacaoNome.Text = situacao._SituacaoNome;

                lblSituacaoNovoTitulo.Text = "Atualizar Situação";
                lblSituacaoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSituacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
          
    }
}