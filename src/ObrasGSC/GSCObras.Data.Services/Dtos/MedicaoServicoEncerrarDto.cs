namespace GSCObras.Data.Services.Dtos
{
    public class MedicaoServicoEncerrarDto
    {
        public ObrasDto Obra { get; set; }
        public string Janela { get; set; }
        public string Situacao { get; private set; }
    }
}
