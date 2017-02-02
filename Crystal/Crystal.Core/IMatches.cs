namespace Crystal.Core
{
    public interface IMatches<T>
    {
        bool Matches(T other);
    }
}