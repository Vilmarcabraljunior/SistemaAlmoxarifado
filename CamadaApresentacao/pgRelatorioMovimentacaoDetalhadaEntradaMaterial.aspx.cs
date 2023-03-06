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
    public partial class pgRelatorioMovimentacaoDetalhadaEntradaMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region (Métodos Auxiliáres)

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        public void CalcularValorTotalGeralEntradaMaterial()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvEntradaMaterial.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[3].Text != null && row.Cells[3].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[3].Text);
                    }

                }
            }
            lblValorTotalGeral.Text = ValorTotal.ToString("C2");
            lblValorTotalGeralInvisivel.Text = ValorTotal.ToString();
        }

        public void CalcularValorTotalGeralEntradaMaterialExtra()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvEntradaMaterialExtra.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[3].Text != null && row.Cells[3].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[3].Text);
                    }

                }
            }
            lblValorTotalGeralExtra.Text = ValorTotal.ToString("C2");
            lblValorTotalGeralExtraInvisivel.Text = ValorTotal.ToString();
              
        }

        public void SomarValorOrçamenatarioeExtra()
        {
            decimal valorTotal = Convert.ToDecimal(lblValorTotalGeralInvisivel.Text) + Convert.ToDecimal(lblValorTotalGeralExtraInvisivel.Text);

            lblSomaOrçamentariaExtra.Text = valorTotal.ToString("C2");
        }

        public void LimparFormularioRelatorio()
        {
            lblDataInicial.Text = string.Empty;
            lblDataFinal.Text = string.Empty;

            gvEntradaMaterial.DataSource = null;
            gvEntradaMaterial.DataBind();

            gvEntradaMaterialExtra.DataSource = null;
            gvEntradaMaterialExtra.DataBind();

            lblValorTotalGeral.Text = string.Empty;
            lblValorTotalGeralExtra.Text = string.Empty;
            lblValorTotalGeralInvisivel.Text = string.Empty;
            lblValorTotalGeralExtraInvisivel.Text = string.Empty;
            lblSomaOrçamentariaExtra.Text = string.Empty;
        }
        #endregion

        #region (Métodos Principais)

        //Buscar Saída de Material
        protected void lkbBuscarEntradaMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                EntradaMaterialBO entradaMaterialBO = new EntradaMaterialBO();
                IList<EntradaMaterial> listaEntradaMaterial = new List<EntradaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {

                    string dataInicial = "'" + txtBuscarPorDataInicial.Text + "'";
                    string dataFinal = "'" + txtBuscarPorDataFinal.Text + "'";

                    SqlDataSource1.SelectCommand = "select Conta.contaNumero as Codigo ,Conta.contaDescricao as Conta,Fornecedor.fornecedorNome as Fornecedor, SUM(Produto.produtoValorTotal) as Valor from EntradaMaterial, ItemEntradaMaterial, Produto, Conta, Fornecedor" +
                   " WHERE EntradaMaterial.entradaMaterialID = ItemEntradaMaterial.entradaMaterialID and ItemEntradaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and EntradaMaterial.fornecedorID = Fornecedor.fornecedorID" +
                   " and Produto.produtoTipo = 1 and CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + " GROUP BY  Conta.contaNumero, Conta.contaDescricao, Fornecedor.fornecedorNome ORDER BY Fornecedor.fornecedorNome";

                    SqlDataSource2.SelectCommand = "select Conta.contaNumero as Codigo ,Conta.contaDescricao as Conta,Fornecedor.fornecedorNome as Fornecedor, SUM(Produto.produtoValorTotal) as Valor from EntradaMaterial, ItemEntradaMaterial, Produto, Conta, Fornecedor" +
                   " WHERE EntradaMaterial.entradaMaterialID = ItemEntradaMaterial.entradaMaterialID and ItemEntradaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and EntradaMaterial.fornecedorID = Fornecedor.fornecedorID" +
                   " and Produto.produtoTipo = 2 and CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + " GROUP BY  Conta.contaNumero, Conta.contaDescricao, Fornecedor.fornecedorNome ORDER BY Fornecedor.fornecedorNome";

                    lblDataInicial.Text = txtBuscarPorDataInicial.Text;
                    lblDataFinal.Text = txtBuscarPorDataFinal.Text;

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                                  
                }
                else
                {
                    Mensagem("Selecione o período", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBuscarEntradaMaterialModal();", true);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para calcular o valor total geral atarvés do método rowdatabound
        protected void gvEntradaMaterial_DataBound(object sender, EventArgs e)
        {
            CalcularValorTotalGeralEntradaMaterial();
        }

        //Método para calcular o valor total geral atarvés do método rowdatabound
        protected void gvEntradaMaterialExtra_DataBound(object sender, EventArgs e)
        {
            CalcularValorTotalGeralEntradaMaterialExtra();

            SomarValorOrçamenatarioeExtra();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
                   
    }
}