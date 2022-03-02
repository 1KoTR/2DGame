using System;
using UnityEngine;

public abstract class AirplaneController : Controller
{
    public AirplaneConfig config;
    private protected AirplaneView _view;

    private protected virtual void Awake()
    {
        _view = GetComponent<AirplaneView>();
    }

    private protected override void Execute()
    {
        Move();
        Rotate();
        Attack();
    }

    private protected virtual void Move()
    {
        transform.Translate(Vector3.up * config.moveSpeed * Time.deltaTime);
    }
    private protected abstract void Rotate();
    private protected abstract void Attack();
}