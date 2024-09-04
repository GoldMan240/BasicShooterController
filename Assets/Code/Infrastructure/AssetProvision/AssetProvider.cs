using UnityEngine;

namespace Infrastructure.AssetProvision
{
    public class AssetProvider : IAssetProvider
    {
        public T Instantiate<T>(string path) where T : Object
        {
            T asset = Resources.Load<T>(path);
            
            if (asset != null)
                return Object.Instantiate(asset);
            
            Debug.LogError($"Asset at path {path} not found.");
            return null;
        }
    }
}