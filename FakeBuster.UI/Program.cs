using FakeBuster.DataAccess.Repository;
using FakeBuster.UI.Components;
using Microsoft.EntityFrameworkCore;

namespace FakeBuster.UI
{
  public class Program
  {
    public static void Main(string[] args)
    {
      var builder = WebApplication.CreateBuilder(args);

      // Add services to the container.
      builder.Services.AddRazorComponents()
          .AddInteractiveServerComponents();

      //DbContext
      builder.Services.AddDbContext<FakeBuster.DataAccess.Data.FakeBusterContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

      //Repositories
      builder.Services.AddScoped<IPersonRepository, PersonRepository>();
      builder.Services.AddScoped<IBookingRepository, BookingRepository>();
      builder.Services.AddScoped<IGenreRepository, GenreRepository>();
      builder.Services.AddScoped<IMovieRepository, MovieRepository>();
      builder.Services.AddScoped<ITvShowRepository, TvShowRepository>();
      builder.Services.AddScoped<IContentItemRepository, ContentItemRepository>();

      var app = builder.Build();

      // Configure the HTTP request pipeline.
      if (!app.Environment.IsDevelopment())
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
      app.UseHttpsRedirection();

      app.UseAntiforgery();

      app.MapStaticAssets();
      app.MapRazorComponents<App>()
          .AddInteractiveServerRenderMode();

      app.Run();
    }
  }
}
