public class Repository<T> where T :class
{
    private List<T> items=new();
    
    public void add(T item)
    {
        items.Add(item);
    }

    public IReadOnlyList<T> GetAll()
    {
        return items;
    }

    public T? Find(Func<T,bool> predicate)
    {
        return items.FirstOrDefault(predicate);
    }
}