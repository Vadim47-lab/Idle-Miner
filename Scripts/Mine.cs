using System.Linq;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Ore[] _ore;

    private void Awake()
    {
        _ore = transform.GetComponentsInChildren<Ore>(); 
    }

    public Ore TryGetClosest(Vector3 point)
    {
        Ore[] notEmptyOre = _ore.Where(ore => ore.Empty == false).ToArray();

        if (notEmptyOre.Length == 0)
        {
            return null;
        }

        point = new Vector3(1, 1, 1);

        return _ore.Closest(point);
    }
}