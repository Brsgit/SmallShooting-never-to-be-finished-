using UnityEngine;

public interface IPoolable
{
    void Activate(Vector3 position);
    void Deactivate();
}
