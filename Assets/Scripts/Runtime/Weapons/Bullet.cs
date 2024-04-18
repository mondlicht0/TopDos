using System;
using UnityEngine;

namespace TopDos.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        private void Update()
        {
            _rigidbody.velocity = Vector3.forward * (_bulletSpeed * Time.deltaTime);
        }
    }
}
