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
    public partial class pgLicitacaoNovo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDataCadastroLicitacao.Text = DateTime.Now.ToShortDateString();
            txtDataCadastroProduto.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroConta.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroUnidade.Text = DateTime.Now.ToLongDateString();
            txtDataCadastroNomeProduto.Text = DateTime.Now.ToLongDateString();

            //Método para mostrar os itens do estoque atual
            MostrarItensDoEstoque();

            //Método para atualizar os contadores de quantidade e valor geral
            AtualizarContadores();

            //Método para verificar se o estoque está baixo e manda uma mensagem
            VerificaSeEstoqueEstaBaixoMensagem();

            //Método para mostrar os itens que estão com o estoque baixo
            MostrarItensComEstoqueBaixo();

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AtualizarPrecoUnitarioMedioEstoque();
        }

        #region Métodos Auxiliares

        public void LimparBusca()
        {
            gvLicitacao.DataSource = null;
            gvLicitacao.DataBind();
        }

        public void LimparFormulario()
        {
            lblLicitacaoNovoTitulo.Text = "Novo Estoque";
            lblLicitacaoNovoTitulo.CssClass = "fa fa-plus-circle";

            hdLicitacaoID.Value = "0";
            txtDataCadastroLicitacao.Text = DateTime.Now.ToShortDateString();
            txtObservacao.Text = string.Empty;

            gvItemLicitacao.DataSource = null;
            gvItemLicitacao.DataBind();
        }

        public void LimparFormularioDetalhes()
        {
            hdDetalhesLicitacaoID.Value = "0";
            lblDataCadastroLicitacao.Text = string.Empty;
            txtObservacaoDetalhes.Text = string.Empty;
            
            gvItemLicitacaoDetalhes.DataSource = null;
            gvItemLicitacaoDetalhes.DataBind();

            lblValorTotalGeralDetalhes.Text = string.Empty;
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
            txtQuantidadeEstoque.Text = "0";

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
        }

        public void CalcularValorTotalGeralItemLicitacaoDetalhes()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacaoDetalhes.Rows)
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

        public void CalcularValorTotalGeralItemLicitacaoTelaPrincipal()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacaoTelaPrincipal.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[9].Text != null && row.Cells[9].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[9].Text);
                    }

                }
            }
            lblValorTotalGeralTelaPrincipal.Text = ValorTotal.ToString("C2");
        }

        public void CalcularQuantidadeTotalGeralItemLicitacaoTelaPrincipal()
        {
            decimal ValorTotal = 0;
            foreach (GridViewRow row in gvItemLicitacaoTelaPrincipal.Rows)
            {
                if (row.RowType != DataControlRowType.Header && row.RowType != DataControlRowType.Footer)
                {
                    if (row.Cells[6].Text != null && row.Cells[6].Text != string.Empty)
                    {
                        ValorTotal += Convert.ToDecimal(row.Cells[6].Text);
                    }

                }
            }
            lblQuantidadeTotalGeralTelaPrincipal.Text = ValorTotal.ToString();
        }

        public void VerificaSeEstoqueEstaBaixoMensagem()
        {
            for (int i = 0; i <= gvItemLicitacaoTelaPrincipal.Rows.Count - 1; i++)
            {
                Label lblQuantidadeEstoque = (Label)gvItemLicitacaoTelaPrincipal.Rows[i].FindControl("lblQuantidadeEstoque");

                int lblQtdeEstoque = Convert.ToInt32(lblQuantidadeEstoque.Text);

                if (lblQtdeEstoque <= 10)
                {
                    gvItemLicitacaoTelaPrincipal.Rows[i].Cells[6].BackColor = System.Drawing.Color.Red;
                    gvItemLicitacaoTelaPrincipal.Rows[i].Cells[6].ForeColor = System.Drawing.Color.White;
                                  

                }
                else
                {
                    gvItemLicitacaoTelaPrincipal.Rows[i].Cells[6].BackColor = System.Drawing.Color.LightGreen;
                    gvItemLicitacaoTelaPrincipal.Rows[i].Cells[6].ForeColor = System.Drawing.Color.Black;
                }
                                                        
            }
        }

        public void MostrarItensDoEstoque()
        {
            try
            {
                licitacao = new Licitacao();
                licitacaoBO = new LicitacaoBO();

                licitacao = licitacaoBO.BuscarPorUltimaLicitacao();
                
                if (licitacao != null) 
                {
                    int licitacaoID = licitacao._LicitacaoID;

                    txtLicitacaoID.Text = licitacaoID.ToString();

                    //mostar todos os itens da licitação.
                    IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                    ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                    listaItemLicitacao = itemLicitacaoBO.BuscarItensDaLicitacao(licitacaoID);
                    gvItemLicitacaoTelaPrincipal.DataSource = listaItemLicitacao;
                    gvItemLicitacaoTelaPrincipal.DataBind();
                                       
                }
                else
                {
                    gvItemLicitacaoTelaPrincipal.DataSource = null;
                    gvItemLicitacaoTelaPrincipal.DataBind();
                }
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        public void MostrarItensComEstoqueBaixo()
        {
            SqlDataSource1.SelectCommand = "select  Produto.codigo as Código, Produto.produtoNome as Produto, Produto.quantidadeEstoque [Qtde em Estoque]"+
                " from ItemLicitacao, Produto"+
                " where ItemLicitacao.produtoID = Produto.produtoID and Produto.quantidadeEstoque <= 10"+
                " order by Produto.codigo asc";
        }

        public void AtualizarContadores()
        {
            //calcular valor total geral  do item da licitação da tela Principal
            CalcularValorTotalGeralItemLicitacaoTelaPrincipal();

            //calcular a quantidade total geral  do item da licitação da tela Principal
            CalcularQuantidadeTotalGeralItemLicitacaoTelaPrincipal();
        }

        private static void Mensagem(String message, Control cntrl)
        {
            ScriptManager.RegisterStartupScript(cntrl, cntrl.GetType(), "information", "alert('" + message + "');", true);
        }
        #endregion

        #region Eventos da Licitação

        #region (Eventos Principais)

        Licitacao licitacao;
        LicitacaoBO licitacaoBO;
        IList<Licitacao> listaLicitacao;
        
        protected void lkbSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                licitacao = new Licitacao();

                licitacao._LicitacaoID = Convert.ToInt32(hdLicitacaoID.Value);
                licitacao._DataCadastro = txtDataCadastroLicitacao.Text;
                licitacao._Observacao = txtObservacao.Text;
                               

                licitacaoBO = new LicitacaoBO();

                //salva e retorna o id para o hiddenfild para gravar os itens da licitação.
                int licitacaoIDRetornador = licitacaoBO.Salvar(licitacao);
                txtLicitacaoID.Text = licitacaoIDRetornador.ToString();

                if (licitacao._LicitacaoID != 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemLicitacaoModal();", true);

                    Mensagem("Estoque Atualizado com Sucesso.", this);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openAdicionarItemLicitacaoModal();", true);

                    Mensagem("Estoque Salvo com Sucesso.", this);
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
                licitacao = new Licitacao();
                licitacaoBO = new LicitacaoBO();

                //Primeiro excluir os itens da licitação para não dar erro de integridade no banco

                //Excluir os itens da licitação
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                itemLicitacaoBO.ExcluirItensDaLicitacao(Convert.ToInt32(hdLicitacaoID.Value));

                //excluir uma licitação
                licitacao._LicitacaoID = Convert.ToInt32(hdLicitacaoID.Value);
                licitacaoBO.Excluir(licitacao);

                Mensagem("Estoque Excluído com Sucesso.", this);

                if (gvLicitacao.Rows.Count == 1)
                {
                    int id = licitacao._LicitacaoID;
                    licitacao = licitacaoBO.BuscarPorID(id);
                    gvLicitacao.DataSource = licitacao;
                    gvLicitacao.DataBind();
                }
                else if (gvLicitacao.Rows.Count > 1)
                {
                    listaLicitacao = new List<Licitacao>();
                    listaLicitacao = licitacaoBO.BuscarTodasLicitacoes();
                    gvLicitacao.DataSource = listaLicitacao;
                    gvLicitacao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewLicitacaoModal();", true);

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
                licitacaoBO = new LicitacaoBO();
                listaLicitacao = new List<Licitacao>();

                if (!string.IsNullOrEmpty(txtBuscarPorData.Text))
                {
                    listaLicitacao = licitacaoBO.BuscarPorDataCadastro(txtBuscarPorData.Text);
                    gvLicitacao.DataSource = listaLicitacao;
                    gvLicitacao.DataBind();

                    txtBuscarPorData.Text = string.Empty;
                }
                else if (!string.IsNullOrEmpty(txtBuscarPorDataInicial.Text))
                {
                    listaLicitacao = licitacaoBO.BuscarDataCadastroPorBetween(txtBuscarPorDataInicial.Text, txtBuscarPorDataFinal.Text);
                    gvLicitacao.DataSource = listaLicitacao;
                    gvLicitacao.DataBind();

                    txtBuscarPorDataInicial.Text = string.Empty;
                    txtBuscarPorDataFinal.Text = string.Empty;
                }
                else
                {
                    listaLicitacao = licitacaoBO.BuscarTodasLicitacoes();
                    gvLicitacao.DataSource = listaLicitacao;
                    gvLicitacao.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbBuscarLicitacaoPorUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioBO usuarioBO = new UsuarioBO();
                IList<Usuario> listaUsuario = new List<Usuario>();

                if (!string.IsNullOrEmpty(txtBuscarPorUsuario.Text))
                {
                    listaUsuario = usuarioBO.BuscarPorNome(txtBuscarPorUsuario.Text);
                    gvBuscarLicitacaoPorUsuario.DataSource = listaUsuario;
                    gvBuscarLicitacaoPorUsuario.DataBind();

                    txtBuscarPorUsuario.Text = string.Empty;
                }
                else
                {
                    listaUsuario = usuarioBO.BuscarTodosUsuarios();
                    gvBuscarLicitacaoPorUsuario.DataSource = listaUsuario;
                    gvBuscarLicitacaoPorUsuario.DataBind();
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewBuscarLicitacaoPorUsuarioModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvBuscarLicitacaoPorUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                licitacaoBO = new LicitacaoBO();
                listaLicitacao = new List<Licitacao>();

                int usuarioID = Convert.ToInt32(gvBuscarLicitacaoPorUsuario.SelectedDataKey.Value);
                listaLicitacao = licitacaoBO.BuscarPorUsuario(usuarioID);

                gvLicitacao.DataSource = listaLicitacao;
                gvLicitacao.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void gvLicitacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                licitacao = new Licitacao();
                licitacaoBO = new LicitacaoBO();

                int licitacaoID = Convert.ToInt32(gvLicitacao.SelectedDataKey.Value);
                licitacao = licitacaoBO.BuscarPorID(licitacaoID);

                hdDetalhesLicitacaoID.Value = licitacao._LicitacaoID.ToString();
                lblDataCadastroLicitacao.Text = licitacao._DataCadastro;
                txtObservacaoDetalhes.Text = licitacao._Observacao;
                
                //mostar todos os itens da licitação.
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBO.BuscarItensDaLicitacao(licitacaoID);
                gvItemLicitacaoDetalhes.DataSource = listaItemLicitacao;
                gvItemLicitacaoDetalhes.DataBind();

                //calcular valor total geral dos detalhes do item da licitação
                CalcularValorTotalGeralItemLicitacaoDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLicitacaoDetalhesModal();", true);
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
                lblLicitacaoNovoTitulo.Text = "Atualizar Estoque";
                lblLicitacaoNovoTitulo.CssClass = "fa fa-pencil";

                licitacao = new Licitacao();
                licitacaoBO = new LicitacaoBO();

                licitacao = licitacaoBO.BuscarPorID(Convert.ToInt32(hdDetalhesLicitacaoID.Value));

                hdLicitacaoID.Value = licitacao._LicitacaoID.ToString();
                txtDataCadastroLicitacao.Text = licitacao._DataCadastro;
                txtObservacao.Text = licitacao._Observacao;
                              

                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBO.BuscarItensDaLicitacao(Convert.ToInt32(hdLicitacaoID.Value));
                gvItemLicitacao.DataSource = listaItemLicitacao;
                gvItemLicitacao.DataBind();

                LimparFormularioDetalhes();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openNovaLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemLicitacaoDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoDetalhesModal();", true);
        }

        protected void lkbCancelarDetalhes_Click(object sender, EventArgs e)
        {
            LimparFormularioDetalhes();
        }

        protected void lkbVisualizarLicitacaoDetalhesModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openLicitacaoDetalhesModal();", true);
        }


        #endregion

        #region (Eventos do timer de atualização do gridview Principal e dos contadores de quantidade)

        protected void timerAtualizacaoTelaPrincipal_Tick(object sender, EventArgs e)
        {
            //Método para mostrar os itens do estoque atual
            MostrarItensDoEstoque();

            //Método para verificar se o estoque está baixo e manda uma mensagem
            VerificaSeEstoqueEstaBaixoMensagem();

            //Método para mostrar os itens que estão com o estoque baixo
            MostrarItensComEstoqueBaixo();

            //Método para atulizar preço médio dos produtos que estão em todas as operações.
            ProdutoBO produtoBO = new ProdutoBO();
            produtoBO.AtualizarPrecoUnitarioMedioEstoque();
        }

        protected void timerContadoresTelaPrincipal_Tick(object sender, EventArgs e)
        {
            //Método para atualizar os contadores de quantidade e valor geral
            AtualizarContadores();
        }

        protected void lkbMostrarItensComEstoqueBaixo_Click(object sender, EventArgs e)
        {
            gvLicitacaoProdutoEstoqueBaixo.DataSource = null;
            gvLicitacaoProdutoEstoqueBaixo.DataBind();

            //Método para mostrar os itens que estão com o estoque baixo
            MostrarItensComEstoqueBaixo();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "opengvLicitacaoProdutoEstoqueBaixoModal();", true);
        }

        #endregion


        #region (Eventos ItemLicitação)
        protected void lkbAdicionarItemLicitacaoModal_Click(object sender, EventArgs e)
        {
            try
            {
                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBO.BuscarItensDaLicitacao(Convert.ToInt32(txtLicitacaoID.Text));
                gvItemLicitacao.DataSource = listaItemLicitacao;
                gvItemLicitacao.DataBind();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarAdicionarItemLicitacaoModal_Click(object sender, EventArgs e)
        {
            //txtLicitacaoID.Text = string.Empty;
            //hdLicitacaoIDRetornado.Value = "0";

            //LimparFormulario();
        }

        //Método para editar um item do estoque
        protected void gvItemLicitacao_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Buscar um item do estoque pelo id
                licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                int itemLicitacaoID = Convert.ToInt32(gvItemLicitacao.DataKeys[e.RowIndex].Value);
                itemLicitacao = itemLicitacaoBO.BuscarPorID(itemLicitacaoID);


                //Buscar o produto pelo id do produto que veio do item da licitação
                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto = produtoBO.BuscarPorID(itemLicitacao._Produto._ProdutoID);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastroProduto.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeEstoque.Text = produto._QuantidadeEstoque.ToString();

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

        //Método para editar um item do estoque da tela principal
        protected void gvItemLicitacaoTelaPrincipal_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Buscar um item do estoque pelo id
                licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                int itemLicitacaoID = Convert.ToInt32(gvItemLicitacaoTelaPrincipal.DataKeys[e.RowIndex].Value);
                itemLicitacao = itemLicitacaoBO.BuscarPorID(itemLicitacaoID);


                //Buscar o produto pelo id do produto que veio do item da licitação
                Produto produto = new Produto();
                ProdutoBO produtoBO = new ProdutoBO();

                produto = produtoBO.BuscarPorID(itemLicitacao._Produto._ProdutoID);

                hdProdutoID.Value = produto._ProdutoID.ToString();
                txtCodigo.Text = produto._Codigo;
                txtDataCadastroProduto.Text = produto._DataCadastro;
                txtProdutoNome.Text = produto._ProdutoNome;
                txtProdutoPrecoUnitario.Text = produto._ProdutoPrecoUnitario.ToString();
                txtQuantidadeEstoque.Text = produto._QuantidadeEstoque.ToString();

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

        //Método para excluir um item do estoque
        protected void gvItemLicitacao_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //exclui um item da Licitação
                licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                int itemLicitacaoID = Convert.ToInt32(gvItemLicitacao.DataKeys[e.RowIndex].Value);
                itemLicitacao._ItemLicitacaoID = Convert.ToInt32(itemLicitacaoID);
                itemLicitacaoBO.Excluir(itemLicitacao);


                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBOBuscar = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBOBuscar.BuscarItensDaLicitacao(Convert.ToInt32(txtLicitacaoID.Text));
                gvItemLicitacao.DataSource = listaItemLicitacao;
                gvItemLicitacao.DataBind();


                Mensagem("Produto foi Excluído do Estoque com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        //Método para excluir um item da licitação da tela principal
        protected void gvItemLicitacaoTelaPrincipal_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //exclui um item da Licitação
                licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                int itemLicitacaoID = Convert.ToInt32(gvItemLicitacaoTelaPrincipal.DataKeys[e.RowIndex].Value);
                itemLicitacao._ItemLicitacaoID = Convert.ToInt32(itemLicitacaoID);
                itemLicitacaoBO.Excluir(itemLicitacao);

                //Busca o id da última licitação cadastrada
                licitacao = new Licitacao();
                licitacaoBO = new LicitacaoBO();

                licitacao = licitacaoBO.BuscarPorUltimaLicitacao();
                int licitacaoID = licitacao._LicitacaoID;  


                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBOBuscar = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBOBuscar.BuscarItensDaLicitacao(licitacaoID);
                gvItemLicitacaoTelaPrincipal.DataSource = listaItemLicitacao;
                gvItemLicitacaoTelaPrincipal.DataBind();

                //calcular valor total geral  do item da licitação da tela Principal
                CalcularValorTotalGeralItemLicitacaoTelaPrincipal();

                Mensagem("Produto foi Excluído do Estoque com Sucesso.", this);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbFinalizarAdicionarItemModal_Click(object sender, EventArgs e)
        {
            //txtLicitacaoID.Text = string.Empty;
            //hdLicitacaoIDRetornado.Value = "0";

            //LimparFormulario();

            Mensagem("Finalizado com Sucesso.", this);
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
                produto._QuantidadeEstoque = Convert.ToInt32(txtQuantidadeEstoque.Text);
                produto._EstoqueValorTotal = Convert.ToDecimal(produto._ProdutoPrecoUnitario * produto._QuantidadeEstoque);

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
                    licitacao = new Licitacao();
                    ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                    ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                    int produtoID = Convert.ToInt32(produto2._ProdutoID);

                    itemLicitacao._Produto._ProdutoID = produtoID;
                    itemLicitacao._Licitacao._LicitacaoID = Convert.ToInt32(txtLicitacaoID.Text);

                    itemLicitacaoBO.Salvar(itemLicitacao);
                }
                                
                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBOBuscar = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBOBuscar.BuscarItensDaLicitacao(Convert.ToInt32(txtLicitacaoID.Text));
                gvItemLicitacao.DataSource = listaItemLicitacao;
                gvItemLicitacao.DataBind();

                LimparFormularioProduto();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbCancelarProduto_Click(object sender, EventArgs e)
        {
            LimparFormularioProduto();
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

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
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

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
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

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
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
                licitacao = new Licitacao();
                ItemLicitacao itemLicitacao = new ItemLicitacao(licitacao);
                ItemLicitacaoBO itemLicitacaoBO = new ItemLicitacaoBO();

                int produtoID = Convert.ToInt32(gvProduto.SelectedDataKey.Value);

                itemLicitacao._Produto._ProdutoID = produtoID;
                itemLicitacao._Licitacao._LicitacaoID = Convert.ToInt32(txtLicitacaoID.Text);

                itemLicitacaoBO.Salvar(itemLicitacao);


                //mostar todos os itens da Licitação
                IList<ItemLicitacao> listaItemLicitacao = new List<ItemLicitacao>();
                ItemLicitacaoBO itemLicitacaoBOBuscar = new ItemLicitacaoBO();

                listaItemLicitacao = itemLicitacaoBOBuscar.BuscarItensDaLicitacao(Convert.ToInt32(txtLicitacaoID.Text));
                gvItemLicitacao.DataSource = listaItemLicitacao;
                gvItemLicitacao.DataBind();

                Mensagem("Produto Adicionado com Sucesso.", this);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
            }
            catch (Exception ex)
            {
                Mensagem(ex.Message, this);
            }
        }

        protected void lkbVisualizarGridViewItemLicitacaoModal_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openGridViewItemLicitacaoModal();", true);
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