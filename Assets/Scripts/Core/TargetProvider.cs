using UnityEngine;

public class TargetProvider : MonoBehaviour, ITargetProvider
{
    public Vector3 HitCheck(Ray ray)
    {
        Vector3 _destination;
        if (Physics.Raycast(ray, out var hit))
        {
            _destination = hit.point;
        }
        else
        {
            _destination = ray.GetPoint(1000);
        }

        return _destination;
    }
}
