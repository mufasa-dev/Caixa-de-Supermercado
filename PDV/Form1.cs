using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV
{
    public partial class Form1 : Form
    {
        //Declara e instancia o objeto produto
        Produto produto = new Produto();

        //declaração lista de objetos da classe produtos
        List<listaProdutos> lista = new List<listaProdutos>();

        public Form1()
        {
            InitializeComponent();
        }

        //Envento
        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            //Recupera o codigo digitado
            int codProduto;
            if (!int.TryParse(txtCodigo.Text, out codProduto))
            {
                codProduto = 0;
            }

            //Busca produto pelo codigo
            Produto prodBusca = produto.buscaPorCodigo(codProduto);

            //Verifica se foi encontrado
            if(prodBusca != null)
            {
                lblDescProduto.Text = prodBusca.Descricao;
                txtPreco.Text = prodBusca.PrecoUnitario.ToString("F2");
                txtQuantidade.Text = Convert.ToString(prodBusca.Quantidade);
                PicIcone.Image = Properties.Resources.item1;
            }
        }

        private void btnIncluir_Click(object sender, EventArgs e)
        {
            int codProduto;
            if (!int.TryParse(txtCodigo.Text, out codProduto))
            {
                return;
            }
            //Recupera os valores do campo de texto e atribui ao objeto
            listaProdutos incluiProduto = new listaProdutos();

            incluiProduto.Descricao = lblDescProduto.Text;
            incluiProduto.Codigo = Convert.ToInt16(txtCodigo.Text);
            incluiProduto.Quantidade = Convert.ToInt16(txtQuantidade.Text);
            incluiProduto.PrecoUnitario = Convert.ToDouble(txtPreco.Text);

     
            double campoTotal = Convert.ToDouble(txtTotal.Text);
            double total = incluiProduto.PrecoUnitario * incluiProduto.Quantidade + campoTotal;
            txtTotal.Text = total.ToString("F2");

            //Adiciona os objetos recuperados a lista
            lista.Add(incluiProduto);

            //nula a referencia da fonte de dados
            dvgProdutos.DataSource = null;

            //Exibe a lista no datadridview
            dvgProdutos.DataSource = lista;

            //Chama o metodo para limpar os campos
            LimpaCamposTexto();
            PicIcone.Image = Properties.Resources.item0;
            this.calcularTroco(null, null);
        }

        public void LimpaCamposTexto()
        {
            lblDescProduto.Text = "DESCRIÇÃO DO PRODUTO";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            txtCodigo.Text = "";
        }

        private void calcularTroco(object sender, EventArgs e)
        {
            int valorRecebido;
            if (!int.TryParse(txtValorRecebido.Text, out valorRecebido))
            {
                txtValorRecebido.Text = "0";
                return;
            }
            var total = Convert.ToDouble(txtTotal.Text);
            var troco = valorRecebido - total;
            txtTroco.Text = troco.ToString("F2");
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            //Recuperar o indice da linha selecionada
            int indiceLinha = dvgProdutos.CurrentRow.Index;

            //double Total = indiceLinha.PrecoUnitario * indiceLinha.incluiProduto.Quantidade;
            //txtTotal.Text = Convert.ToString(Total);

            //Remove lista
            lista.RemoveAt(indiceLinha);

            //chama o método que limpa os campos
            LimpaCamposTexto();
            PicIcone.Image = Properties.Resources.item0;

            //Nula a referncia do campo de dados (limpa as colunas)
            dvgProdutos.DataSource = null;

            //Exibe a lista na datadridview
            dvgProdutos.DataSource = lista;
        }
    }
}
