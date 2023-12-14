using NPOI.SS.Formula.Functions;

namespace api.Lista.PRO.Interfaces
{
    public interface IBaseReposiory<T> where T : class
    {
        List<T> PegarTodos();
        T PegarUm(int id);
        bool Criar(T entity);
        bool Deletar(T entity);
        bool Editar(T entity);

    }
}
