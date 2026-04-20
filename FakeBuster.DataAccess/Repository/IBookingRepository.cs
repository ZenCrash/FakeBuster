using System;
using System.Collections.Generic;
using System.Text;
using FakeBuster.DataAccess.Models;

namespace FakeBuster.DataAccess.Repository
{
  public interface IBookingRepository
  {
    public Task<Booking?> Get(int id);
    public Task<List<Booking>> GetAll();
    public Task Create(Booking entity);
    public Task Update(Booking entity);
    public Task Delete(int id);
  }
}
