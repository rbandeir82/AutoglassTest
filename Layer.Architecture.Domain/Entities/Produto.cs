using System;

namespace AutoglassTest.Domain.Entities
{
    public class Produto : BaseEntity
    {
        public string Descricao { get; set; }

        public char Situacao { get; set; }

        public DateTime? DataFabricacao { get; set; }

        public DateTime? DataValidade { get; set; }

        public int CodigoFornecedor { get; set; }

        public Fornecedor Fornecedor { get; set; }
        
    }
}
