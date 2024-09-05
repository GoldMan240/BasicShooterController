using Infrastructure.Services;
using UnityEngine;

namespace Infrastructure.AssetProvision
{
    public interface IAssetProvider : IService
    {
        T Instantiate<T>(string path) where T : Object;
    }
}