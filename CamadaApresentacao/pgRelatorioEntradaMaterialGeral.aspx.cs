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
    public partial class pgRelatorioEntradaMaterialGeral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region (Métodos Auxiliáres)

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
                    if (row.Cells[7].Text != null && row.Cells[7].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[7].Text);
                    }

                }
            }
            lblValorTotalGeral.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralItemEntradaMaterialTotalPorFornecedor()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemEntradaMaterialTotalPorFornecedor.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralTotalPorFornecedor.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralItemEntradaMaterialQtdeTotalPorFornecedor()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemEntradaMaterialTotalPorFornecedor.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[1].Text != null && row.Cells[1].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[1].Text);
                    }

                }
            }
            lblValorTotalGeralQtdeTotalPorFornecedor.Text = ValorTotal.ToString();
        }

        public void LimparFormularioRelatorio()
        {
            lblDataInicial.Text = string.Empty;
            lblDataFinal.Text = string.Empty;

            gvItemEntradaMaterial.DataSource = null;
            gvItemEntradaMaterial.DataBind();

            gvItemEntradaMaterialTotalPorFornecedor.DataSource = null;
            gvItemEntradaMaterialTotalPorFornecedor.DataBind();

            lblValorTotalGeral.Text = string.Empty;
            lblValorTotalGeralTotalPorFornecedor.Text = string.Empty;
            lblValorTotalGeralQtdeTotalPorFornecedor.Text = string.Empty;
        }
        #endregion

        #region (Métodos Principais)

        //Buscar Saída de Material
        protected void lkbBuscarItemEntradaMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                ItemEntradaMaterialBO itemEntradaMaterialBO = new ItemEntradaMaterialBO();
                IList<ItemEntradaMaterial> listaItemEntradaMaterial = new List<ItemEntradaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {

                    string dataInicial = "'" + txtBuscarPorDataInicial.Text + "'";
                    string dataFinal = "'" + txtBuscarPorDataFinal.Text + "'";

                    SqlDataSource1.SelectCommand = "select Fornecedor.fornecedorNome as Fornecedor, Processo.processoData as ProcessoData, Processo.processoNumero as ProcessoN," +
                        " Produto.codigo as CodProd, Produto.produtoNome as Produto, Produto.produtoPrecoUnitario as Preço, Produto.quantidadeEntrada as Qtde," +
                        " Produto.produtoValorTotal as Total" +
                        " from EntradaMaterial, ItemEntradaMaterial, Produto, Fornecedor, Processo" +
                        " where ItemEntradaMaterial.entradaMaterialID = EntradaMaterial.entradaMaterialID and " +
                        " ItemEntradaMaterial.produtoID = Produto.produtoID and" +
                        " EntradaMaterial.fornecedorID = Fornecedor.fornecedorID and" +
                        " EntradaMaterial.processoID = Processo.processoID and" +
                        " CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + 
                        " order by Fornecedor.fornecedorNome asc";

                    SqlDataSource2.SelectCommand = "select Fornecedor.fornecedorNome as Fornecedor, SUM(Produto.quantidadeEntrada) as Quantidade, SUM(Produto.produtoValorTotal) as Total " +
                        " from EntradaMaterial, ItemEntradaMaterial, Produto, Fornecedor" +
                        " where ItemEntradaMaterial.entradaMaterialID = EntradaMaterial.entradaMaterialID and" +
                        " ItemEntradaMaterial.produtoID = Produto.produtoID and" +
                        " EntradaMaterial.fornecedorID = Fornecedor.fornecedorID and" +
                        " CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal +
                        " group by Fornecedor.fornecedorNome" +
                        " order by Fornecedor.fornecedorNome asc";
                 
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
        protected void gvItemEntradaMaterial_DataBound(object sender, EventArgs e)
        {
            CalcularValorTotalGeralItemEntradaMaterial();

            CalcularValorTotalGeralItemEntradaMaterialTotalPorFornecedor();

            CalcularValorTotalGeralItemEntradaMaterialQtdeTotalPorFornecedor();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
             
    }
}