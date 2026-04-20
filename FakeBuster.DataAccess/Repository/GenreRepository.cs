using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class GenreRepository : IGenreRepository
  {
    private readonly FakeBusterContext _context;
    public GenreRepository(FakeBusterContext context)
    {
      _context = context;
    }


    public async Task<Genre?> Get(int id)
    {
      return await _context.Genres
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Genre>> GetAll()
    {
      return await _context.Genres
        .ToListAsync();
    }

    public async Task Create(Genre entity)
    {
      await _context.Genres.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(Genre entity)
    {
      _context.Genres.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.Genres
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
