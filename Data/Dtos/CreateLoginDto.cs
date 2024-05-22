namespace autenticacao.Data.Dtos
{
    public record CreateLoginDto
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
