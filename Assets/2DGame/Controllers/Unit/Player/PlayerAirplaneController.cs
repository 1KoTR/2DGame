using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerAirplaneController : AirplaneController
{
    private protected override void Rotate()
    {
        int angle = 0;
        if (Input.GetKey(KeyCode.A))
            angle = -1;
        else if (Input.GetKey(KeyCode.D))
            angle = 1;
        transform.Rotate(Vector3.back, angle * config.rotateSpeed * Time.deltaTime);
    }
    private protected override void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            Debug.Log("Attack!");
    }
}
