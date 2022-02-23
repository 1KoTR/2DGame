using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterView : MonoBehaviour // Переделать весь класс!!!
{
    private Animator _animator;

    [SerializeField] private Transform _weaponPoint;
    [SerializeField] private BulletView _bulletView;
    [SerializeField] private float _moveSpeed;

    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(_bulletView, _weaponPoint.position, _weaponPoint.rotation);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Die();
        }

        var moveDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += moveDirection * Time.deltaTime * _moveSpeed;
    }

    private void Die()
    {
        enabled = false;
        _animator.SetBool("IsDie", true);
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject, 1);
    }
}
