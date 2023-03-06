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
    public partial class pgUnidadeNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvUnidade.DataSource = null;
            gvUnidade.DataBind();
        }

        public void LimparFormulario()
        {
            lblUnidadeNovoTitulo.Text = "Nova Unidade";
            lblUnidadeNovoTitulo.CssClass = "fa fa-plus-circle";

            hdUnidadeID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtUnidadeDescricao.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Unidade

        Unidade unidade;
        UnidadeBO unidadeBO;
        IList<Unidade> listaUnidade;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaUnidadeModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                unidade = new Unidade();

                unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);
                unidade._DataCadastro = txtDataCadastro.Text;
                unidade._UnidadeDescricao = txtUnidadeDescricao.Text;

                unidadeBO = new UnidadeBO();
                unidadeBO.Salvar(unidade);

                if (unidade._UnidadeID != 0)
                {
                    if (gvUnidade.Rows.Count == 1)
                    {
                        int id = unidade._UnidadeID;
                        unidade = unidadeBO.BuscarPorID(id);

                        listaUnidade = new List<Unidade>();
                        listaUnidade.Add(unidade);

                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();
                    }
                    else if (gvUnidade.Rows.Count > 1)
                    {
                        listaUnidade = new List<Unidade>();
                        listaUnidade = unidadeBO.BuscarTodasUnidades();
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);

                    Mensagem("Unidade Atualizada com Sucesso.", this);
                }
                else
                {
                    Mensagem("Unidade Salva com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaUnidadeModal();", true);
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
                unidade = new Unidade();
                unidadeBO = new UnidadeBO();

                unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);
                unidadeBO.Excluir(unidade);

                Mensagem("Unidade Excluída com Sucesso.", this);

                if (gvUnidade.Rows.Count == 1)
                {
                    int id = unidade._UnidadeID;
                    unidade = unidadeBO.BuscarPorID(id);
                    gvUnidade.DataSource = unidade;
                    gvUnidade.DataBind();
                }
                else if (gvUnidade.Rows.Count > 1)
                {
                    listaUnidade = new List<Unidade>();
                    listaUnidade = unidadeBO.BuscarTodasUnidades();
                    gvUnidade.DataSource = listaUnidade;
                    gvUnidade.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);

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
                unidadeBO = new UnidadeBO();
                listaUnidade = new List<Unidade>();

                if (!string.IsNullOrEmpty(txtBuscarPorDescricao.Text))
                {
                    listaUnidade = unidadeBO.BuscarPorDescricao(txtBuscarPorDescricao.Text);
                    gvUnidade.DataSource = listaUnidade;
                    gvUnidade.DataBind();

                    txtBuscarPorDescricao.Text = string.Empty;
                }
                else
                {
                    listaUnidade = unidadeBO.BuscarTodasUnidades();
                    gvUnidade.DataSource = listaUnidade;
                    gvUnidade.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
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
                unidade = new Unidade();
                unidadeBO = new UnidadeBO();

                int id = Convert.ToInt32(gvUnidade.SelectedDataKey.Value);
                unidade = unidadeBO.BuscarPorID(id);

                hdUnidadeID.Value = unidade._UnidadeID.ToString();
                txtDataCadastro.Text = unidade._DataCadastro;
                txtUnidadeDescricao.Text = unidade._UnidadeDescricao;

                lblUnidadeNovoTitulo.Text = "Atualizar Unidade";
                lblUnidadeNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaUnidadeModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
          
    }
}