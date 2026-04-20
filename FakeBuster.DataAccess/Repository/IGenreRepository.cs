using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface IGenreRepository
  {
    public Task<Genre?> Get(int id);
    public Task<List<Genre>> GetAll();
    public Task Create(Genre entity);
    public Task Update(Genre entity);
    public Task Delete(int id);
  }
}
