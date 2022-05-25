using Newtonsoft.Json;

namespace GSCObras.MedicaoServico.Core.Entidades
{
    public class ObraEAP : EntidadeBase
    {
        public string Unidade { get; set; }
        public string Etapa { get; set; }
        public Obra Obra { get; set; }
        public DateTime DataInicioPrevisto { get; set; }
        public DateTime DataFimPrevisto { get; set; }
        public DateTime? DataInicioReal { get; set; }
        public DateTime? DataFimReal { get; set; }
    }
}
