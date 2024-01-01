namespace LibraryDifferentialEquations1jan2024
{
    // Indexer on an interface:
    public interface IIndexInterface<T>
    {
        // Indexer declaration:
        T this[int index]
        {
            get;
            set;
        }
    }
}
