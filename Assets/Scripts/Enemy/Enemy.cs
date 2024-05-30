using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Movement")]
    [Min(0)]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private TriggerHandler _attackAreaHandler;

    [SerializeField]
    private TriggerHandler _viewAreaHandler;

    private Transform _target;

    private MovementService _movement;

    private void Awake()
    {
        _movement = new MovementService(transform, _speed);

        _viewAreaHandler.OnTriggerEntered += ApplyViewAreaTriggerEnter;
        _viewAreaHandler.OnTriggerExited += ApplyViewAreaTriggerExited;
        _attackAreaHandler.OnTriggerEntered += ApplyAttackAreaTriggerEnter;
    }

    private void Update()
    {
        Move();
    }

    private void OnDestroy()
    {
        _viewAreaHandler.OnTriggerEntered -= ApplyViewAreaTriggerEnter;
        _viewAreaHandler.OnTriggerExited -= ApplyViewAreaTriggerExited;
        _attackAreaHandler.OnTriggerEntered -= ApplyAttackAreaTriggerEnter;
    }

    private void Move()
    {
        if (_target is null)
        {
            return;
        }

        var moveDirection = _target.position - transform.position;

        _movement.Move(moveDirection);
    }

    private void ApplyViewAreaTriggerEnter(Collider2D collider)
    {
        if (!collider.TryGetComponent(out Player _))
        {
            return;
        }

        _target = collider.transform;
    }

    private void ApplyViewAreaTriggerExited(Collider2D collider)
    {
        if (!collider.TryGetComponent(out Player _))
        {
            return;
        }

        _target = null;
    }

    private void ApplyAttackAreaTriggerEnter(Collider2D collider)
    {
        if (!collider.TryGetComponent(out Player _))
        {
            return;
        }

       Destroy(collider.gameObject);
    }
}
