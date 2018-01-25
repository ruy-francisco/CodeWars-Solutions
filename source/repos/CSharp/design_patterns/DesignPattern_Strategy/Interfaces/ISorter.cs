namespace DesignPattern_Strategy.Interfaces
{
    using System.Collections.Generic;

    public interface ISorter<T>
    {
        IList<T> Sort(IList<T> input);
    }
}
