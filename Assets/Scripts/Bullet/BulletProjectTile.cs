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

    [Header("Area Handlers")]
    [SerializeField]
    private TriggerHandler _triggerHandler; 

    private void Awake()
    {
        _triggerHandler.OnTriggerEntered += ApplyAreaTriggerEnter;
    }

    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        _triggerHandler.OnTriggerEntered -= ApplyAreaTriggerEnter;
    }

    private void Move()
    {
        transform.position += transform.up * Time.deltaTime * _speed;
    }

    private void ApplyAreaTriggerEnter(Collider2D collider)
    {
        if (!collider.TryGetComponent(out Enemy _))
        {
            
            return;
        }
        Debug.Log("a");
        Destroy(collider.gameObject);
        Destroy(gameObject);
    }
}
