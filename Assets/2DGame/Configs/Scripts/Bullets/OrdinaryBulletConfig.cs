using UnityEngine;

[CreateAssetMenu(menuName = "Config/Bullet Config/Ordinary Bullet Config")]
public sealed class OrdinaryBulletConfig : ScriptableObject
{
    public float lifeTime = 5;

    public float moveSpeed = 15;
}