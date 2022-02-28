using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TurretEnemyController : EnemyController
{
    [SerializeField] private TurretEnemyConfig _config;
    [SerializeField] private Transform _player;
    [SerializeField] private Transform _weapon;
    [SerializeField] private GameObject _bullet;

    private protected override void Execute()
    {
        Rotate();
        Attack();
    }

    private void Rotate()
    {
        var angle = Vector2.Angle(Vector2.up, _player.position - _weapon.position);
        _weapon.eulerAngles = new Vector3(0f, 0f, _weapon.position.y < _player.position.x ? -angle : angle);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Instantiate(_bullet, _weapon.position, _weapon.rotation);
        }
    }
}
