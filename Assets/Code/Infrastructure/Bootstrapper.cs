using Gameplay.Bullet;
using Infrastructure.AssetProvision;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private void Awake()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            ServiceLocator.Register<IInputService>(new StandaloneInputService());
            ServiceLocator.Register<IAssetProvider>(new AssetProvider());
            ServiceLocator.Register<IBulletFactory>(new BulletFactory(ServiceLocator.Get<IAssetProvider>()));
        }
    }
}