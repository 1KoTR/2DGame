using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class OrdinaryBulletController : Controller
{
    private const string Enemy = nameof(Enemy);

    [SerializeField] private Rigidbody2D _rigidbody;

    [SerializeField] private OrdinaryBulletConfig _config;

    private void Start()
    {
        Destroy(gameObject, _config.lifeTime);
    }

    private protected override void Execute()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector3.up * _config.moveSpeed * Time.deltaTime);
    }
}
