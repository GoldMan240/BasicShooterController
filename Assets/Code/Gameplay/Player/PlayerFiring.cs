using Gameplay.Bullet;
using Infrastructure;
using Infrastructure.Services;
using Services;
using UnityEngine;

namespace Gameplay.Player
{
    public class PlayerFiring : MonoBehaviour
    {
        [SerializeField] private Transform _firePoint;
        
        private IInputService _inputService;
        private IBulletFactory _bulletFactory;

        private void Awake()
        {
            _inputService = ServiceLocator.Container.Get<IInputService>();
            _bulletFactory = ServiceLocator.Container.Get<IBulletFactory>();
        }

        private void Update()
        {
            if (_inputService.IsFirePressed) 
                Fire();
        }

        private void Fire()
        {
            Bullet.Bullet bullet = _bulletFactory.GetBullet();
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = _firePoint.rotation;
        }
    }
}