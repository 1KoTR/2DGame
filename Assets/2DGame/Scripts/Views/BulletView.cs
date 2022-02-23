using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletView : MonoBehaviour // Переделать весь класс!!!
{
    [SerializeField] private float _lifeTime;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        Destroy(gameObject, _lifeTime);
    }

    private void Update()
    {
        transform.position += new Vector3(0, _moveSpeed * Time.deltaTime, 0);
    }
}
