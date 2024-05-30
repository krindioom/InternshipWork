using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting
{
    private readonly Transform _shootingPoint;
    private readonly BulletProjectTile _projectTile;

    public PlayerShooting(Transform shootingPoint, BulletProjectTile projectTile)
    {
        _shootingPoint = shootingPoint;
        _projectTile = projectTile;
    }

    public void Shoot()
    {
        var projectTileGO = Object.Instantiate(_projectTile);
        projectTileGO.transform.position = _shootingPoint.position;
        projectTileGO.transform.rotation = _shootingPoint.rotation;
    }
}
