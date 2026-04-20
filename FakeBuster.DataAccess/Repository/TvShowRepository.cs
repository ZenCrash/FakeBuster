using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class TvShowRepository : ITvShowRepository
  {
    private readonly FakeBusterContext _context;

    public TvShowRepository(FakeBusterContext context)
    {
      _context = context;
    }

    public async Task<TvShow?> Get(int id)
    {
      return await _context.TvShows
        .Include(x => x.ContentItems)
        .Include(x => x.Genres)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<TvShow>> GetAll()
    {
      return await _context.TvShows
        .Include(x => x.ContentItems)
        .Include(x => x.Genres)
        .ToListAsync();
    }

    public async Task<TvShow> Create(TvShow entity)
    {
      await _context.TvShows.AddAsync(entity);
      await _context.SaveChangesAsync();

      return entity;
    }

    public async Task Update(TvShow entity)
    {
      _context.TvShows.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.TvShows
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
