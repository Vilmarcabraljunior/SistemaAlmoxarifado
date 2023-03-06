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
    public partial class pgRelatorioSaidaMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        
        #region (Métodos Auxiliáres)

        public void LimparFormularioRelatorio()
        {
            lblSaidaMaterialID.Text = string.Empty;
            lblDataCadastro.Text = string.Empty;

            lblCentroCusto.Text = string.Empty;

            lblRequisitante.Text = string.Empty;

            txtSaidaMaterialObservacao.Text = string.Empty;

            gvItemSaidaMaterial.DataSource = null;
            gvItemSaidaMaterial.DataBind();

            lblValorTotalGeral.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        public void CalcularValorTotalGeralItemSaidaMaterial()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemSaidaMaterial.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[6].Text != null && row.Cells[6].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[6].Text);
                    }

                }
            }
            lblValorTotalGeral.Text = ValorTotal.ToString("C2");
        }

        #endregion

        #region (Métodos Principais)

        protected void lkbBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                SaidaMaterialBO saidaMaterialBO = new SaidaMaterialBO();
                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarSaidaDataPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;

                }
                else if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarPorSaidaData(txtBuscarPorData.Text);
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarTodasSaidasMaterial();
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        
        protected void lkbBuscarSaidaMaterialPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarSaidaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarSaidaMaterialPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarSaidaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarSaidaMaterialPorUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarSaidaMaterialPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarSaidaMaterialPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaidaMaterialBO saidaMaterialBO = new SaidaMaterialBO();
                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                int usuarioID = Convert.ToInt32(gvBuscarSaidaMaterialPorUsuario.SelectedDataKey.Value);
                listaSaidaMaterial = saidaMaterialBO.BuscarPorUsuario(usuarioID);

                gvSaidaMaterial.DataSource = listaSaidaMaterial;
                gvSaidaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarSaidaMaterialPorRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitanteBO requisitanteBO = new RequisitanteBO();
                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarPorRequisitante.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarPorRequisitante.Text);
                    gvBuscarSaidaMaterialPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarSaidaMaterialPorRequisitante.DataBind();

                    txtBuscarPorRequisitante.Text = string.Empty;
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    gvBuscarSaidaMaterialPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarSaidaMaterialPorRequisitante.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarSaidaMaterialPorRequisitanteModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarSaidaMaterialPorRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SaidaMaterialBO saidaMaterialBO = new SaidaMaterialBO();
                IList<SaidaMaterial> listaSaidaMaterial = new List<SaidaMaterial>();

                int requisitanteID = Convert.ToInt32(gvBuscarSaidaMaterialPorRequisitante.SelectedDataKey.Value);
                listaSaidaMaterial = saidaMaterialBO.BuscarPorRequisitante(requisitanteID);

                gvSaidaMaterial.DataSource = listaSaidaMaterial;
                gvSaidaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvSaidaMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {

            SaidaMaterialBO saidaMaterialBO = new SaidaMaterialBO();
            SaidaMaterial saidaMaterial = new SaidaMaterial();

            int saidaMaterialID = Convert.ToInt32(gvSaidaMaterial.SelectedDataKey.Value);

            saidaMaterial = saidaMaterialBO.BuscarPorID(saidaMaterialID);
            lblSaidaMaterialID.Text = saidaMaterial._SaidaMaterialID.ToString();
            lblDataCadastro.Text = saidaMaterial._DataCadastro;
            lblCentroCusto.Text = saidaMaterial._CentroDeCusto._Descricao;
            lblRequisitante.Text = saidaMaterial._Requisitante._RequisitanteNome;
            txtSaidaMaterialObservacao.Text = saidaMaterial._Observacao;


            //Buscar os itens da saída de material pelo id da saída de material
            ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();
            IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();

            listaItemSaidaMaterial = itemSaidaMaterialBO.BuscarItensDaSaidaMaterial(saidaMaterialID);
            gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
            gvItemSaidaMaterial.DataBind();

            CalcularValorTotalGeralItemSaidaMaterial();

        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }   

        #endregion
            
    }
}