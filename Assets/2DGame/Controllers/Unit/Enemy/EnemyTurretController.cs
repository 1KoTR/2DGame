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
        if (Vector2.Distance(transform.position, _targetTransform.position) <= _config.attackDistance)
        {
            Rotate();
            Attack();
        }
    }

    private protected override void Rotate()
    {
        var angle = Vector2.Angle(Vector2.right, _targetTransform.position - _weaponTransform.position);
        _weaponTransform.eulerAngles = new Vector3
            (
                0, 0, 
                (_weaponTransform.position.y < _targetTransform.position.y ? angle : -angle)
                //* _config.rotateSpeed
                //* Time.deltaTime
            );
    }
    private protected override void Attack()
    {

    }

    void OnDrawGizmos()
    {
        var config = Resources.Load<EnemyTurretConfig>(name);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, config.attackDistance);
    }
}
