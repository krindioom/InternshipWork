using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementService
{
    private readonly Transform _playerTransform;
    private readonly float _movementSpeed;

    public MovementService(Transform playerTransform, float movementSpeed)
    {
        _playerTransform = playerTransform;
        _movementSpeed = movementSpeed;
    }

    public void Move(Vector2 direction)
    {
        float multiplier = Time.deltaTime * _movementSpeed;
        Vector2 modifiedDirection = direction.normalized * multiplier;
        _playerTransform.Translate(modifiedDirection, Space.World);
    }
}
