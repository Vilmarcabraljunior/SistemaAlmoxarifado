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
    public partial class pgRequisitanteNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvRequisitante.DataSource = null;
            gvRequisitante.DataBind();
        }

        public void LimparFormulario()
        {
            lblRequisitanteNovoTitulo.Text = "Novo Requisitante";
            lblRequisitanteNovoTitulo.CssClass = "fa fa-plus-circle";

            hdRequisitanteID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtCodigo.Text = string.Empty;
            txtRequisitanteNome.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Requisitante

        Requisitante requisitante;
        RequisitanteBO requisitanteBO;
        IList<Requisitante> listaRequisitante;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoRequisitanteModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                requisitante = new Requisitante();

                requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteID.Value);
                requisitante._DataCadastro = txtDataCadastro.Text;
                requisitante._Codigo = txtCodigo.Text;
                requisitante._RequisitanteNome = txtRequisitanteNome.Text;

                requisitanteBO = new RequisitanteBO();
                requisitanteBO.Salvar(requisitante);

                if (requisitante._RequisitanteID != 0)
                {
                    if (gvRequisitante.Rows.Count == 1)
                    {
                        int id = requisitante._RequisitanteID;
                        requisitante = requisitanteBO.BuscarPorID(id);

                        listaRequisitante = new List<Requisitante>();
                        listaRequisitante.Add(requisitante);

                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();
                    }
                    else if (gvRequisitante.Rows.Count > 1)
                    {
                        listaRequisitante = new List<Requisitante>();
                        listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);

                    Mensagem("Requisitante Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Requisitante Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoRequisitanteModal();", true);
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
                requisitante = new Requisitante();
                requisitanteBO = new RequisitanteBO();

                requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteID.Value);
                requisitanteBO.Excluir(requisitante);

                Mensagem("Requisitante Excluído com Sucesso.", this);

                if (gvRequisitante.Rows.Count == 1)
                {
                    int id = requisitante._RequisitanteID;
                    requisitante = requisitanteBO.BuscarPorID(id);
                    gvRequisitante.DataSource = requisitante;
                    gvRequisitante.DataBind();
                }
                else if (gvRequisitante.Rows.Count > 1)
                {
                    listaRequisitante = new List<Requisitante>();
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    gvRequisitante.DataSource = listaRequisitante;
                    gvRequisitante.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);

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
                requisitanteBO = new RequisitanteBO();
                listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvRequisitante.DataSource = listaRequisitante;
                    gvRequisitante.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvRequisitante.DataSource = listaRequisitante;
                    gvRequisitante.DataBind();

                    txtBuscarPorNome.Text = string.Empty;
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    gvRequisitante.DataSource = listaRequisitante;
                    gvRequisitante.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
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
                requisitante = new Requisitante();
                requisitanteBO = new RequisitanteBO();

                int id = Convert.ToInt32(gvRequisitante.SelectedDataKey.Value);
                requisitante = requisitanteBO.BuscarPorID(id);

                hdRequisitanteID.Value = requisitante._RequisitanteID.ToString();
                txtDataCadastro.Text = requisitante._DataCadastro;
                txtCodigo.Text = requisitante._Codigo;
                txtRequisitanteNome.Text = requisitante._RequisitanteNome;

                lblRequisitanteNovoTitulo.Text = "Atualizar Requisitante";
                lblRequisitanteNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoRequisitanteModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        #endregion
             
    }
}