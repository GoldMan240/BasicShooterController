using UnityEngine;

namespace Infrastructure.AssetProvision
{
    public interface IAssetProvider
    {
        T Instantiate<T>(string path) where T : Object;
    }
}