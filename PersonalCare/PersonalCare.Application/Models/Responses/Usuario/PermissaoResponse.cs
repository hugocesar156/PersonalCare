using System.Text.Json.Serialization;

namespace PersonalCare.Application.Models.Responses.Usuario
{
    public class PermissaoResponse
    {
        public PermissaoResponse(int _id, string _nome, string? _descricao)
        {
            Id = _id;
            Nome = _nome;
            Descricao = _descricao;
        }

        public int Id { get; }
        public string Nome { get; }
        public string? Descricao { get; }
    }
}
