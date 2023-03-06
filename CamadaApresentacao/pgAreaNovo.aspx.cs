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
    public partial class pgAreaNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvArea.DataSource = null;
            gvArea.DataBind();
        }

        public void LimparFormulario()
        {
            lblAreaNovoTitulo.Text = "Nova Área";
            lblAreaNovoTitulo.CssClass = "fa fa-plus-circle";

            hdAreaID.Value = "0";
            txtAreaNome.Text = string.Empty;
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Área

        Area area;
        AreaBO areaBO;
        IList<Area> listaArea;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaAreaModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                area = new Area();

                area._AreaID = Convert.ToInt32(hdAreaID.Value);
                area._AreaNome = txtAreaNome.Text;
                area._DataCadastro = txtDataCadastro.Text;

                areaBO = new AreaBO();
                areaBO.Salvar(area);

                if (area._AreaID != 0)
                {
                    if (gvArea.Rows.Count == 1)
                    {
                        int id = area._AreaID;
                        area = areaBO.BuscarPorID(id);

                        listaArea = new List<Area>();
                        listaArea.Add(area);

                        gvArea.DataSource = listaArea;
                        gvArea.DataBind();
                    }
                    else if (gvArea.Rows.Count > 1)
                    {
                        listaArea = new List<Area>();
                        listaArea = areaBO.BuscarTodasAreas();
                        gvArea.DataSource = listaArea;
                        gvArea.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewAreaModal();", true);

                    Mensagem("Área Atualizada com Sucesso.", this);
                }
                else
                {
                    Mensagem("Área Salva com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", " openNovaAreaModal();", true);
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
                area = new Area();
                areaBO = new AreaBO();

                area._AreaID = Convert.ToInt32(hdAreaID.Value);
                areaBO.Excluir(area);

                Mensagem("Área Excluída com Sucesso.", this);

                if (gvArea.Rows.Count == 1)
                {
                    int id = area._AreaID;
                    area = areaBO.BuscarPorID(id);
                    gvArea.DataSource = area;
                    gvArea.DataBind();
                }
                else if (gvArea.Rows.Count > 1)
                {
                    listaArea = new List<Area>();
                    listaArea = areaBO.BuscarTodasAreas();
                    gvArea.DataSource = listaArea;
                    gvArea.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewAreaModal();", true);

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
                areaBO = new AreaBO();
                listaArea = new List<Area>();

                if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaArea = areaBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvArea.DataSource = listaArea;
                    gvArea.DataBind();

                    txtBuscarPorNome.Text = string.Empty;
                }
                else
                {
                    listaArea = areaBO.BuscarTodasAreas();
                    gvArea.DataSource = listaArea;
                    gvArea.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewAreaModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                area = new Area();
                areaBO = new AreaBO();

                int id = Convert.ToInt32(gvArea.SelectedDataKey.Value);
                area = areaBO.BuscarPorID(id);

                hdAreaID.Value = area._AreaID.ToString();
                txtAreaNome.Text = area._AreaNome;
                txtDataCadastro.Text = area._DataCadastro;

                lblAreaNovoTitulo.Text = "Atualizar Área";
                lblAreaNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaAreaModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

  
    }
}