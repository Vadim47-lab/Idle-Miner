using System.Linq;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Ore[] _ore;

    private void Awake()
    {
        _ore = transform.GetComponentsInChildren<Ore>(); 
    }

    public Ore TryGetClosest()
    {
        Ore[] notEmptyOre = _ore.Where(ore => ore.Empty == false).ToArray();

        if (notEmptyOre.Length == 0)
        {
            return null;
        }

        return _ore.Closest(new Vector3(1, 1, 1));
    }
}