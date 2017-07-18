
namespace BookLogic
{
    public interface ITagComparer<T>//??
    {
        int TagCompare(T lhs, T rhs);
    }
}
