namespace RasperryClient.Droid._DependencyInjection
{
    public interface IRasperryClientContainer
    {
        T Resolve<T>();
    }
}