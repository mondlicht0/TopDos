using System;
using TopDos.Enemies;
using TopDos.Weapons.Data;
using UnityEngine;

namespace TopDos.Weapons
{
    [RequireComponent(typeof(Rigidbody))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _bulletSpeed;
        private int _damage = 5;
        private Rigidbody _rigidbody;

        [field: SerializeField] public float BulletLifeTime { get; private set; }
        public event Action OnCollisionHit;

        private void Awake()
        {
            _rigidbody ??= GetComponent<Rigidbody>();
        }

        public void Init(WeaponConfiguration config)
        {
            _damage = config.Damage;
        }

        private void Update()
        {
            _rigidbody.velocity = transform.forward * (_bulletSpeed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision other)
        {
            Debug.Log(other.collider.name);
            if (other.collider.TryGetComponent(out IDamagable health))
            {
                health.ModifyHealth(-_damage);
                
            }
            
            OnCollisionHit?.Invoke();
        }
    }
}
