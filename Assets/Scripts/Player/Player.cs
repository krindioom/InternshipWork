using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [Min(0)]
    [SerializeField]
    private float _speed;

    private PlayerMovement _movement;

    private void Awake()
    {
        _movement = new PlayerMovement(transform, _speed);
    }
}
