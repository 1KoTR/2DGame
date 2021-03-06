using System;
using UnityEngine;

public abstract class AirplaneController : Controller
{
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

    private protected abstract void Move();
    private protected abstract void Rotate();
    private protected abstract void Attack();
}