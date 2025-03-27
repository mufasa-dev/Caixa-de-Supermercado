using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV
{
    class Produto
    {
        //Produto
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int Quantidade { get; set; }

        public string Imagem { get; set; }

        //Construtores
        public Produto ()
        {
            //Vazio
        }

        public Produto (int codigo, string descricao, double precoUnitario, int quantidade, string imagem)
        {
            this.Codigo = codigo;
            this.Descricao = descricao;
            this.PrecoUnitario = precoUnitario;
            this.Quantidade = quantidade;
            this.Imagem = imagem;

        }

        private List<Produto> getProdutos()
        {
            List<Produto> listaProdutos = new List<Produto>();
            listaProdutos.Add(new Produto(0, "DESCRIÇÃO DO PRODUTO", 0.00, 0, "item1.png"));
            listaProdutos.Add(new Produto(1,"Mamão",7.50,1, "item1.png"));
            listaProdutos.Add(new Produto(2, "Melancia", 10.10, 1, "item1.png"));
            listaProdutos.Add(new Produto(3, "Pera", 10.20, 1, "item1.png"));
            listaProdutos.Add(new Produto(4, "Batata", 5.50, 1, "item1.png"));
            listaProdutos.Add(new Produto(5, "Cenoura", 6.10, 1, "item1.png"));
            listaProdutos.Add(new Produto(6, "Limão", 2.50, 1, "item1.png"));
            listaProdutos.Add(new Produto(7, "Alho", 4.30, 1, "item1.png"));
            listaProdutos.Add(new Produto(8, "Alface", 3.10, 1, "item1.png"));
            listaProdutos.Add(new Produto(9, "Maçã", 7.40, 1, "http://www.tapetesoasis.com.br/imagens/get/id/100/w/28/i/"));
            listaProdutos.Add(new Produto(10, "Maracujá", 8.50, 1, "item1.png"));

            return listaProdutos;
        }

        public Produto buscaPorCodigo(int codigo)
        {
            Produto produtoBusca = null;
            foreach (var produto in getProdutos())
            {
                if (produto.Codigo == codigo)
                {
                    produtoBusca = produto;
                    break;
                }
            }
            return produtoBusca;
        }

    }
}
