using System;
using UnityEngine;

public class Miner : MonoBehaviour
{
    [SerializeField] private Mine _mine;
    [SerializeField] private float _speed;
    [SerializeField] private float _handsLength;

    private Ore _current;
    private float _ore;

    private void OnValidate()
    {
        _speed = Mathf.Clamp(_speed, 0, float.MaxValue);
        _handsLength = Mathf.Clamp(_handsLength, 0, float.MaxValue);
    }

    private void OnEnable()
    {
        if (_mine == null)
        {
            enabled = false;
            throw new ArgumentOutOfRangeException(nameof(_mine));
        }
    }

    private void Update()
    {
        if (Valid())
        {
            Update(_current);
        }
        else
        {
            _current = _mine.TryGetClosest();
        }
    }

    private bool Valid()
    {
        return _current != null && _current.Empty == false;
    }

    private void Update(Ore ore)
    {
        transform.position = Vector3.MoveTowards(transform.position, _current.transform.position, _handsLength);

        if (Vector3.Distance(transform.position, _current.transform.position) <= _handsLength)
        {
            _current.TryMine(Time.deltaTime, out float mined);
            _ore += mined;
        }
    }
}