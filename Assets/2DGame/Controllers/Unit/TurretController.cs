using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretController : Controller
{
    private protected TurretView _view;

    private protected virtual void Awake()
    {
        _view = GetComponent<TurretView>();
    }

    private protected override void Execute()
    {
        Rotate();
        Attack();
    }

    private protected abstract void Rotate();
    private protected abstract void Attack();
}
