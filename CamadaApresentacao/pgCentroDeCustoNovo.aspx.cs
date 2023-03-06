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
    public partial class pgCentroDeCustoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvCentroDeCusto.DataSource = null;
            gvCentroDeCusto.DataBind();
        }

        public void LimparFormulario()
        {
            lblCentroDeCustoNovoTitulo.Text = "Novo Centro de Custo";
            lblCentroDeCustoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdCentroDeCustoID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtCodigo.Text = string.Empty;
            txtDescricao.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Centro de Custo

        CentroDeCusto centroDeCusto;
        CentroDeCustoBO centroDeCustoBO;
        IList<CentroDeCusto> listaCentroDeCusto;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoCentroDeCustoModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                centroDeCusto = new CentroDeCusto();

                centroDeCusto._CentroDeCustoID = Convert.ToInt32(hdCentroDeCustoID.Value);
                centroDeCusto._DataCadastro = txtDataCadastro.Text;
                centroDeCusto._Codigo = txtCodigo.Text;
                centroDeCusto._Descricao = txtDescricao.Text;

                centroDeCustoBO = new CentroDeCustoBO();
                centroDeCustoBO.Salvar(centroDeCusto);

                if (centroDeCusto._CentroDeCustoID != 0)
                {
                    if (gvCentroDeCusto.Rows.Count == 1)
                    {
                        int id = centroDeCusto._CentroDeCustoID;
                        centroDeCusto = centroDeCustoBO.BuscarPorID(id);

                        listaCentroDeCusto = new List<CentroDeCusto>();
                        listaCentroDeCusto.Add(centroDeCusto);

                        gvCentroDeCusto.DataSource = listaCentroDeCusto;
                        gvCentroDeCusto.DataBind();
                    }
                    else if (gvCentroDeCusto.Rows.Count > 1)
                    {
                        listaCentroDeCusto = new List<CentroDeCusto>();
                        listaCentroDeCusto = centroDeCustoBO.BuscarTodosCentrosDeCusto();
                        gvCentroDeCusto.DataSource = listaCentroDeCusto;
                        gvCentroDeCusto.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);

                    Mensagem("Centro de Custo Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Centro de Custo Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoCentroDeCustoModal();", true);
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
                centroDeCusto = new CentroDeCusto();
                centroDeCustoBO = new CentroDeCustoBO();

                centroDeCusto._CentroDeCustoID = Convert.ToInt32(hdCentroDeCustoID.Value);
                centroDeCustoBO.Excluir(centroDeCusto);

                Mensagem("Centro de Custo Excluído com Sucesso.", this);

                if (gvCentroDeCusto.Rows.Count == 1)
                {
                    int id = centroDeCusto._CentroDeCustoID;
                    centroDeCusto = centroDeCustoBO.BuscarPorID(id);
                    gvCentroDeCusto.DataSource = centroDeCusto;
                    gvCentroDeCusto.DataBind();
                }
                else if (gvCentroDeCusto.Rows.Count > 1)
                {
                    listaCentroDeCusto = new List<CentroDeCusto>();
                    listaCentroDeCusto = centroDeCustoBO.BuscarTodosCentrosDeCusto();
                    gvCentroDeCusto.DataSource = listaCentroDeCusto;
                    gvCentroDeCusto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);

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
                centroDeCustoBO = new CentroDeCustoBO();
                listaCentroDeCusto = new List<CentroDeCusto>();

                if (!string.IsNullOrEmpty(txtBuscarPorCodigo.Text))
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarPorCodigo(txtBuscarPorCodigo.Text);
                    gvCentroDeCusto.DataSource = listaCentroDeCusto;
                    gvCentroDeCusto.DataBind();

                    txtBuscarPorCodigo.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDescricao.Text))
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarPorDescricao(txtBuscarPorDescricao.Text);
                    gvCentroDeCusto.DataSource = listaCentroDeCusto;
                    gvCentroDeCusto.DataBind();

                    txtBuscarPorDescricao.Text = string.Empty;
                }
                else
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarTodosCentrosDeCusto();
                    gvCentroDeCusto.DataSource = listaCentroDeCusto;
                    gvCentroDeCusto.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvCentroDeCusto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                centroDeCusto = new CentroDeCusto();
                centroDeCustoBO = new CentroDeCustoBO();

                int id = Convert.ToInt32(gvCentroDeCusto.SelectedDataKey.Value);
                centroDeCusto = centroDeCustoBO.BuscarPorID(id);

                hdCentroDeCustoID.Value = centroDeCusto._CentroDeCustoID.ToString();
                txtDataCadastro.Text = centroDeCusto._DataCadastro;
                txtCodigo.Text = centroDeCusto._Codigo;
                txtDescricao.Text = centroDeCusto._Descricao;

                lblCentroDeCustoNovoTitulo.Text = "Atualizar Centro de Custo";
                lblCentroDeCustoNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoCentroDeCustoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        #endregion

        
    }
}