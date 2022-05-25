namespace GSCObras.MedicaoServico.Core.Entidades
{
    public enum PagamentoSituacao
    { 
        Pendente = 0,
        Pago = 1,
        Cancelado = 2
    }

    public class MedicaoOrdemServicoPagamento : EntidadeBase
    {
        public string ObraId { get; set; }
        public string Janela { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public PagamentoSituacao Situacao { get; set; }
        public decimal Valor { get; set; }
    }
}
