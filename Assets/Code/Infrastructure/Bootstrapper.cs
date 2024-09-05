using Gameplay.Bullet;
using Infrastructure.AssetProvision;
using Infrastructure.Services;
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
            ServiceLocator.Container.Register<IInputService>(new StandaloneInputService());
            ServiceLocator.Container.Register<IAssetProvider>(new AssetProvider());
            ServiceLocator.Container.Register<IBulletFactory>(new BulletFactory(ServiceLocator.Container.Get<IAssetProvider>()));
        }
    }
}