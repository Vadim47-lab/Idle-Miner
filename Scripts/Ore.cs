using System;
using UnityEngine;

public class Ore : MonoBehaviour
{
    [SerializeField] private float _amount;
    [SerializeField] private float _amountPerSecond;

    public bool Empty => _amount <= 0;

    public event Action AmountChanged;

    private void OnValidate()
    {
        _amount = Mathf.Clamp(_amount, 0, float.MaxValue);
        _amountPerSecond = Mathf.Clamp(_amountPerSecond, 0, float.MaxValue);
    }

    public bool TryMine(float time, out float mined)
    {
        if (time <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(time));
        }

        float mightMined = _amountPerSecond * time;
        mined = Mathf.Clamp(mightMined, 0, _amount);
        _amount -= mined;

        AmountChanged?.Invoke();

        return mightMined == mined;
    }
}