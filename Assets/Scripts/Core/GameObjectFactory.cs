using UnityEngine;

public class GameObjectFactory : ScriptableObject
{
    protected T CreateGameObjectInstance<T>(T prefab, Transform transform) where T : MonoBehaviour
    {
        T instance = Instantiate(prefab, transform);
        return instance;
    }
}
