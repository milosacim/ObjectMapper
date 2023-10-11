namespace ObjectConversion
{
    public interface ICustomMapper
    {
        TDestination MapObject<TSource, TDestination>(TSource source, Action<TDestination>? customMap = null) where TDestination : class, new();
        List<TDestination> MapObjects<TSource, TDestination>(List<TSource> source, Action<TDestination>? customMap = null) where TDestination : class, new();
    }
}
