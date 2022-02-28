using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AirplanePlayerController : PlayerController
{
    [SerializeField] private AirplanePlayerConfig _config;
    [SerializeField] private PlayerAirplaneView _view;

    private void Awake()
    {
        _view = GetComponentInChildren<PlayerAirplaneView>();
    }

    private protected override void Execute()
    {
        Move();
        Rotate();
        Attack();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * _config.moveSpeed * Time.deltaTime);
    }
    private void Rotate()
    {
        var rotDir = 0;
        if (Input.GetKey(_config.keyMoveRight))
            rotDir = 1;
        else if (Input.GetKey(_config.keyMoveLeft))
            rotDir = -1;

        transform.Rotate(Vector3.back, rotDir * _config.angularSpeed * Time.deltaTime);
    }
    private void Attack()
    {
        if (Input.GetKeyDown(_config.keyAttack))
        {
            var weaponTransform = _view.weapon.transform;
            Instantiate(_config.bullet, weaponTransform.position, weaponTransform.rotation);
        }
    }
}
