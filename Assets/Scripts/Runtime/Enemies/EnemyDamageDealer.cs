using UnityEngine;

namespace TopDos.Enemies
{
    public class EnemyDamageDealer : MonoBehaviour
    {
        [SerializeField] private Transform _damageDealerHolder;
        [SerializeField] private float _armLength;
        [SerializeField] private LayerMask _playerMask;

        private bool _canDealDamage = false;
        private bool _hasDealtDamage = false;

        private void Update()
        {
            if (_canDealDamage && !_hasDealtDamage)
            {
                RaycastHit hit;

                if (Physics.Raycast(_damageDealerHolder.position, -_damageDealerHolder.forward, out hit, _armLength, _playerMask))
                {
                    if (hit.transform.TryGetComponent(out IDamagable health))
                    {
                        health.TakeDamage(5);
                        _hasDealtDamage = true;
                    }
                }
            }
        }

        public void StartDealDamage()
        {
            _canDealDamage = true;
            _hasDealtDamage = false;
        }

        public void EndDealDamage()
        {
            _canDealDamage = false;
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(_damageDealerHolder.position, _damageDealerHolder.position - _damageDealerHolder.forward * _armLength);
        }
    }
}
