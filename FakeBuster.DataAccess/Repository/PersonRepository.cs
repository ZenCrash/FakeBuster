using FakeBuster.DataAccess.Data;
using FakeBuster.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.DataAccess.Repository
{
  public class PersonRepository : IPersonRepository
  {
    private readonly FakeBusterContext _context;

    public PersonRepository(FakeBusterContext context)
    {
      _context = context;
    }

    public async Task<Person?> Get(int id)
    {
      return await _context.Persons
        .Include(p => p.Address)
        .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Person?> GetByEmail(string email)
    {
      return await _context.Persons
        .Include(p => p.Address)
        .FirstOrDefaultAsync(p => p.Email == email);
    }

    public async Task<List<Person>> GetAll()
    {
      return await _context.Persons
        .Include(p => p.Address)
        .ToListAsync();
    }

    public async Task Create(Person person)
    {
      await _context.Persons.AddAsync(person);
      await _context.SaveChangesAsync();
    }

    public async Task Update(Person person)
    {
      _context.Persons.Update(person);
      await _context.SaveChangesAsync();
    }

    public async Task Delete(int id)
    {
      await _context.Persons
        .Where(p => p.Id == id)
        .ExecuteDeleteAsync();
    }
  }
}
