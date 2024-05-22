namespace autenticacao.Data.Dtos
{
    public record CreateLoginDto
    {
        public string Nome { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
    }
}
