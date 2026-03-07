using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    [SerializeField] float timeToDestroy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DestroyGameObj();
    }

    void DestroyGameObj()
    {
        Destroy(gameObject,timeToDestroy);
    }
}
