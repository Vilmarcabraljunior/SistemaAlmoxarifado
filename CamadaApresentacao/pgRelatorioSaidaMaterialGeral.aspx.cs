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
    public partial class pgRelatorioSaidaMaterialGeral : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region (Métodos Auxiliáres)

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
            lblValorTotalGeralItemSaidaMaterial.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralItemSaidaMaterialTotalPorRequisitante()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemSaidaMaterialTotalPorRequisitante.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[3].Text != null && row.Cells[3].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[3].Text);
                    }

                }
            }
            lblValorTotalGeralItemSaidaMaterialTotalPorRequisitante.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralItemSaidaMaterialQtdeTotalPorRequisitante()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemSaidaMaterialTotalPorRequisitante.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralItemSaidaMaterialQtdeTotalPorRequisitante.Text = ValorTotal.ToString();
        }

        public void LimparFormularioRelatorio()
        {
            lblDataInicial.Text = string.Empty;
            lblDataFinal.Text = string.Empty;

            gvItemSaidaMaterial.DataSource = null;
            gvItemSaidaMaterial.DataBind();

            gvItemSaidaMaterialTotalPorRequisitante.DataSource = null;
            gvItemSaidaMaterialTotalPorRequisitante.DataBind();

            lblValorTotalGeralItemSaidaMaterial.Text = string.Empty;
            lblValorTotalGeralRotuloTotalPorRequisitante.Text = string.Empty;
            lblValorTotalGeralItemSaidaMaterialQtdeTotalPorRequisitante.Text = string.Empty;
        }
        #endregion

        #region (Métodos Principais)

        //Buscar Saída de Material
        protected void lkbBuscarItemSaidaMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {

                    string dataInicial = "'" + txtBuscarPorDataInicial.Text + "'";
                    string dataFinal = "'" + txtBuscarPorDataFinal.Text + "'";

                    SqlDataSource1.SelectCommand = "select Requisitante.codigo as CodRequisitante, Requisitante.requisitanteNome as Requisitante," +
                        " Produto.codigo as CodProd, Produto.produtoNome as Produto, Produto.produtoPrecoUnitario as Preço, Produto.quantidadeSaida as Qtde," +
                        " Produto.produtoValorTotal as Total" +
                        " from SaidaMaterial, ItemSaidaMaterial, Produto, Requisitante" +
                        " where ItemSaidaMaterial.saidaMaterialID = SaidaMaterial.saidaMaterialID and" +
                        " ItemSaidaMaterial.produtoID = Produto.produtoID and" +
                        " SaidaMaterial.requisitanteID = Requisitante.requisitanteID and" +
                        " CAST(SaidaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal +
                        " order by Requisitante.codigo asc";

                    SqlDataSource2.SelectCommand = "select Requisitante.codigo as CodRequisitante, Requisitante.requisitanteNome as Requisitante," +
                        " SUM(Produto.quantidadeSaida) as Quantidade, SUM(Produto.produtoValorTotal) as Total" +
                        " from SaidaMaterial, ItemSaidaMaterial, Produto, Requisitante" +
                        " where ItemSaidaMaterial.saidaMaterialID = SaidaMaterial.saidaMaterialID and" +
                        " ItemSaidaMaterial.produtoID = Produto.produtoID and" +
                        " SaidaMaterial.requisitanteID = Requisitante.requisitanteID and" +
                        " CAST(SaidaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal +
                        " group by Requisitante.codigo, Requisitante.requisitanteNome" +
                        " order by Requisitante.codigo asc";

                    lblDataInicial.Text = txtBuscarPorDataInicial.Text;
                    lblDataFinal.Text = txtBuscarPorDataFinal.Text;

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;

                }
                else
                {
                    Mensagem("Selecione o período", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBuscarItemSaidaMaterialModal();", true);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        
        //Método para calcular valor geral total através do evento row data bound do gridview
        protected void gvItemSaidaMaterial_DataBound(object sender, EventArgs e)
        {
            CalcularValorTotalGeralItemSaidaMaterial();

            CalcularValorTotalGeralItemSaidaMaterialTotalPorRequisitante();

            CalcularValorTotalGeralItemSaidaMaterialQtdeTotalPorRequisitante();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion

    }
}