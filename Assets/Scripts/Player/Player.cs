using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [Min(0)]
    [SerializeField]
    private float _speed = 0;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = new PlayerMovement(transform, _speed);
    }

    private void Update()
    {
        Move();
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
}
