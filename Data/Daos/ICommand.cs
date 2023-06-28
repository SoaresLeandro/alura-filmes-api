namespace FilmesAPI.Data.Daos
{
    public interface ICommand<T>
    {

        void Excluir(T obj);
    }
}
