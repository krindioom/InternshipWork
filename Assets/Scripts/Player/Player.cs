using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [Min(0)]
    [SerializeField]
    private float _speed = 0;

    [Header("Camera")]
    [SerializeField]
    private Camera _mainCamera;

    private PlayerMovement _movement;
    private PlayerRotation _rotation;

    private void Awake()
    {
        _movement = new PlayerMovement(transform, _speed);
        _rotation = new PlayerRotation(transform);
    }

    private void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        _movement.Move(direction);
    }

    private void Rotate()
    {
        Vector3 cursourWorldPosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        _rotation.LookAt(cursourWorldPosition);
    }
}
