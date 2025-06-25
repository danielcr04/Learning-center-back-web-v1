namespace Pc2_Tipo1.API.OTROS_CASOS.APPLICATION;


/// <summary>
/// Handles commands related to the Manager aggregate in the Veterinary Campaign.
/// </summary>
/// <param name="managerRepository">Repository for managing managers</param>
/// <param name="unitOfWork">Unit of Work for transaction management</param>
public class ManagerCommandService(
    IManagerRepository managerRepository,
    IUnitOfWork unitOfWork)
    : IManagerCommandService
{
    /// <inheritdoc />
    public async Task<Manager?> Handle(CreateManagerCommand command)
    {
        try
        {
            // Verify name uniqueness
            var exists = await managerRepository.ExistsByFullNameAsync(command.FirstName!, command.LastName!);
            if (exists)
                throw new ArgumentException("A manager with the same first name and last name already exists.");

            // Create aggregate
            var manager = new Manager(command);

            // Persist
            await managerRepository.AddAsync(manager);
            await unitOfWork.CompleteAsync();

            return manager;
        }
        catch (Exception)
        {
            // Optionally log the exception
            return null;
        }
    }
}