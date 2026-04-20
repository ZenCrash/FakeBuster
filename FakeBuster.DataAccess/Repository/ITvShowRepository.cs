using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface ITvShowRepository
  {
    public Task<TvShow?> Get(int id);
    public Task<List<TvShow>> GetAll();
    public Task<TvShow> Create(TvShow entity);
    public Task Update(TvShow entity);
    public Task Delete(int id);
  }
}
