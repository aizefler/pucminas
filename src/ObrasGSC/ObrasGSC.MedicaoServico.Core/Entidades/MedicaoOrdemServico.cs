namespace GSCObras.MedicaoServico.Core.Entidades
{
    public class MedicaoOrdemServico : EntidadeBase
    {
        public Obra Obra { get; set; }
        public string Janela { get; set; }
        public string Situacao { get; set; }
        
        public List<MedicaoOrdemServicoItem> Medicoes { get; set; }

    }
}
