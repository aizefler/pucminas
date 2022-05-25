namespace ObrasGSC.MedicaoServico.Core.Entidades
{
    public class Servico : EntidadeBase
    {
        public string Descricao { get; set; }
        public Decimal Quantidade { get; set; }
        public Decimal Valor { get; set; }
    }
}
