namespace FilmesAPI.Data.Daos
{
    public interface IQuery<T>
    {
        public IEnumerable<T> Listar();

        public T ObterPorId(int id);
    }
}
