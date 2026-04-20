using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class MovieRepository : IMovieRepository
  {
    private readonly FakeBusterContext _context;

    public MovieRepository(FakeBusterContext context)
    {
      _context = context;
    }

    public async Task<Movie?> Get(int id)
    {
      return await _context.Movies
        .Include(x => x.ContentItems)
        .Include(x => x.Genres)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Movie>> GetAll()
    {
      return await _context.Movies
        .Include(x => x.ContentItems)
        .Include(x => x.Genres)
        .ToListAsync();
    }

    public async Task<Movie> Create(Movie entity)
    {
      await _context.Movies.AddAsync(entity);
      await _context.SaveChangesAsync();
      return entity;
    }

    public async Task Update(Movie entity)
    {
      _context.Movies.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.Movies
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
