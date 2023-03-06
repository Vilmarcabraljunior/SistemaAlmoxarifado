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
    public partial class pgUsuarioNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarDDLNivelAcesso();
            }
            txtDataCadastroArea.Text = DateTime.Now.ToLongDateString();
        }

        #region Métodos Auxiliares
        public void CarregarDDLNivelAcesso()
        {
            ddlUsuarioNivelAcesso.DataSource = Enum.GetNames(typeof(UsuarioNivelAcesso));
            ddlUsuarioNivelAcesso.DataBind();
        }


        public void LimparBusca()
        {
            gvUsuario.DataSource = null;
            gvUsuario.DataBind();
        }

        public void LimparFormulario()
        {
            lblUsuarioNovoTitulo.Text = "Novo Usuário";
            lblUsuarioNovoTitulo.CssClass = "fa fa-plus-circle";

            hdUsuarioID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtUsuarioCpf.Text = string.Empty;
            txtUsuarioNome.Text = string.Empty;
            txtUsuarioSenha.Text = string.Empty;
            ddlUsuarioNivelAcesso.SelectedValue = null;

            hdAreaID.Value = "0";
            txtAreaNome.Text = string.Empty;
        }

        public void LimparFormularioArea()
        {
            hdAreaModalID.Value = "0";
            txtAreaNomeModal.Text = string.Empty;
            txtDataCadastroArea.Text = DateTime.Now.ToLongDateString();
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Usuário

        Usuario usuario;
        UsuarioBO usuarioBO;
        IList<Usuario> listaUsuario;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();

                usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                usuario._DataCadastro = txtDataCadastro.Text;
                usuario._UsuarioNome = txtUsuarioNome.Text;
                usuario._UsuarioCpf = txtUsuarioCpf.Text;
                usuario._UsuarioSenha = txtUsuarioSenha.Text;
                usuario._UsuarioNivelAcesso = (UsuarioNivelAcesso)Enum.Parse(typeof(UsuarioNivelAcesso), ddlUsuarioNivelAcesso.SelectedValue);
                usuario._UltimoAcessoData = txtUltimoAcessoData.Text;
                usuario._Area._AreaID = Convert.ToInt32(hdAreaID.Value);

                usuarioBO = new UsuarioBO();
                usuarioBO.Salvar(usuario);

                if (usuario._UsuarioID != 0)
                {
                    if (gvUsuario.Rows.Count == 1)
                    {
                        int id = usuario._UsuarioID;
                        usuario = usuarioBO.BuscarPorID(id);

                        listaUsuario = new List<Usuario>();
                        listaUsuario.Add(usuario);

                        gvUsuario.DataSource = listaUsuario;
                        gvUsuario.DataBind();
                    }
                    else if (gvUsuario.Rows.Count > 1)
                    {
                        listaUsuario = new List<Usuario>();
                        listaUsuario = usuarioBO.BuscarTodosUsuarios();
                        gvUsuario.DataSource = listaUsuario;
                        gvUsuario.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);

                    Mensagem("Usuário Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Usuário Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
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
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                usuarioBO.Excluir(usuario);

                Mensagem("Usuário Excluido com Sucesso.", this);

                if (gvUsuario.Rows.Count == 1)
                {
                    int id = usuario._UsuarioID;
                    usuario = usuarioBO.BuscarPorID(id);
                    gvUsuario.DataSource = usuario;
                    gvUsuario.DataBind();
                }
                else if (gvUsuario.Rows.Count > 1)
                {
                    listaUsuario = new List<Usuario>();
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);

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
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                    txtBuscarPorNome.Text = string.Empty;

                }
                else if (!string.IsNullOrEmpty(txtBuscarPorCpf.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorCpf(txtBuscarPorCpf.Text);
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                    txtBuscarPorCpf.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvUsuario.DataSource = listaUsuario;
                    gvUsuario.DataBind();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                usuario = new Usuario();
                usuarioBO = new UsuarioBO();

                int id = Convert.ToInt32(gvUsuario.SelectedDataKey.Value);
                usuario = usuarioBO.BuscarPorID(id);

                hdUsuarioID.Value = usuario._UsuarioID.ToString();
                txtDataCadastro.Text = usuario._DataCadastro;
                txtUsuarioNome.Text = usuario._UsuarioNome;
                txtUsuarioCpf.Text = usuario._UsuarioCpf;
                txtUsuarioSenha.Text = usuario._UsuarioSenha;
                ddlUsuarioNivelAcesso.SelectedValue = usuario._UsuarioNivelAcesso.ToString();
                txtUltimoAcessoData.Text = usuario._UltimoAcessoData;

                hdAreaID.Value = usuario._Area._AreaID.ToString();
                txtAreaNome.Text = usuario._Area._AreaNome;

                lblUsuarioNovoTitulo.Text = "Atualizar Usuário";
                lblUsuarioNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos da Área

        protected void lkbSalvarArea_Click(object sender, EventArgs e)
        {
            try
            {
                Area area = new Area();
                AreaBO areaBO = new AreaBO();

                area._AreaID = Convert.ToInt32(hdAreaModalID.Value);
                area._AreaNome = txtAreaNomeModal.Text;
                area._DataCadastro = txtDataCadastroArea.Text;

                areaBO.Salvar(area);

                Mensagem("Área Salva com Sucesso", this);

                LimparFormularioArea();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarArea_Click(object sender, EventArgs e)
        {
            LimparFormularioArea();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
        }

        protected void lkbBuscarArea_Click(object sender, EventArgs e)
        {
            try
            {
                AreaBO areaBO = new AreaBO();
                IList<Area> listaArea = new List<Area>();

                if (!string.IsNullOrEmpty(txtBuscarAreaPorNome.Text))
                {
                    listaArea = areaBO.BuscarPorNome(txtBuscarAreaPorNome.Text);
                    if (listaArea != null)
                    {
                        gvArea.DataSource = listaArea;
                        gvArea.DataBind();

                        txtBuscarAreaPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewAreaModal();", true);
                    }
                    else
                    {
                        txtBuscarAreaPorNome.Text = string.Empty;

                        Mensagem("Nenhuma Área Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
                    }
                }
                else
                {
                    listaArea = areaBO.BuscarTodasAreas();
                    if (listaArea != null)
                    {
                        gvArea.DataSource = listaArea;
                        gvArea.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewAreaModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Área Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
                    }
                }
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
                Area area = new Area();
                AreaBO areaBO = new AreaBO();

                int id = Convert.ToInt32(gvArea.SelectedDataKey.Value);
                area = areaBO.BuscarPorID(id);

                hdAreaID.Value = area._AreaID.ToString();
                txtAreaNome.Text = area._AreaNome;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
          
    }
}