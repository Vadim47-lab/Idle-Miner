using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(Ore))]
public class OreView : MonoBehaviour
{
    [SerializeField] private MeshRenderer _renderer;
    [SerializeField] private Color _emptyColor;

    private Ore _ore;
    private Color _notEmptyColor;

    private void OnEnable()
    {
        _renderer = GetComponent<MeshRenderer>();
        _ore = GetComponent<Ore>();

        _notEmptyColor = _renderer.material.color;
    }

    private void Update()
    {
        
    }
}