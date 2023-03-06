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
    public partial class pgFornecedorNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvFornecedor.DataSource = null;
            gvFornecedor.DataBind();
        }

        public void LimparFormulario()
        {
            lblFornecedorNovoTitulo.Text = "Novo Fornecedor";
            lblFornecedorNovoTitulo.CssClass = "fa fa-plus-circle";

            hdFornecedorID.Value = "0";
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();
            txtFornecedorNome.Text = string.Empty;
           
        }
        
        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos do Fornecedor

        Fornecedor fornecedor;
        FornecedorBO fornecedorBO;
        IList<Fornecedor> listaFornecedor;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastro.Text = DateTime.Now.ToLongDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoFornecedorModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                fornecedor = new Fornecedor();

                fornecedor._FornecedorID = Convert.ToInt32(hdFornecedorID.Value);
                fornecedor._DataCadastro = txtDataCadastro.Text;
                fornecedor._FornecedorNome = txtFornecedorNome.Text;

                fornecedorBO = new FornecedorBO();
                fornecedorBO.Salvar(fornecedor);

                if (fornecedor._FornecedorID != 0)
                {
                    if (gvFornecedor.Rows.Count == 1)
                    {
                        int id = fornecedor._FornecedorID;
                        fornecedor = fornecedorBO.BuscarPorID(id);

                        listaFornecedor = new List<Fornecedor>();
                        listaFornecedor.Add(fornecedor);

                        gvFornecedor.DataSource = listaFornecedor;
                        gvFornecedor.DataBind();
                    }
                    else if (gvFornecedor.Rows.Count > 1)
                    {
                        listaFornecedor = new List<Fornecedor>();
                        listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                        gvFornecedor.DataSource = listaFornecedor;
                        gvFornecedor.DataBind();
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewFornecedorModal();", true);

                    Mensagem("Fornecedor Atualizado com Sucesso.", this);
                }
                else
                {
                    Mensagem("Fornecedor Salvo com Sucesso.", this);

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoFornecedorModal();", true);
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
                fornecedor = new Fornecedor();
                fornecedorBO = new FornecedorBO();

                fornecedor._FornecedorID = Convert.ToInt32(hdFornecedorID.Value);
                fornecedorBO.Excluir(fornecedor);

                Mensagem("Fornecedor Excluído com Sucesso.", this);

                if (gvFornecedor.Rows.Count == 1)
                {
                    int id = fornecedor._FornecedorID;
                    fornecedor = fornecedorBO.BuscarPorID(id);
                    gvFornecedor.DataSource = fornecedor;
                    gvFornecedor.DataBind();
                }
                else if (gvFornecedor.Rows.Count > 1)
                {
                    listaFornecedor = new List<Fornecedor>();
                    listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                    gvFornecedor.DataSource = listaFornecedor;
                    gvFornecedor.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewFornecedorModal();", true);

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
                fornecedorBO = new FornecedorBO();
                listaFornecedor = new List<Fornecedor>();

                if (!string.IsNullOrEmpty(txtBuscarPorNome.Text))
                {
                    listaFornecedor = fornecedorBO.BuscarPorNome(txtBuscarPorNome.Text);
                    gvFornecedor.DataSource = listaFornecedor;
                    gvFornecedor.DataBind();

                    txtBuscarPorNome.Text = string.Empty;

                }
                else
                {
                    listaFornecedor = fornecedorBO.BuscarTodosFornecedores();
                    gvFornecedor.DataSource = listaFornecedor;
                    gvFornecedor.DataBind();

                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewFornecedorModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvFornecedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                fornecedor = new Fornecedor();
                fornecedorBO = new FornecedorBO();

                int id = Convert.ToInt32(gvFornecedor.SelectedDataKey.Value);
                fornecedor = fornecedorBO.BuscarPorID(id);

                hdFornecedorID.Value = fornecedor._FornecedorID.ToString();
                txtDataCadastro.Text = fornecedor._DataCadastro;
                txtFornecedorNome.Text = fornecedor._FornecedorNome;
                               
                lblFornecedorNovoTitulo.Text = "Atualizar Fornecedor";
                lblFornecedorNovoTitulo.CssClass = "fa fa-pencil";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoFornecedorModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion
                    
    }
}