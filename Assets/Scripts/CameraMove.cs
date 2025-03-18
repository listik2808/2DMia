using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;
    private Vector2 _startPosition;
    private float _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position.x;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _startPosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            float pos = _camera.ScreenToWorldPoint(Input.mousePosition).x - _startPosition.x;
            _targetPosition = Mathf.Clamp(transform.position.x - pos, -557f, 838f);
        }
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, _targetPosition, _speed * Time.deltaTime),transform.position.y,transform.position.z);
    }
}
