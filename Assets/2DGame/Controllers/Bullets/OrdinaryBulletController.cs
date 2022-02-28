using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class OrdinaryBulletController : MonoBehaviour
{
    [SerializeField] private OrdinaryBulletConfig _config;

    private void Start()
    {
        Destroy(gameObject, _config.lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.up * _config.moveSpeed * Time.deltaTime);
    }
}
