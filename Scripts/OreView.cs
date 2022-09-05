using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Ore))]
public class OreView : MonoBehaviour
{
    [SerializeField] private Color _emptyColor;

    private Ore _ore;
    private Color _notEmptyColor;
    private MeshRenderer _renderer;

    private void OnEnable()
    {
        _renderer = GetComponent<MeshRenderer>();
        _ore = GetComponent<Ore>();

        _notEmptyColor = _renderer.material.color;

        _ore.AmountChanged += OnAmountChanged;
    }

    private void OnDisable()
    {
        _ore.AmountChanged -= OnAmountChanged;
    }

    private void OnAmountChanged()
    {
        if (_ore.Empty)
        {
            _renderer.material.color = _emptyColor;
        }
        else
        {
            _renderer.material.color = _notEmptyColor;
        }
    }
}