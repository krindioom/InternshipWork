using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectTile : MonoBehaviour
{
    [Header("Configuration")]
    [Min(0)]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _lifeTime;

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += transform.up * Time.deltaTime * _speed;
    }
}
