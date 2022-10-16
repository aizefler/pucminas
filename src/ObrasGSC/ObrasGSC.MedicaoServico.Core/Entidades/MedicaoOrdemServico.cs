namespace GSCObras.MedicaoServico.Core.Entidades
{
    public class MedicaoOrdemServico : EntidadeBase
    {
        public Obra Obra { get; set; }
        public string Janela { get; set; }
        public string Situacao { get; private set; }
        
        public List<MedicaoOrdemServicoItem> Medicoes { get; set; }


        public void EncerrarJanela()
        {
            if (this.Situacao != "ABERTO")
            {
                new ApplicationException($"Período de medição {Janela}, já foi encerrado.");
            }

            this.Situacao = "ENCERRADO";
        }

        public void AbrirJanela()
        {
            if (this.Situacao == "ENCERRADO")
            {
                new ApplicationException($"Período de medição {Janela}, não pode ser aberto, pois já foi fechado.");
            }

            this.Situacao = "ABERTO";
        }

    }
}
