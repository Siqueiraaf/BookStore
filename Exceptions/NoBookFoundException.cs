namespace BookStoreApi.Exceptions
{
    public class NoBookFoundException : Exception
    {
        public NoBookFoundException() : base("Nenhum livro encontrado")
        {}
    }
}