using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class BookingRepository : IBookingRepository  
  {
    private readonly FakeBusterContext _context;

    public BookingRepository(FakeBusterContext context)
    {
      _context = context;
    }

    public async Task<Booking?> Get(int id)
    {
      return await _context.Bookings
        .Include(b => b.Person)
        .Include(b => b.ContentItems)
          .ThenInclude(x => x.Movie)
        .Include(b => b.ContentItems)
          .ThenInclude(x => x.TvShow)
        .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Booking>> GetAll()
    {
      return await _context.Bookings
        .Include(b => b.Person)
        .Include(b => b.ContentItems)
          .ThenInclude(x => x.Movie)
        .Include(b => b.ContentItems)
          .ThenInclude(x => x.TvShow)
        .ToListAsync();
    }

    public async Task Create(Booking entity)
    {
      await _context.Bookings.AddAsync(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Update(Booking entity)
    {
      _context.Bookings.Update(entity);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.Bookings
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
