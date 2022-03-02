using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class AirplaneView : UnitView
{
    private const string Engine = nameof(Engine);

    public GameObject engine;

    private protected override void Awake()
    {
        base.Awake();
        engine = transform.Find(Engine).gameObject;
    }
}
