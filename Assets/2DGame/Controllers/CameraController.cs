using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraController : Controller
{
    private const string Player = nameof(Player);

    private Transform _target;

    private protected override void Execute()
    {
        Move();
    }

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag(Player).transform;
    }

    private void Move()
    {
        transform.position = _target.position + new Vector3(0, 0, transform.position.z);
    }
}
