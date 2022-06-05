using System.Collections;
using System.Collections.ObjectModel;


namespace HM.Core.Extensions;

public static class ListExtensions
{
    public static bool IsNullOrEmpty(this IList list) => list == null || list.Count == 0;
    public static bool AnyNotNull<T>(this IEnumerable<T> source) => source != null && source.Any();
    public static bool AnyNotNull<T>(this IEnumerable<T> source, Func<T, bool> predicate) => source != null && source.Any(predicate);
    public static bool IsNotNullAndNotZero(this int? value) => value != null && value != 0;
    public static bool IsNotNullAndNotZero(this List<int> source) => source != null && source.Any() && source.Count > 0 && source.First() != (default);
    public static void Sort<TSource, TKey>(this ObservableCollection<TSource> observableCollection, Func<TSource, TKey> selector)
    {
        var collections = observableCollection.OrderBy(selector).ToList();
        observableCollection.Clear();
        foreach (var collection in collections)
        {
            observableCollection.Add(collection);
        }
    }
}
