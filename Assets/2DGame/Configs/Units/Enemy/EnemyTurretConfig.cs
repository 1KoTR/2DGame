using UnityEngine;

[CreateAssetMenu(menuName = "Config/Unit Config/Enemy Config/Turret Config")]
public sealed class EnemyTurretConfig : TurretConfig
{
    public Transform target = null;

    public float attackDistance = 10;
}