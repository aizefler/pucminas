using ObrasGSC.MedicaoServico.Core.Entidades;

namespace ObrasGSC.MedicaoServico.Infra.Data.Comum
{
    /// <summary>
    ///  Defines the container level context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IContainerContext<T> where T : EntidadeBase
    {
        string ContainerName { get; }    }
}
