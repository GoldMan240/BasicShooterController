using Infrastructure;
using Infrastructure.Services;

namespace Gameplay.Bullet
{
    public interface IBulletFactory : IService
    {
        Bullet GetBullet();
    }
}