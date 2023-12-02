namespace CleanSoftware.Domain.Services
{
    public delegate TIdentifier IdentifierFactoryService<TIdentifier>()
         where TIdentifier : notnull;
}
