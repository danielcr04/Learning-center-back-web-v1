namespace Pc2_Tipo1.API.OTROS_CASOS.INFRASTRUCTURE;

public class ManagerRepository(AppDbContext context) 
    : BaseRepository<Manager>(context), IManagerRepository
{
    /// <inheritdoc />
    public async Task<bool> ExistsByFullNameAsync(string firstName, string lastName)
    {
        return await Context.Set<Manager>()
            .AnyAsync(m => m.FirstName == firstName && m.LastName == lastName);
    }
}