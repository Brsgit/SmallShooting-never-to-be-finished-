using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerView : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetRunAnimation()
    {
        Debug.Log("Run");
    }

    public void SetIdleAnimation()
    {
        Debug.Log("Idle");
    }
}
