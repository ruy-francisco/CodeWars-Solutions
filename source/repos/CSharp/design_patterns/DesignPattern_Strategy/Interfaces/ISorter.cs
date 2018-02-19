namespace DesignPattern_Strategy.Interfaces
{
    using System.Collections.Generic;

    public interface ISorter<T>
    {
        List<T> Sort(List<T> input);
    }
}
