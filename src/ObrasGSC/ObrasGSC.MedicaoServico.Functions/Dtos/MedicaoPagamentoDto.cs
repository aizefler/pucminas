namespace ObrasGSC.MedicaoServico.Functions.Dtos
{
    public class MedicaoPagamentoDto
    {
        public string ObraId { get; set; }
        public string Janela { get; set; }
        public string FornecedorNome { get; set; }
        public string FornecedorCNPJ { get; set; }
        public string Situacao { get; set; }
        public decimal Valor { get; set; }

    }
}
