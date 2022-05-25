using Newtonsoft.Json;

namespace ObrasGSC.MedicaoServico.Core.Entidades
{
    public abstract class EntidadeBase
    {
        [JsonProperty(PropertyName = "id")]
        public virtual string Id { get; set; }
        public string CriadoPor { get; set; }
        public DateTime CriadoEm { get; set; }
        public string? AlteradoPor { get; set; }
        public DateTime? AlteradoEm { get; set; }

        protected EntidadeBase()
        {
            CriadoEm = DateTime.Now;
        }

    }
}
