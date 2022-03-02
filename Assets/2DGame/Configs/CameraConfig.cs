using UnityEngine;

[CreateAssetMenu(menuName = "Config/Camera Config")]
public sealed class CameraConfig : ScriptableObject
{
    public Transform targetTransform;
}