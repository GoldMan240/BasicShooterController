using System;
using System.Collections;
using UnityEngine;

namespace Gameplay.Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _speed = 10f;
        [SerializeField] private float _lifetime = 3f;
        [SerializeField] private LayerMask _targetLayerMask = 1 << 6; // 6 is the layer index of the Enemy layer
        
        private Action<Collider> _onHit;
        private Action<Bullet> _onLifetimeEnd;
        private Vector3 _previousPosition;

        private void OnEnable() => 
            StartCoroutine(ActionAfterLifetime());

        private void FixedUpdate()
        {
            float distance = Vector3.Distance(_previousPosition, transform.position);
            
            if (Physics.Raycast(transform.position, -transform.forward, out RaycastHit hit, distance, _targetLayerMask))
                OnTriggerEnter(hit.collider);
            
            _previousPosition = transform.position;
            
            _rigidbody.MovePosition(transform.position + transform.forward * (_speed * Time.fixedDeltaTime));
        }

        private void OnDisable() => 
            StopAllCoroutines();

        public void Setup(Action<Collider> onHit, Action<Bullet> onLifetimeEnd)
        {
            _onHit = onHit;
            _onLifetimeEnd = onLifetimeEnd;
        }

        private void OnTriggerEnter(Collider other)
        {
            _onHit?.Invoke(other);
            _onLifetimeEnd?.Invoke(this);
        }

        private IEnumerator ActionAfterLifetime()
        {
            yield return new WaitForSeconds(_lifetime);
            _onLifetimeEnd?.Invoke(this);
        }
    }
}