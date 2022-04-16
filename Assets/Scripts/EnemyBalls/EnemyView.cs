using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class EnemyView : MonoBehaviour
{
    private Color _color;
    private MeshRenderer _mesh;
    [SerializeField] private ParticleSystem _particlePrefab;

    private void Awake()
    {
        _mesh = GetComponent<MeshRenderer>();
    }

    public void Initialize(Color color)
    {
        _color = color;
        _mesh.material.color = color;
    }

    public void PlayEffects()
    {
        _particlePrefab = Instantiate(_particlePrefab, transform.position, Quaternion.identity);
        _particlePrefab.startColor = _color;
    }
}
