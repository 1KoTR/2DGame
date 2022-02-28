using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Config/Player Config/Airplane Config")]
public sealed class AirplanePlayerConfig : PlayerConfig
{
    public KeyCode keyMoveRight = KeyCode.D;
    public KeyCode keyMoveLeft = KeyCode.A;

    public float moveSpeed = 5;
    public float angularSpeed = 10;
}
