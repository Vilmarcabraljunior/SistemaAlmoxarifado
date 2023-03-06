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
    public partial class pgRelatorioEntradaMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region (Métodos Auxiliáres)

        public void LimparFormularioRelatorio()
        {
            lblEntradaMaterialID.Text = string.Empty;
            lblDataCadastro.Text = string.Empty;

            lblFornecedor.Text = string.Empty;

            lblProcesso.Text = string.Empty;

            txtEntradaMaterialObservacao.Text = string.Empty;

            gvItemEntradaMaterial.DataSource = null;
            gvItemEntradaMaterial.DataBind();

            lblValorTotalGeral.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        public void CalcularValorTotalGeralItemEntradaMaterial()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemEntradaMaterial.Rows)
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
                EntradaMaterialBO entradaMaterialBO = new EntradaMaterialBO();
                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarEntradaDataPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;

                }
                else if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarPorEntradaData(txtBuscarPorData.Text);
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else
                {
                    listaEntradaMaterial = entradaMaterialBO.BuscarTodasEntradasMaterial();
                    gvEntradaMaterial.DataSource = listaEntradaMaterial;
                    gvEntradaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);

            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        
        protected void lkbBuscarEntradaMaterialPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarEntradaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarEntradaMaterialPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarEntradaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarEntradaMaterialPorUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarEntradaMaterialPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarEntradaMaterialPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EntradaMaterialBO entradaMaterialBO = new EntradaMaterialBO();
                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                int usuarioID = Convert.ToInt32(gvBuscarEntradaMaterialPorUsuario.SelectedDataKey.Value);
                listaEntradaMaterial = entradaMaterialBO.BuscarPorUsuario(usuarioID);

                gvEntradaMaterial.DataSource = listaEntradaMaterial;
                gvEntradaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarEntradaMaterialPorFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                FornecedorBO fornecedorBO = new FornecedorBO();
                IList<Fornecedor> listaFornecedor = new List<Fornecedor>();

                if (!string.IsNullOrEmpty(txtBuscarPorFornecedor.Text))
                {
                    listaFornecedor = fornecedorBO.BuscarPorNome(txtBuscarPorFornecedor.Text);
                    gvBuscarEntradaMaterialPorFornecedor.DataSource = listaFornecedor;
                    gvBuscarEntradaMaterialPorFornecedor.DataBind();

                    txtBuscarPorFornecedor.Text = string.Empty;
                }
                else
                {
                    listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                    gvBuscarEntradaMaterialPorFornecedor.DataSource = listaFornecedor;
                    gvBuscarEntradaMaterialPorFornecedor.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarEntradaMaterialPorFornecedorModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarEntradaMaterialPorFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EntradaMaterialBO entradaMaterialBO = new EntradaMaterialBO();
                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                int fornecedorID = Convert.ToInt32(gvBuscarEntradaMaterialPorFornecedor.SelectedDataKey.Value);
                listaEntradaMaterial = entradaMaterialBO.BuscarPorFornecedor(fornecedorID);

                gvEntradaMaterial.DataSource = listaEntradaMaterial;
                gvEntradaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewEntradaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvEntradaMaterial_SelectedIndexChanged1(object sender, EventArgs e)
        {

            EntradaMaterialBO entradaMaterialBO = new EntradaMaterialBO();
            EntradaMaterial entradaMaterial = new EntradaMaterial();

            int entradaMaterialID = Convert.ToInt32(gvEntradaMaterial.SelectedDataKey.Value);

            entradaMaterial = entradaMaterialBO.BuscarPorID(entradaMaterialID);
            lblEntradaMaterialID.Text = entradaMaterial._EntradaMaterialID.ToString();
            lblDataCadastro.Text = entradaMaterial._DataCadastro;
            lblFornecedor.Text = entradaMaterial._Fornecedor._FornecedorNome;
            lblProcesso.Text = entradaMaterial._Processo._ProcessoData + " - " + entradaMaterial._Processo._ProcessoNumero;
            txtEntradaMaterialObservacao.Text = entradaMaterial._Observacao;


            //Buscar os itens da entrada de material pelo id da entrada de material
            ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();
            IList<ItemEntradaMaterial> listaItemEntradMaterial = new List<ItemEntradaMaterial>();

            listaItemEntradMaterial = itemEntradaMaterialBO.BuscarItensDaEntradaMaterial(entradaMaterialID);
            gvItemEntradaMaterial.DataSource = listaItemEntradMaterial;
            gvItemEntradaMaterial.DataBind();

            CalcularValorTotalGeralItemEntradaMaterial();

        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion

    }
}