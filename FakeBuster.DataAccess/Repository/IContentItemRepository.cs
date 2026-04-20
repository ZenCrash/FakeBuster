using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface IContentItemRepository
  {
    public Task<ContentItem?> Get(int id);
    public Task<List<ContentItem>> GetAll();
    public Task Create(ContentItem entity);
    public Task Update(ContentItem entity);
    public Task Delete(int id);
  }
}
