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
    public partial class pgIndex : System.Web.UI.Page
    {
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
                      
            try
            {
                //Mostrando a data do último acesso do usuário
                var usuario = (Usuario)Session["UsuarioLogado"];

                lblUltimoAcessoData.Text = usuario._UltimoAcessoData;

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel0) 
                {
                    pnlMenuNivel0Admin.Visible = true;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel1)
                {
                    pnlMenuNivel1Almoxarifado.Visible = true;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2)
                {
                    pnlMenuNivel2Outros.Visible = true;
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #region Eventos do Menu Principal(Index)
        protected void imbMenuMaterial_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuMaterial();", true);
        }

        protected void imbMenuRequisicao_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuRequisicao();", true);
        }

        protected void imbMenuLicitacao_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuLicitacao();", true);
        }

        protected void lmbMenuRelatorio_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuRelatorio();", true);
        }
        
        protected void imbMenuUsuario_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("pgUsuarioNovo.aspx");
        }
    
        protected void imbMenuManualNivel0Admin_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuManuais();", true);
        }

        protected void imbMenuManualNivel1Almoxarifado_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuManualSemDev();", true);
        }

        protected void imbMenuManualNivel2Outros_Click(object sender, ImageClickEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "abrirModalSubmenuManualSemDev();", true);
        }
        #endregion

        #region Eventos do Modal SubMenu(index)
               

        protected void lkbLinkEntradaMaterialSubmenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgEntradaMaterialNovo.aspx");
        }
        
        protected void lkbLinkSaidaMaterialSubmenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgSaidaMaterialNovo.aspx");
        }

        protected void lkbLinkRequisicaoSubmenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRequisicaoNovo.aspx");
        }

        protected void lkbLinkLicitacaoSubmenu_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgLicitacaoNovo.aspx");
        }
            
        protected void lkbRelatorioRequisicaoEspecifico_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioRequisicaoEspecifico.aspx");
        }
        
        protected void lkbRelatorioEntradaMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioEntradaMaterial.aspx");
        }

        protected void lkbRelatorioSaidaMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioSaidaMaterial.aspx");
        }

        protected void lkbRelatorioNotificacaoBaixaDeMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioNotificacaoBaixaDeMaterial.aspx");
        }

        protected void lkbMovimentacaoDetalhadaEntradaMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioMovimentacaoDetalhadaEntradaMaterial.aspx");
        }

        protected void lkbMovimentacaoDetalhadaSaidaMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioMovimentacaoDetalhadaSaidaMaterial.aspx");
        }

        protected void lkbRelatorioEntradaMaterialGeral_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioEntradaMaterialGeral.aspx");
        }

        protected void lkbRelatorioSaidaMaterialGeral_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioSaidaMaterialGeral.aspx");
        }

        protected void lkbRelatorioMensalConsumoAlmoxarifado_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioMensalConsumoAlmoxarifado.aspx");
        }

        protected void lkbRelatorioMensalPermanenteAlmoxarifado_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioMensalPermanenteAlmoxarifado.aspx");
        }

        protected void lkbRelatorioInventarioEstoque_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioInventarioEstoque.aspx");
        }

        protected void lkbRelatorioEstoqueAtual_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgRelatorioEstoqueProduto.aspx");
        }

        protected void lkbLinkUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("pgUsuarioNovo.aspx");
        }
           
            
        #endregion
          
                  
    }
}