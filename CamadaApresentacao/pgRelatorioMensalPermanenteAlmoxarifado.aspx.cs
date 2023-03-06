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
    public partial class pgRelatorioMensalPermanenteAlmoxarifado : System.Web.UI.Page
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
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralEntrada.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralEntradaMaterialExtra()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvEntradaMaterialExtra.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralEntradaExtra.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralSaidaMaterial()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvSaidaMaterial.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralSaida.Text = ValorTotal.ToString("C2");
        }

        public void CalcularValorTotalGeralLicitacao()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvLicitacao.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[2].Text != null && row.Cells[2].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[2].Text);
                    }

                }
            }
            lblValorTotalGeralLicitacao.Text = ValorTotal.ToString("C2");
        }

        public void LimparFormularioRelatorio()
        {
            lblDataInicial.Text = string.Empty;
            lblDataFinal.Text = string.Empty;

            gvEntradaMaterial.DataSource = null;
            gvEntradaMaterial.DataBind();

            gvEntradaMaterialExtra.DataSource = null;
            gvEntradaMaterialExtra.DataBind();

            gvSaidaMaterial.DataSource = null;
            gvSaidaMaterial.DataBind();

            gvLicitacao.DataSource = null;
            gvLicitacao.DataBind();

            lblValorTotalGeralEntrada.Text = string.Empty;
            lblValorTotalGeralEntradaExtra.Text = string.Empty;
            lblValorTotalGeralSaida.Text = string.Empty;
            lblValorTotalGeralLicitacao.Text = string.Empty;
        }
        #endregion

        #region (Métodos Principais)

        //Buscar Saída de Material
        protected void lkbBuscarSaidaMaterial_Click(object sender, EventArgs e)
        {
            try
            {
                RequisicaoBO requisicaoBO = new RequisicaoBO();
                IList<Requisicao> listaRequisicao = new List<Requisicao>();

                if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {

                    string dataInicial = "'" + txtBuscarPorDataInicial.Text + "'";
                    string dataFinal = "'" + txtBuscarPorDataFinal.Text + "'";


                    SqlDataSource1.SelectCommand = "select Conta.contaNumero as Codigo, Conta.contaDescricao as Conta, SUM(Produto.produtoValorTotal) as Entrada" +
                       " from EntradaMaterial, ItemEntradaMaterial, Produto, Conta" +
                       " WHERE ItemEntradaMaterial.entradaMaterialID = EntradaMaterial.entradaMaterialID  and ItemEntradaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and" +
                       " Produto.produtoTipo = 1 and Conta.tipoConta = 2 and CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + " GROUP BY  Conta.contaNumero, Conta.contaDescricao ORDER BY Conta.contaNumero ASC";

                    SqlDataSource2.SelectCommand = "select Conta.contaNumero as Codigo, Conta.contaDescricao as Conta, SUM(Produto.produtoValorTotal) as Entrada" +
                       " from EntradaMaterial, ItemEntradaMaterial, Produto, Conta" +
                       " WHERE ItemEntradaMaterial.entradaMaterialID = EntradaMaterial.entradaMaterialID  and ItemEntradaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and" +
                       " Produto.produtoTipo = 2 and Conta.tipoConta = 2 and CAST(EntradaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + " GROUP BY  Conta.contaNumero, Conta.contaDescricao ORDER BY Conta.contaNumero ASC";

                    SqlDataSource3.SelectCommand = "select Conta.contaNumero as Codigo ,Conta.contaDescricao as Conta, SUM(Produto.produtoValorTotal) as Saída" +
                        " from SaidaMaterial, ItemSaidaMaterial, Produto, Conta" +
                        " WHERE SaidaMaterial.saidaMaterialID = ItemSaidaMaterial.saidaMaterialID and ItemSaidaMaterial.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and" +
                        " Conta.tipoConta = 2 and CAST(SaidaMaterial.dataCadastro As DATE) BETWEEN " + dataInicial + " AND " + dataFinal + " GROUP BY  Conta.contaNumero, Conta.contaDescricao ORDER BY Conta.contaNumero ASC";

                    SqlDataSource4.SelectCommand = "select Conta.contaNumero as Codigo ,Conta.contaDescricao as Conta, SUM(Produto.EstoqueValorTotal) as EstoqueAtual" +
                        " from Licitacao, ItemLicitacao, Produto, Conta" +
                        " WHERE Licitacao.licitacaoID = ItemLicitacao.licitacaoID and ItemLicitacao.produtoID = Produto.produtoID and Produto.contaID = Conta.contaID and" +
                        " Conta.tipoConta = 2 GROUP BY  Conta.contaNumero, Conta.contaDescricao ORDER BY Conta.contaNumero ASC";


                    lblDataInicial.Text = txtBuscarPorDataInicial.Text;
                    lblDataFinal.Text = txtBuscarPorDataFinal.Text;

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;

                }
                else
                {
                    Mensagem("Selecione o período", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openBuscarSaidaMaterialModal();", true);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para calcular valor geral total através do evento row data bound do gridview
        protected void gvEntradaMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CalcularValorTotalGeralEntradaMaterial();
        }

        //Método para calcular valor geral total através do evento row data bound do gridview
        protected void gvEntradaMaterialExtra_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CalcularValorTotalGeralEntradaMaterialExtra();
        }

        //Método para calcular valor geral total através do evento row data bound do gridview
        protected void gvSaidaMaterial_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CalcularValorTotalGeralSaidaMaterial();
        }

        //Método para calcular valor geral total através do evento row data bound do gridview
        protected void gvLicitacao_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            CalcularValorTotalGeralLicitacao();
        }

        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
    }
}