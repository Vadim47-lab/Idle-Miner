using System.Collections.Generic;
using UnityEngine;

public static class ArrayExtension
{
    public static Ore Closest(this IEnumerable<Ore> ores, Vector3 point)
    {
        float minDistance = Mathf.Infinity;
        Ore closestOre = null;

        foreach (Ore ore in ores)
        {
            float distance = Vector3.Distance(point, ore.transform.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestOre = ore;
            }
        }

        return closestOre;
    }
}
