using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface IMovieRepository
  {
    public Task<Movie?> Get(int id);
    public Task<List<Movie>> GetAll();
    public Task<Movie> Create(Movie entity);
    public Task Update(Movie entity);
    public Task Delete(int id);
  }
}
