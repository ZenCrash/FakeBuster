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
    public Task Create(Person entity);
    public Task Update(Person entity);
    public Task Delete(int id);
  }
}
