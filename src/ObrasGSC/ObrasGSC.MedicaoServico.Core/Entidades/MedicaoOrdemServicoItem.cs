namespace ObrasGSC.MedicaoServico.Core.Entidades
{
    public class MedicaoOrdemServicoItem
    {
        public string Id { get; set; }
        public OrdemServico OrdemServico { get; set; }
        public Decimal Quantidade { get; set; }
    }
}
