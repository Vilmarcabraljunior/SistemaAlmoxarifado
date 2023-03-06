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
    public partial class pgSaidaMaterialNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDataCadastroCentroDeCusto.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroRequisitante.Text = DateTime.Now.ToLongDateString();

            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AtualizarPrecoUnitarioMedioEstoque();
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvSaidaMaterial.DataSource = null;
            gvSaidaMaterial.DataBind();
        }

        public void LimparFormulario()
        {
            lblSaidaMaterialNovoTitulo.Text = "Nova Saída de Material";
            lblSaidaMaterialNovoTitulo.CssClass = "fa fa-plus-circle";

            hdSaidaMaterialID.Value = "0";
            txtDataCadastroSaidaMaterial.Text = DateTime.Now.ToShortDateString();

            hdCentroDeCustoID.Value = "0";
            txtCentroDeCustoCodigo.Text = string.Empty;
            txtCentroDeCustoDescricao.Text = string.Empty;

            hdRequisitanteID.Value = "0";
            txtRequisitanteCodigo.Text = string.Empty;
            txtRequisitanteNome.Text = string.Empty;

            txtSaidaMaterialObservacao.Text = string.Empty;

            hdUsuarioID.Value = "0";

            gvItemSaidaMaterial.DataSource = null;
            gvItemSaidaMaterial.DataBind();
        }

        public void LimparFormularioDetalhes()
        {
            hdDetalhesSaidaMaterialID.Value = "0";
            lblDataCadastroSaidaMaterial.Text = DateTime.Now.ToShortDateString();

            lblCentroDeCustoCodigo.Text = string.Empty;
            lblCentroDeCustoDescricao.Text = string.Empty;

            lblRequisitanteCodigo.Text = string.Empty;
            lblRequisitanteNome.Text = string.Empty;

            txtSaidaMaterialObservacaoDetalhes.Text = string.Empty;

            lblUsuarioNome.Text = string.Empty;
            lblUsuarioArea.Text = string.Empty;

            gvItemSaidaMaterialDetalhes.DataSource = null;
            gvItemSaidaMaterialDetalhes.DataBind();

            lblValorTotalGeralDetalhes.Text = string.Empty;
        }

        public void LimparFormularioCentroDeCusto()
        {
            hdCentroDeCustoModalID.Value = "0";
            txtDataCadastroCentroDeCusto.Text = DateTime.Now.ToLongDateString();
            txtCentroDeCustoCodigoModal.Text = string.Empty;
            txtCentroDeCustoDescricaoModal.Text = string.Empty;
        }

        public void LimparFormularioRequisitante()
        {
            hdRequisitanteModalID.Value = "0";
            txtDataCadastroRequisitante.Text = DateTime.Now.ToLongDateString();
            txtRequisitanteCodigoModal.Text = string.Empty;
            txtRequisitanteNomeModal.Text = string.Empty;
        }

        public void ValidacaoSalvarProduto()
        {
            if (string.IsNullOrEmpty(txtCodigo.Text))
            {
                Mensagem("Campo CÓDIGO DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtDataCadastroProduto.Text))
            {
                Mensagem("Campo DATA DO CADASTRO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (string.IsNullOrEmpty(txtProdutoNome.Text))
            {
                Mensagem("Campo NOME DO PRODUTO é Obrigatório.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }

            else if (hdContaID.Value == "0")
            {
                Mensagem("Selecione uma CONTA.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            else if (hdUnidadeID.Value == "0")
            {
                Mensagem("Selecione uma UNIDADE.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
        }

        public void LimparFormularioProduto()
        {
            hdProdutoID.Value = "0";
            txtCodigo.Text = string.Empty;
            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNome.Text = string.Empty;
            txtProdutoPrecoUnitario.Text = string.Empty;
            txtQuantidadeSaida.Text = "0";

            hdContaID.Value = "0";
            txtConta.Text = string.Empty;
            txtContaNumero.Text = string.Empty;

            hdUnidadeID.Value = "0";
            txtUnidadeDescricao.Text = string.Empty;
        }

        public void LimparFormularioConta()
        {
            hdContaModalID.Value = "0";
            txtContaDescricao.Text = string.Empty;
            txtContaNumeroModal.Text = string.Empty;
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
        }

        public void LimparFormularioUnidade()
        {
            hdUnidadeModalID.Value = "0";
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtUnidadeDescricaoModal.Text = string.Empty;
        }

        public void LimparFormularioNomeProduto()
        {
            hdNomeProdutoID.Value = "0";
            txtCodigoModal.Text = string.Empty;
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();
            txtProdutoNomeModal.Text = string.Empty;
            txtProdutoPrecoUnitarioProdutoNome.Text = string.Empty;

            hdContaIDProdutoNome.Value = "0";
            txtContaProdutoNome.Text = string.Empty;
            txtContaNumeroProdutoNome.Text = string.Empty;

            hdUnidadeIDProdutoNome.Value = "0";
            txtUnidadeDescricaoProdutoNome.Text = string.Empty;
        }

        public void CalcularValorTotalGeralItemSaidaMaterialDetalhes()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemSaidaMaterialDetalhes.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[6].Text != null && row.Cells[6].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[6].Text);
                    }

                }
            }
            lblValorTotalGeralDetalhes.Text = ValorTotal.ToString("C2");
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Saída de Material

        #region (Eventos Principais)

        SaidaMaterial saidaMaterial;
        SaidaMaterialBO saidaMaterialBO;
        IList<SaidaMaterial> listaSaidaMaterial;

        protected void lkbNovo_Click(object sender, EventArgs e)
        {
            txtDataCadastroSaidaMaterial.Text = DateTime.Now.ToShortDateString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
        }

        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                saidaMaterial = new SaidaMaterial();

                saidaMaterial._SaidaMaterialID = Convert.ToInt32(hdSaidaMaterialID.Value);
                saidaMaterial._DataCadastro = txtDataCadastroSaidaMaterial.Text;
                saidaMaterial._HoraCadastro = DateTime.Now.ToShortTimeString();

                saidaMaterial._Requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteID.Value);
                saidaMaterial._CentroDeCusto._CentroDeCustoID = Convert.ToInt32(hdCentroDeCustoID.Value);

                saidaMaterial._Observacao = txtSaidaMaterialObservacao.Text;

                if (hdSaidaMaterialID.Value != "0")
                {
                    saidaMaterial._Usuario._UsuarioID = Convert.ToInt32(hdUsuarioID.Value);
                }
                else
                {
                    var usuario = (Usuario)Session["UsuarioLogado"];
                    saidaMaterial._Usuario._UsuarioID = usuario._UsuarioID;
                }

                saidaMaterialBO = new SaidaMaterialBO();

                //salva e retorna o id para o hiddenfield para gravar os itens da saída de material.
                int saidaMaterialIDRetornador = saidaMaterialBO.Salvar(saidaMaterial);
                txtSaidaMaterialID.Text = saidaMaterialIDRetornador.ToString();

                if (saidaMaterial._SaidaMaterialID != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemSaidaMaterialModal();", true);

                    Mensagem("Saída de Material Atualizada com Sucesso.", this);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemSaidaMaterialModal();", true);

                    Mensagem("Saída de Material Salva com Sucesso.", this);
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
                saidaMaterial = new SaidaMaterial();
                saidaMaterialBO = new SaidaMaterialBO();

                //Primeiro excluir os itens da saída de material para não dar erro de integridade no banco

                //Excluir os itens da saída de material
                ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                itemSaidaMaterialBO.ExcluirItensDaSaidaMaterial(Convert.ToInt32(hdSaidaMaterialID.Value));

                //excluir uma saída de material
                saidaMaterial._SaidaMaterialID = Convert.ToInt32(hdSaidaMaterialID.Value);
                saidaMaterialBO.Excluir(saidaMaterial);

                Mensagem("Saída de Material Excluída com Sucesso.", this);

                if (gvSaidaMaterial.Rows.Count == 1)
                {
                    int id = saidaMaterial._SaidaMaterialID;
                    saidaMaterial = saidaMaterialBO.BuscarPorID(id);
                    gvSaidaMaterial.DataSource = saidaMaterial;
                    gvSaidaMaterial.DataBind();
                }
                else if (gvSaidaMaterial.Rows.Count > 1)
                {
                    listaSaidaMaterial = new List<SaidaMaterial>();
                    listaSaidaMaterial = saidaMaterialBO.BuscarTodasSaidasMaterial();
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);

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
                saidaMaterialBO = new SaidaMaterialBO();
                listaSaidaMaterial = new List<SaidaMaterial>();

                if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarPorSaidaData(txtBuscarPorData.Text);
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarSaidaDataPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                }
                else
                {
                    listaSaidaMaterial = saidaMaterialBO.BuscarTodasSaidasMaterial();
                    gvSaidaMaterial.DataSource = listaSaidaMaterial;
                    gvSaidaMaterial.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarSaidaMaterialPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarSaidaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarSaidaMaterialPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarSaidaMaterialPorUsuario.DataSource = listaUsuario;
                    gvBuscarSaidaMaterialPorUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarSaidaMaterialPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarSaidaMaterialPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                saidaMaterialBO = new SaidaMaterialBO();
                listaSaidaMaterial = new List<SaidaMaterial>();

                int usuarioID = Convert.ToInt32(gvBuscarSaidaMaterialPorUsuario.SelectedDataKey.Value);
                listaSaidaMaterial = saidaMaterialBO.BuscarPorUsuario(usuarioID);

                gvSaidaMaterial.DataSource = listaSaidaMaterial;
                gvSaidaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarSaidaMaterialPorRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitanteBO requisitanteBO = new RequisitanteBO();
                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarPorRequisitante.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarPorRequisitante.Text);
                    gvBuscarSaidaMaterialPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarSaidaMaterialPorRequisitante.DataBind();

                    txtBuscarPorRequisitante.Text = string.Empty;
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    gvBuscarSaidaMaterialPorRequisitante.DataSource = listaRequisitante;
                    gvBuscarSaidaMaterialPorRequisitante.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarSaidaMaterialPorRequisitanteModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarSaidaMaterialPorRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                saidaMaterialBO = new SaidaMaterialBO();
                listaSaidaMaterial = new List<SaidaMaterial>();

                int requisitanteID = Convert.ToInt32(gvBuscarSaidaMaterialPorRequisitante.SelectedDataKey.Value);
                listaSaidaMaterial = saidaMaterialBO.BuscarPorRequisitante(requisitanteID);

                gvSaidaMaterial.DataSource = listaSaidaMaterial;
                gvSaidaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvSaidaMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                saidaMaterial = new SaidaMaterial();
                saidaMaterialBO = new SaidaMaterialBO();

                int saidaMaterialID = Convert.ToInt32(gvSaidaMaterial.SelectedDataKey.Value);
                saidaMaterial = saidaMaterialBO.BuscarPorID(saidaMaterialID);

                hdDetalhesSaidaMaterialID.Value = saidaMaterial._SaidaMaterialID.ToString();
                lblDataCadastroSaidaMaterial.Text = saidaMaterial._DataCadastro;

                lblCentroDeCustoCodigo.Text = saidaMaterial._CentroDeCusto._Codigo;
                lblCentroDeCustoDescricao.Text = saidaMaterial._CentroDeCusto._Descricao;

                lblRequisitanteCodigo.Text = saidaMaterial._Requisitante._Codigo;
                lblRequisitanteNome.Text = saidaMaterial._Requisitante._RequisitanteNome;

                txtSaidaMaterialObservacaoDetalhes.Text = saidaMaterial._Observacao;

                lblUsuarioNome.Text = saidaMaterial._Usuario._UsuarioNome;
                lblUsuarioArea.Text = saidaMaterial._Usuario._Area._AreaNome;

                //mostar todos os itens da Saída de Material.
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBO.BuscarItensDaSaidaMaterial(saidaMaterialID);
                gvItemSaidaMaterialDetalhes.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterialDetalhes.DataBind();

                //calcular valor total geral dos detalhes do item da saída de material
                CalcularValorTotalGeralItemSaidaMaterialDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSaidaMaterialDetalhesModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do Detalhes)

        protected void lkbAtualizarDetalhes_Click(object sender, EventArgs e)
        {
            try
            {
                lblSaidaMaterialNovoTitulo.Text = "Atualizar Saída de Material";
                lblSaidaMaterialNovoTitulo.CssClass = "fa fa-pencil";

                saidaMaterial = new SaidaMaterial();
                saidaMaterialBO = new SaidaMaterialBO();

                saidaMaterial = saidaMaterialBO.BuscarPorID(Convert.ToInt32(hdDetalhesSaidaMaterialID.Value));

                hdSaidaMaterialID.Value = saidaMaterial._SaidaMaterialID.ToString();
                txtDataCadastroSaidaMaterial.Text = saidaMaterial._DataCadastro;

                hdCentroDeCustoID.Value = saidaMaterial._CentroDeCusto._CentroDeCustoID.ToString();
                txtCentroDeCustoCodigo.Text = saidaMaterial._CentroDeCusto._Codigo;
                txtCentroDeCustoDescricao.Text = saidaMaterial._CentroDeCusto._Descricao;

                hdRequisitanteID.Value = saidaMaterial._Requisitante._RequisitanteID.ToString();
                txtRequisitanteCodigo.Text = saidaMaterial._Requisitante._Codigo;
                txtRequisitanteNome.Text = saidaMaterial._Requisitante._RequisitanteNome;

                txtSaidaMaterialObservacao.Text = saidaMaterial._Observacao;

                hdUsuarioID.Value = saidaMaterial._Usuario._UsuarioID.ToString();

                //mostar todos os itens
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBO.BuscarItensDaSaidaMaterial(Convert.ToInt32(hdSaidaMaterialID.Value));
                gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterial.DataBind();

                LimparFormularioDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemSaidaMaterialDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialDetalhesModal();", true);
        }

        protected void lkbCancelarDetalhes_Click(object sender, EventArgs e)
        {
            LimparFormularioDetalhes();
        }

        protected void lkbVisualizarSaidaMaterialDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openSaidaMaterialDetalhesModal();", true);
        }


        #endregion


        #region (Eventos ItemSaidaMaterial)
        protected void lkbAdicionarItemSaidaMaterialModal_Click(object sender, EventArgs e)
        {
            try
            {
                //mostar todos os itens
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBO.BuscarItensDaSaidaMaterial(Convert.ToInt32(txtSaidaMaterialID.Text));
                gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterial.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAdicionarItemSaidaMaterialModal_Click(object sender, EventArgs e)
        {
            txtSaidaMaterialID.Text = string.Empty;
            hdSaidaMaterialIDRetornado.Value = "0";

            LimparFormulario();
        }

        //Método para atualizar um item da saída de material
        protected void gvItemSaidaMaterial_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Buscar um item da saída de material pelo id
                saidaMaterial = new SaidaMaterial();
                ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                int itemSaidaMaterialID = Convert.ToInt32(gvItemSaidaMaterial.DataKeys[e.RowIndex].Value);
                itemSaidaMaterial = itemSaidaMaterialBO.BuscarPorID(itemSaidaMaterialID);


                //Buscar o produto pelo id do produto que veio do item da saída de material
                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto = produtoBO.BuscarPorID(itemSaidaMaterial._Produto._ProdutoID);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastroProduto.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeSaida.Text = produto._QuantidadeSaida.ToString();

                hdContaID.Value = produto._Conta._ContaID.ToString();
                txtConta.Text = produto._Conta._ContaDescricao;
                txtContaNumero.Text = produto._Conta._ContaNumero;

                hdUnidadeID.Value = produto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = produto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para excluir um item da sáida de material
        protected void gvItemSaidaMaterial_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //exclui um item da saída de material
                saidaMaterial = new SaidaMaterial();
                ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                int itemSaidaMaterialID = Convert.ToInt32(gvItemSaidaMaterial.DataKeys[e.RowIndex].Value);
                itemSaidaMaterial._ItemSaidaMaterialID = Convert.ToInt32(itemSaidaMaterialID);
                itemSaidaMaterialBO.Excluir(itemSaidaMaterial);


                //mostar todos os itens
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBOBuscar = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBOBuscar.BuscarItensDaSaidaMaterial(Convert.ToInt32(txtSaidaMaterialID.Text));
                gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterial.DataBind();


                Mensagem("Produto foi Excluído da Saída de Material com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbFinalizarAdicionarItemModal_Click(object sender, EventArgs e)
        {
            txtSaidaMaterialID.Text = string.Empty;
            hdSaidaMaterialIDRetornado.Value = "0";

            LimparFormulario();

            Mensagem("Finalizado com Sucesso.", this);
        }

        #endregion



        #region (Eventos do Centro de Custo)

        protected void lkbSalvarCentroDeCusto_Click(object sender, EventArgs e)
        {
            try
            {
                CentroDeCusto centroDeCusto = new CentroDeCusto();
                CentroDeCustoBO centroDeCustoBO = new CentroDeCustoBO();

                centroDeCusto._CentroDeCustoID = Convert.ToInt32(hdCentroDeCustoModalID.Value);
                centroDeCusto._DataCadastro = txtDataCadastroCentroDeCusto.Text;
                centroDeCusto._Codigo = txtCentroDeCustoCodigoModal.Text;
                centroDeCusto._Descricao = txtCentroDeCustoDescricaoModal.Text;

                centroDeCustoBO.Salvar(centroDeCusto);

                Mensagem("Centro de Custo Salvo com Sucesso", this);

                LimparFormularioCentroDeCusto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        protected void lkbCancelarCentroDeCusto_Click(object sender, EventArgs e)
        {
            LimparFormularioCentroDeCusto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
        }

        protected void lkbVoltarCentroDeCusto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
        }

        protected void lkbBuscarCentroDeCusto_Click(object sender, EventArgs e)
        {
            try
            {
                CentroDeCustoBO centroDeCustoBO = new CentroDeCustoBO();
                IList<CentroDeCusto> listaCentroDeCusto = new List<CentroDeCusto>();

                if (!string.IsNullOrEmpty(txtBuscarCentroDeCustoPorCodigo.Text))
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarPorCodigo(txtBuscarCentroDeCustoPorCodigo.Text);
                    if (listaCentroDeCusto != null)
                    {
                        gvCentroDeCusto.DataSource = listaCentroDeCusto;
                        gvCentroDeCusto.DataBind();

                        txtBuscarCentroDeCustoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);
                    }
                    else
                    {
                        txtBuscarCentroDeCustoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Centro de Custo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarCentroDeCustoPorDescricao.Text))
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarPorDescricao(txtBuscarCentroDeCustoPorDescricao.Text);
                    if (listaCentroDeCusto != null)
                    {
                        gvCentroDeCusto.DataSource = listaCentroDeCusto;
                        gvCentroDeCusto.DataBind();

                        txtBuscarCentroDeCustoPorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);
                    }
                    else
                    {
                        txtBuscarCentroDeCustoPorDescricao.Text = string.Empty;

                        Mensagem("Nenhum Centro de Custo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
                else
                {
                    listaCentroDeCusto = centroDeCustoBO.BuscarTodosCentrosDeCusto();
                    if (listaCentroDeCusto != null)
                    {
                        gvCentroDeCusto.DataSource = listaCentroDeCusto;
                        gvCentroDeCusto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewCentroDeCustoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Centro de Custo Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvCentroDeCusto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CentroDeCusto centroDeCusto = new CentroDeCusto();
                CentroDeCustoBO centroDeCustoBO = new CentroDeCustoBO();

                int id = Convert.ToInt32(gvCentroDeCusto.SelectedDataKey.Value);
                centroDeCusto = centroDeCustoBO.BuscarPorID(id);

                hdCentroDeCustoID.Value = centroDeCusto._CentroDeCustoID.ToString();
                txtCentroDeCustoCodigo.Text = centroDeCusto._Codigo;
                txtCentroDeCustoDescricao.Text = centroDeCusto._Descricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion

        #region (Eventos do Requisitante)
        protected void lkbSalvarRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                Requisitante requisitante = new Requisitante();
                RequisitanteBO requisitanteBO = new RequisitanteBO();

                requisitante._RequisitanteID = Convert.ToInt32(hdRequisitanteModalID.Value);
                requisitante._DataCadastro = txtDataCadastroRequisitante.Text;
                requisitante._Codigo = txtRequisitanteCodigoModal.Text;
                requisitante._RequisitanteNome = txtRequisitanteNomeModal.Text;

                requisitanteBO.Salvar(requisitante);

                Mensagem("Requisitante Salvo com Sucesso", this);

                LimparFormularioRequisitante();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        protected void lkbCancelarRequisitante_Click(object sender, EventArgs e)
        {
            LimparFormularioRequisitante();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
        }

        protected void lkbVoltarRequisitante_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
        }

        protected void lkbBuscarRequisitante_Click(object sender, EventArgs e)
        {
            try
            {
                RequisitanteBO requisitanteBO = new RequisitanteBO();
                IList<Requisitante> listaRequisitante = new List<Requisitante>();

                if (!string.IsNullOrEmpty(txtBuscarRequisitantePorCodigo.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorCodigo(txtBuscarRequisitantePorCodigo.Text);
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        txtBuscarRequisitantePorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        txtBuscarRequisitantePorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarRequisitantePorNome.Text))
                {
                    listaRequisitante = requisitanteBO.BuscarPorNome(txtBuscarRequisitantePorNome.Text);
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        txtBuscarRequisitantePorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        txtBuscarRequisitantePorNome.Text = string.Empty;

                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
                else
                {
                    listaRequisitante = requisitanteBO.BuscarTodosRequisitantes();
                    if (listaRequisitante != null)
                    {
                        gvRequisitante.DataSource = listaRequisitante;
                        gvRequisitante.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewRequisitanteModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Requisitante Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvRequisitante_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Requisitante requisitante = new Requisitante();
                RequisitanteBO requisitanteBO = new RequisitanteBO();

                int id = Convert.ToInt32(gvRequisitante.SelectedDataKey.Value);
                requisitante = requisitanteBO.BuscarPorID(id);

                hdRequisitanteID.Value = requisitante._RequisitanteID.ToString();
                txtRequisitanteCodigo.Text = requisitante._Codigo;
                txtRequisitanteNome.Text = requisitante._RequisitanteNome;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }
        #endregion



        #region (Eventos do Produto)

        protected void lkbSalvarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ValidacaoSalvarProduto();

                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto._ProdutoID = Convert.ToInt32(hdProdutoID.Value);
                produto._Codigo = txtCodigo.Text;
                produto._DataCadastro = txtDataCadastroProduto.Text;
                produto._ProdutoNome = txtProdutoNome.Text;
                produto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitario.Text);
                produto._QuantidadeSaida = Convert.ToInt32(txtQuantidadeSaida.Text);
                produto._ProdutoValorTotal = Convert.ToDecimal(produto._ProdutoPrecoUnitario * produto._QuantidadeSaida);

                produto._Conta._ContaID = Convert.ToInt32(hdContaID.Value);
                produto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeID.Value);

                produtoBO.Salvar(produto);

                if (produto._ProdutoID == 0)
                {
                    Mensagem("Produto Salvo com Sucesso.", this);
                }
                else
                {
                    Mensagem("Produto Atualizado com Sucesso.", this);
                }

                if (produto._ProdutoID == 0)
                {
                    //Buscar o último produto do registro para adicionar no item
                    Produto produto2 = new Produto();
                    ProdutoBO produtoBO2 = new ProdutoBO();

                    produto2 = produtoBO2.BuscarPorUltimoProdutoCadastrado();

                    //adicionar os produtos no item
                    saidaMaterial = new SaidaMaterial();
                    ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                    ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                    int produtoID = Convert.ToInt32(produto2._ProdutoID);

                    itemSaidaMaterial._Produto._ProdutoID = produtoID;
                    itemSaidaMaterial._SaidaMaterial._SaidaMaterialID = Convert.ToInt32(txtSaidaMaterialID.Text);

                    itemSaidaMaterialBO.Salvar(itemSaidaMaterial);
                }

                if (produto._ProdutoID == 0)
                {
                    //Método para atualizar a quantidade em estoque do produto, buscando pelo código
                    Produto produto3 = new Produto();
                    ProdutoBO produtoBO3 = new ProdutoBO();
                    produto3 = produtoBO3.BuscarPorUltimoProdutoCadastrado();

                    int quantidadeSaida = produto3._QuantidadeSaida;
                    string produtoNome = produto3._ProdutoNome;
                    decimal produtoValorTotal = produto3._ProdutoValorTotal;
                                      

                    ProdutoBO produtoBO4 = new ProdutoBO();
                    produtoBO4.AtualizarQtdeEstoquePorCodigoProdutoSaida(quantidadeSaida, produtoNome, produtoValorTotal);
                }

                //mostar todos os itens
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBOBuscar = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBOBuscar.BuscarItensDaSaidaMaterial(Convert.ToInt32(txtSaidaMaterialID.Text));
                gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterial.DataBind();

                LimparFormularioProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
        }

        protected void lkbBuscarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                ProdutoBO produtoBO = new ProdutoBO();
                IList<Produto> listaProduto = new List<Produto>();

                if (!string.IsNullOrEmpty(txtBuscarProdutoPorCodigo.Text))
                {
                    listaProduto = produtoBO.BuscarPorCodigo(txtBuscarProdutoPorCodigo.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarProdutoPorNome.Text))
                {
                    listaProduto = produtoBO.BuscarPorNome(txtBuscarProdutoPorNome.Text);
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        txtBuscarProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
                    }
                }
                else
                {
                    listaProduto = produtoBO.BuscarTodosProdutos();
                    if (listaProduto != null)
                    {
                        gvProduto.DataSource = listaProduto;
                        gvProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //adicionar os produtos no item
                saidaMaterial = new SaidaMaterial();
                ItemSaidaMaterial itemSaidaMaterial = new ItemSaidaMaterial(saidaMaterial);
                ItemSaidaMaterialBO itemSaidaMaterialBO = new ItemSaidaMaterialBO();

                int produtoID = Convert.ToInt32(gvProduto.SelectedDataKey.Value);

                itemSaidaMaterial._Produto._ProdutoID = produtoID;
                itemSaidaMaterial._SaidaMaterial._SaidaMaterialID = Convert.ToInt32(txtSaidaMaterialID.Text);

                itemSaidaMaterialBO.Salvar(itemSaidaMaterial);


                //mostar todos os itens
                IList<ItemSaidaMaterial> listaItemSaidaMaterial = new List<ItemSaidaMaterial>();
                ItemSaidaMaterialBO itemSaidaMaterialBOBuscar = new ItemSaidaMaterialBO();

                listaItemSaidaMaterial = itemSaidaMaterialBOBuscar.BuscarItensDaSaidaMaterial(Convert.ToInt32(txtSaidaMaterialID.Text));
                gvItemSaidaMaterial.DataSource = listaItemSaidaMaterial;
                gvItemSaidaMaterial.DataBind();

                Mensagem("Produto Adicionado com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCalcularQuantidadeFornecida_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQuantidadeFornecidaDecrescimo.Text != null)
                {
                    decimal quantidadeSaida = Convert.ToDecimal(txtQuantidadeSaida.Text);
                    decimal quantidadeSaidaDecrescimo = Convert.ToDecimal(txtQuantidadeFornecidaDecrescimo.Text);
                    decimal quantidadeSaidaTotal = quantidadeSaida - quantidadeSaidaDecrescimo;

                    txtQuantidadeSaida.Text = quantidadeSaidaTotal.ToString();

                    txtQuantidadeFornecidaDecrescimo.Text = string.Empty;

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                }
                else
                {
                    Mensagem("Digite a quantidade de produtos da saída", this);
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }

        }

        protected void lkbVisualizarGridViewItemSaidaMaterialModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemSaidaMaterialModal();", true);
        }

        #endregion

        #region Eventos da Conta

        protected void lkbSalvarConta_Click(object sender, EventArgs e)
        {
            try
            {
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                conta._ContaID = Convert.ToInt32(hdContaModalID.Value);
                conta._ContaDescricao = txtContaDescricao.Text;
                conta._ContaNumero = txtContaNumeroModal.Text;
                conta._DataCadastro = txtDataCadastroConta.Text;

                contaBO.Salvar(conta);

                Mensagem("Conta Salva com Sucesso.", this);

                LimparFormularioConta();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarConta_Click(object sender, EventArgs e)
        {
            LimparFormularioConta();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarConta_Click(object sender, EventArgs e)
        {
            try
            {
                ContaBO contaBO = new ContaBO();
                IList<Conta> listaConta = new List<Conta>();

                if (!string.IsNullOrEmpty(txtBuscarContaPorNumero.Text))
                {
                    listaConta = contaBO.BuscarPorNumero(txtBuscarContaPorNumero.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorNumero.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorNumero.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else if (!string.IsNullOrEmpty(txtBuscarContaPorDescricao.Text))
                {
                    listaConta = contaBO.BuscarPorDescricao(txtBuscarContaPorDescricao.Text);
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        txtBuscarContaPorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        txtBuscarContaPorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
                else
                {
                    listaConta = contaBO.BuscarTodasContas();
                    if (listaConta != null)
                    {
                        gvConta.DataSource = listaConta;
                        gvConta.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewContaModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Conta Encontrada.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvConta_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Conta conta = new Conta();
                ContaBO contaBO = new ContaBO();

                int id = Convert.ToInt32(gvConta.SelectedDataKey.Value);
                conta = contaBO.BuscarPorID(id);

                hdContaIDProdutoNome.Value = conta._ContaID.ToString();
                txtContaProdutoNome.Text = conta._ContaDescricao;
                txtContaNumeroProdutoNome.Text = conta._ContaNumero;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region Eventos da Unidade

        protected void lkbSalvarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                unidade._UnidadeID = Convert.ToInt32(hdUnidadeModalID.Value);
                unidade._DataCadastro = txtDataCadastroUnidade.Text;
                unidade._UnidadeDescricao = txtUnidadeDescricaoModal.Text;

                unidadeBO.Salvar(unidade);

                Mensagem("Unidade Salva com Sucesso.", this);

                LimparFormularioUnidade();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarUnidade_Click(object sender, EventArgs e)
        {
            LimparFormularioUnidade();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
        }

        protected void lkbBuscarUnidade_Click(object sender, EventArgs e)
        {
            try
            {
                UnidadeBO unidadeBO = new UnidadeBO();
                IList<Unidade> listaUnidade = new List<Unidade>();

                if (!string.IsNullOrEmpty(txtBuscarUnidadePorDescricao.Text))
                {
                    listaUnidade = unidadeBO.BuscarPorDescricao(txtBuscarUnidadePorDescricao.Text);
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        txtBuscarUnidadePorDescricao.Text = string.Empty;

                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }

                }
                else
                {
                    listaUnidade = unidadeBO.BuscarTodasUnidades();
                    if (listaUnidade != null)
                    {
                        gvUnidade.DataSource = listaUnidade;
                        gvUnidade.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewUnidadeModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhuma Unidade Encontrada", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Unidade unidade = new Unidade();
                UnidadeBO unidadeBO = new UnidadeBO();

                int id = Convert.ToInt32(gvUnidade.SelectedDataKey.Value);
                unidade = unidadeBO.BuscarPorID(id);

                hdUnidadeIDProdutoNome.Value = unidade._UnidadeID.ToString();
                txtUnidadeDescricaoProdutoNome.Text = unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoNomeProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion

        #region (Eventos do nome do Produto)

        protected void lkbSalvarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                nomeProduto._NomeProdutoID = Convert.ToInt32(hdNomeProdutoID.Value);
                nomeProduto._Codigo = txtCodigoModal.Text;
                nomeProduto._DataCadastro = txtDataCadastroNomeProduto.Text;
                nomeProduto._ProdutoNome = txtProdutoNomeModal.Text;
                nomeProduto._ProdutoPrecoUnitario = Convert.ToDecimal(txtProdutoPrecoUnitarioProdutoNome.Text);

                nomeProduto._Conta._ContaID = Convert.ToInt32(hdContaIDProdutoNome.Value);
                nomeProduto._Unidade._UnidadeID = Convert.ToInt32(hdUnidadeIDProdutoNome.Value);

                nomeProdutoBO.Salvar(nomeProduto);

                Mensagem("Nome do Produto Salvo com Sucesso.", this);

                LimparFormularioNomeProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarNomeProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioNomeProduto();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbVoltarNomeProduto_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
        }

        protected void lkbBuscarNomeProduto_Click(object sender, EventArgs e)
        {
            try
            {
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();
                IList<NomeProduto> listaNomeProduto = new List<NomeProduto>();

                if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorCodigo.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorCodigo(txtBuscarNomeProdutoPorCodigo.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorCodigo.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else if (!string.IsNullOrEmpty(txtBuscarNomeProdutoPorNome.Text))
                {
                    listaNomeProduto = nomeProdutoBO.BuscarPorNome(txtBuscarNomeProdutoPorNome.Text);
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        txtBuscarNomeProdutoPorNome.Text = string.Empty;

                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
                else
                {
                    listaNomeProduto = nomeProdutoBO.BuscarTodosNomesProdutos();
                    if (listaNomeProduto != null)
                    {
                        gvNomeProduto.DataSource = listaNomeProduto;
                        gvNomeProduto.DataBind();

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewNomeProdutoModal();", true);
                    }
                    else
                    {
                        Mensagem("Nenhum Nome do Produto Encontrado.", this);

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                NomeProduto nomeProduto = new NomeProduto();
                NomeProdutoBO nomeProdutoBO = new NomeProdutoBO();

                int id = Convert.ToInt32(gvNomeProduto.SelectedDataKey.Value);
                nomeProduto = nomeProdutoBO.BuscarPorID(id);

                txtCodigo.Text = nomeProduto._Codigo;
                txtProdutoNome.Text = nomeProduto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = nomeProduto._ProdutoPrecoUnitario.ToString();

                hdContaID.Value = nomeProduto._Conta._ContaID.ToString();
                txtConta.Text = nomeProduto._Conta._ContaDescricao;
                txtContaNumero.Text = nomeProduto._Conta._ContaNumero;

                hdUnidadeID.Value = nomeProduto._Unidade._UnidadeID.ToString();
                txtUnidadeDescricao.Text = nomeProduto._Unidade._UnidadeDescricao;

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovoProdutoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        #endregion
              

        #endregion

    }
}