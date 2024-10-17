using aquaFin.API.Entities;

namespace aquaFin.API.Interfaces;

public interface ICommentRepository
{
    public Task  <List<Comment>> GetAll();

}