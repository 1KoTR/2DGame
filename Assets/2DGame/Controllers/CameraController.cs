using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CameraController : Controller
{
    private const string Player = nameof(Player);

    [SerializeField] private CameraConfig _config;

    private void Start()
    {
        _config.targetTransform = GameObject.FindGameObjectWithTag(Player).transform;
    }

    private protected override void Execute()
    {
        Move();
    }

    private void Move()
    {
        transform.position = _config.targetTransform.position + new Vector3(0, 0, -15);
    }
}
