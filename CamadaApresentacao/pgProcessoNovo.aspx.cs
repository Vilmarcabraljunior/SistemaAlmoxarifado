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
    public partial class pgProcessoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvProcesso.DataSource = null;
            gvProcesso.DataBind();
        }

        public void LimparFormulario()
        {
            lblProcessoNovoTitulo.Text = "Novo Processo";
            lblProcessoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdProcessoID.Value = "0";
            txtProcessoData.Text = string.Empty;
            txtProcessoNumero.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Processo

        Processo processo;
        ProcessoBO processoBO;
        IList<Processo> listaProcesso;

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                processo = new Processo();

                processo._ProcessoID = Convert.ToInt32(hdProcessoID.Value);
                processo._DataCadastro = DateTime.Now.ToLongDateString();
                processo._ProcessoData = txtProcessoData.Text;
                processo._ProcessoNumero = txtProcessoNumero.Text;

                processoBO = new ProcessoBO();
                processoBO.Salvar(processo);

                if (processo._ProcessoID != 0)
                {
                    if (gvProcesso.Rows.Count == 1)
                    {
                        int id = processo._ProcessoID;
                        processo = processoBO.BuscarPorID(id);

                        listaProcesso = new List<Processo>();
                        listaProcesso.Add(processo);

                        gvProcesso.DataSource = listaProcesso;
                        gvProcesso.DataBind();
                    }
                    else if (gvProcesso.Rows.Count > 1)
                    {
                        listaProcesso = new List<Processo>();
                        listaProcesso = processoBO.BuscarTodosProcessos();
                        gvProcesso.DataSource = listaProcesso;
                        gvProcesso.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);

                    Mensagem("Processo Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Processo Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProcessoModal();", true);
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
                processo = new Processo();
                processoBO = new ProcessoBO();

                processo._ProcessoID = Convert.ToInt32(hdProcessoID.Value);
                processoBO.Excluir(processo);

                Mensagem("Processo Excluído com Sucesso.", this);

                if (gvProcesso.Rows.Count == 1)
                {
                    int id = processo._ProcessoID;
                    processo = processoBO.BuscarPorID(id);
                    gvProcesso.DataSource = processo;
                    gvProcesso.DataBind();
                }
                else if (gvProcesso.Rows.Count > 1)
                {
                    listaProcesso = new List<Processo>();
                    listaProcesso = processoBO.BuscarTodosProcessos();
                    gvProcesso.DataSource = listaProcesso;
                    gvProcesso.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);

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
                processoBO = new ProcessoBO();
                listaProcesso = new List<Processo>();

                if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaProcesso = processoBO.BuscarPorData(txtBuscarPorData.Text);
                    gvProcesso.DataSource = listaProcesso;
                    gvProcesso.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorNumero.Text))
                {
                    listaProcesso = processoBO.BuscarPorNumero(txtBuscarPorNumero.Text);
                    gvProcesso.DataSource = listaProcesso;
                    gvProcesso.DataBind();

                    txtBuscarPorNumero.Text = string.Empty;
                }
                else
                {
                    listaProcesso = processoBO.BuscarTodosProcessos();
                    gvProcesso.DataSource = listaProcesso;
                    gvProcesso.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProcessoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvProcesso_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                processo = new Processo();
                processoBO = new ProcessoBO();

                int id = Convert.ToInt32(gvProcesso.SelectedDataKey.Value);
                processo = processoBO.BuscarPorID(id);

                hdProcessoID.Value = processo._ProcessoID.ToString();
                txtProcessoData.Text = processo._ProcessoData;
                txtProcessoNumero.Text = processo._ProcessoNumero;

                lblProcessoNovoTitulo.Text = "Atualizar Processo";
                lblProcessoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProcessoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
    }
}