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
    public partial class pgRelatorioEstoqueProduto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarItensDoEstoque();
        }

        #region (Métodos Auxiliáres)

        public void LimparFormularioRelatorio()
        {
            gvItemLicitacao.DataSource = null;
            gvItemLicitacao.DataBind();

            lblValorTotalGeral.Text = string.Empty;
            lblQuantidadeTotalGeral.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        public void MostrarItensDoEstoque()
        {
            try
            {
                Licitacao licitacao = new Licitacao();
                LicitacaoBO licitacaoBO = new LicitacaoBO();

                licitacao = licitacaoBO.BuscarPorUltimaLicitacao();

                if (licitacao != null)
                {
                    int licitacaoID = licitacao._LicitacaoID;

                    //mostar todos os itens da licitação.
                    IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                    ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                    listaItemLicitacao = itemLicitacaoBO.BuscarItensDaLicitacao(licitacaoID);
                    gvItemLicitacao.DataSource = listaItemLicitacao;
                    gvItemLicitacao.DataBind();

                    //calcular valor total geral  do item da licitação
                    CalcularValorTotalGeralItemLicitacao();

                    //calcular valor total da quantidade dos itens da licitação
                    CalcularQuantidadeTotalGeralItemLicitacao();
                }
                else
                {
                    gvItemLicitacao.DataSource = null;
                    gvItemLicitacao.DataBind();
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        public void CalcularValorTotalGeralItemLicitacao()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacao.Rows)
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

        public void CalcularQuantidadeTotalGeralItemLicitacao()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacao.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[3].Text != null && row.Cells[3].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[3].Text);
                    }

                }
            }
            lblQuantidadeTotalGeral.Text = ValorTotal.ToString();
        }

        #endregion

        #region (Métodos Principais)
               
        protected void lkbCancelar_Click(object sender, EventArgs e)
        {
            LimparFormularioRelatorio();
            Response.Redirect("pgIndex.aspx");
        }

        #endregion
    }
}