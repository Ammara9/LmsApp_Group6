
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LMS.Blazor.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    // De här overrides gjorde att vi inte kunde spara direkt här i blazorprojektet
    // Vi kommenterar bort så länge så att vi har ett sätt att spara och kan bygga allt runt det
    // TODO: Efter att vi fixat så vi kan spara genom backend API kan vi avkommentera här under

    //public override int SaveChanges()
    //{
    //    throw new InvalidOperationException("Use context in API project!!!");
    //}
    //public override int SaveChanges(bool acceptAllChangesOnSuccess)
    //{
    //    throw new InvalidOperationException("Use context in API project!!!");
    //}
    //public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    //{
    //    throw new InvalidOperationException("Use context in API project!!!");
    //}
    //public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    //{
    //    throw new InvalidOperationException("Use context in API project!!!");
    //}
}
