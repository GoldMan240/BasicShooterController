using Infrastructure.AssetProvision;
using UnityEngine;
using UnityEngine.Pool;

namespace Gameplay.Bullet
{
    public class BulletFactory : IBulletFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ObjectPool<Bullet> _bulletPool;

        public BulletFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _bulletPool = new ObjectPool<Bullet>(CreateBullet, OnGetBullet, OnReleaseBullet, DestroyBullet);
        }

        public Bullet GetBullet() => 
            _bulletPool.Get();

        private Bullet CreateBullet()
        {
            Bullet bullet = _assetProvider.Instantiate<Bullet>(AssetPath.BulletPath);
            bullet.Setup(OnHit, OnLifetimeEnd);
            return bullet;
        }

        private void OnHit(Collider collider) => 
            Debug.Log($"Bullet hit {collider.gameObject}");

        private void OnLifetimeEnd(Bullet bullet) => 
            _bulletPool.Release(bullet);

        private void OnGetBullet(Bullet bullet) => 
            bullet.gameObject.SetActive(true);

        private void OnReleaseBullet(Bullet bullet) => 
            bullet.gameObject.SetActive(false);

        private void DestroyBullet(Bullet bullet) => 
            Object.Destroy(bullet.gameObject);
    }
}