using aquaFin.API.AppDbContext;
using aquaFin.API.Entities;
using aquaFin.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace aquaFin.API.Repositories;

public class CommentRepository(AquaFinDbContext context):ICommentRepository
{
   
    public async Task<List<Comment> > GetAll()
    {
        var comments =await context.Comments.ToListAsync();
        return comments;
    }

}