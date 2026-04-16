using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface IPersonRepository
  {
    public Task<Person?> Get(int id);
    public Task<Person?> GetByEmail(string email);
    public Task<List<Person>> GetAll();
    public Task Create(Person person);
    public Task Update(Person person);
    public Task Delete(int id);
  }
}
