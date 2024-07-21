using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class EnumerableExtension 
{
    public static T GetRandomElementInList<T>( this IEnumerable<T> elements )
    {
        var randomElement = Random.Range(0, elements.Count());

        T returnValue = elements.ElementAt(randomElement);

        return returnValue;
    }

    //public static bool GetNeighborExist<T, A>(this IEnumerable<T> elements, A t1, A t2)
    //{
    //    elements.Key
    //    return elements.Contains(t1) && elements.Contains(t2);
    //}
}
