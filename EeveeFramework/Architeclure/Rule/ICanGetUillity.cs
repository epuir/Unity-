namespace Framework
{
    public interface ICanGetUillity:IBelongToArchitecture
    {
        
    }

    public static class CangetUillityExtension
    {
        public static T GetUillity<T>(this ICanGetUillity self) where T : class, IUtility
        {
            return self.GetAchitecture().GetUtility<T>();
        }
    }
}