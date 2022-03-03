using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAirplaneController : AirplaneController
{
    [SerializeField] private PlayerAirplaneConfig _config;

    private protected override void Awake()
    {
        base.Awake();
        _config = Resources.Load<PlayerAirplaneConfig>(name);
    }

    private protected override void Move()
    {
        transform.Translate(Vector3.up * _config.moveSpeed * Time.deltaTime);
    }
    private protected override void Rotate()
    {
        int angle = 0;
        if (Input.GetKey(KeyCode.A))
            angle = -1;
        else if (Input.GetKey(KeyCode.D))
            angle = 1;
        transform.Rotate(Vector3.back, angle * _config.rotateSpeed * Time.deltaTime);
    }
    private protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Attack!");
    }

}
