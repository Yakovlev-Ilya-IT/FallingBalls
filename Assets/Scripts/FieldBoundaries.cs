using UnityEngine;

public class FieldBoundaries : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private float _topBorder, _leftBorder, _rightBorder, _bottomBorder;
    [SerializeField] private float _padding;

    public float BottomBorder => _bottomBorder;

    private void Start()
    {
        _topBorder = _camera.ScreenToWorldPoint(new Vector3(0, _camera.pixelHeight, Mathf.Abs(_camera.transform.position.z))).y;
        _bottomBorder = _camera.ScreenToWorldPoint(new Vector3(0, 0, Mathf.Abs(_camera.transform.position.z))).y;
        _rightBorder = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, 0, Mathf.Abs(_camera.transform.position.z))).x - _padding;
        _leftBorder = _camera.ScreenToWorldPoint(new Vector3(0, 0, Mathf.Abs(_camera.transform.position.z))).x + _padding;
    }

    public Vector3 GetRandomTopPoint()
    {
        return new Vector3(Random.Range(_leftBorder, _rightBorder), _topBorder, 0);
    }
}
