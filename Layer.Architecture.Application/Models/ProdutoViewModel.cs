using System;

namespace AutoglassTest.Application.Models
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public char Situacao { get; set; }

        public DateTime DataFabricacao { get; set; }

        public DateTime DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }

        public string DescricaoFornecedor { get; set; }

        public string CNPJFornecedor { get; set; }

    }
}
