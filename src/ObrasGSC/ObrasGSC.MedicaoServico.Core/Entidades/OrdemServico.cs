namespace ObrasGSC.MedicaoServico.Core.Entidades
{
    public enum OrdemServicoSituacao
    { 
        Aberta = 1,
        Fechada = 2,
        Cancelada = 3
    }

    public class OrdemServico : EntidadeBase
    {
        public OrdemServicoSituacao? Situacao { get; set; }
        public int Progresso { get; set; }

        public Obra Obra { get; set; }
        public ObraEAP EAP { get; set; }
        public Fornecedor Fornecedor { get; set; }
        public Servico Servico { get; set; }

    }
}
