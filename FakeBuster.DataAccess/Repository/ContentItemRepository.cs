using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class ContentItemRepository : IContentItemRepository
  {
    private readonly FakeBusterContext _context;

    public ContentItemRepository(FakeBusterContext context)
    {
      _context = context;
    }

    public async Task<ContentItem?> Get(int id)
    {
      return await _context.ContentItems
        .FirstOrDefaultAsync(p => p.Id == id);
    }


    public async Task<List<ContentItem>> GetAll()
    {
      return await _context.ContentItems
        .ToListAsync();
    }

    public async Task Create(ContentItem entity)
    {
      await _context.ContentItems.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(ContentItem entity)
    {
      _context.ContentItems.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.ContentItems
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
