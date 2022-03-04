using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public sealed class EnemyTurretController : TurretController
{
    private const string Player = nameof(Player);

    [SerializeField] private EnemyTurretConfig _config;

    private Transform _targetTransform;
    private Transform _weaponTransform;

    private protected override void Awake()
    {
        base.Awake();
        _config = Resources.Load<EnemyTurretConfig>(name);
    }

    private void Start()
    {
        _config.target = GameObject.FindGameObjectWithTag(Player).transform;

        _targetTransform = _config.target;
        _weaponTransform = _view.weapon.transform;
    }

    private protected override void Execute()
    {
        var distance = Vector2.Distance(_weaponTransform.position, _targetTransform.position);
        if (distance < _config.rotateDistance)
        {
            Rotate();
            if (distance < _config.attackDistance)
                Attack();
        }
    }

    private protected override void Rotate()
    {
        Vector2 rot = _targetTransform.position - _weaponTransform.position;
        _weaponTransform.up = Vector2.MoveTowards(_weaponTransform.up, rot, _config.rotateSpeed * Time.deltaTime);
    }
    private float nextAttack = 0;
    private protected override void Attack()
    {
        var t = Time.time; 
        if (t > nextAttack)
        {
            nextAttack = t + 1f / _config.attackRate;
            Instantiate(_config.bullet, _weaponTransform.position, _weaponTransform.rotation);
        }
    }

    void OnDrawGizmos()
    {
        var config = Resources.Load<EnemyTurretConfig>(name);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, config.attackDistance);
        Gizmos.DrawWireSphere(transform.position, config.rotateDistance);
    }
}
