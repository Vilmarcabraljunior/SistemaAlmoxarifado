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
    public partial class MasterPageInterna : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Mostrando o nome do usuário e definindo o tipo de menu que ele verá quando acessar o sistema.
            if (Session["UsuarioLogado"] != null)
            {
                var usuario = (Usuario)Session["UsuarioLogado"];

                if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel0)
                {
                    lblUsuarioNomeNivel0.Text = "Bem-Vindo(a) " + usuario._UsuarioNome;
                    pnlMenuNivel0Admin.Visible = true;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel1)
                {
                    lblUsuarioNomeNivel1.Text = "Bem-Vindo(a) " + usuario._UsuarioNome;
                    pnlMenuNivel1Almoxarifado.Visible = true;
                }
                else if (usuario._UsuarioNivelAcesso == UsuarioNivelAcesso.Nivel2) 
                {
                    lblUsuarioNomeNivel2.Text = "Bem-Vindo(a) " + usuario._UsuarioNome;
                    pnlMenuNivel2Outros.Visible = true;
                }
            }
            else
            {
                Response.Redirect("pgCarregamentoSaida.aspx");
            }
        }

        #region Métodos Auxiliares

        public void LimparFormularioAlterarSenha()
        {
            txtNovaSenha.Text = string.Empty;
            txtConfirmarSenha.Text = string.Empty;
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }

        #endregion

        #region Eventos do Modal Submenu Relatórios
        
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
        #endregion

        #region Eventos do Botão Sair

        protected void lkbSair_Click(object sender, EventArgs e)
        {
            try
            {
                var usuarioLogado = (Usuario)Session["UsuarioLogado"];

                Usuario usuario = new Usuario();
                usuario._UsuarioID = usuarioLogado._UsuarioID;
                usuario._UltimoAcessoData = "Seu último acesso foi dia " + DateTime.Now.ToShortDateString() + " às " + DateTime.Now.ToShortTimeString();

                UsuarioBO usuarioBO = new UsuarioBO();
                usuarioBO.AtualizarUltimoAcessoData(usuario);

                Response.Redirect("pgCarregamentoSaida.aspx");
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos do Alterar Senha

        protected void lkbAlterarSenha_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNovaSenha.Text))
                {
                    if (!string.IsNullOrEmpty(txtConfirmarSenha.Text))
                    {
                        if (txtNovaSenha.Text == txtConfirmarSenha.Text)
                        {
                            var usuarioLogado = (Usuario)Session["UsuarioLogado"];

                            Usuario usuario = new Usuario();

                            usuario._UsuarioID = usuarioLogado._UsuarioID;
                            usuario._UsuarioSenha = txtConfirmarSenha.Text;

                            UsuarioBO usuarioBO = new UsuarioBO();
                            usuarioBO.RedefinirSenha(usuario);

                            Mensagem("Senha foi Alterada com Sucesso.", this);

                            LimparFormularioAlterarSenha();
                        }
                        else
                        {
                            Mensagem("As Senhas Informadas Precisam ser Idênticas.", this);

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                        }
                    }
                    else
                    {
                        Mensagem("Campo Confirmar Senha é Obrigatório.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                    }
                }
                else
                {
                    Mensagem("Campo Nova Senha é Obrigatório.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAlterarSenhaModal();", true);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAlterarSenha_Click(object sender, EventArgs e)
        {
            LimparFormularioAlterarSenha();
        }

        #endregion
            
    }
}