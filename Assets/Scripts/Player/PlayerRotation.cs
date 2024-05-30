using UnityEngine;

public class PlayerRotation
{
    private readonly Transform _playerTransform;

    public PlayerRotation(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }

    public void LookAt(Vector3 target)
    {
        float angleRad = Mathf.Atan2(target.y - _playerTransform.position.y, target.x - _playerTransform.position.x);
        float angleDeg = angleRad * Mathf.Rad2Deg - 90f;

        _playerTransform.localRotation = Quaternion.Euler(0, 0, angleDeg);
    }
}
