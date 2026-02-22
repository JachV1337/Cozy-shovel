using UnityEngine;

public class NoRotation : MonoBehaviour
{
    private Quaternion initialLocalRotation;
    private Vector3 initialLocalPosition;

    void Start()
    {
        // zapamiętaj pierwotną lokalną rotację i pozycję
        initialLocalRotation = transform.localRotation;
        initialLocalPosition = transform.localPosition;
    }

    void LateUpdate()
    {
        // przywróć lokalną rotację i pozycję
        transform.localRotation = initialLocalRotation;
        transform.localPosition = initialLocalPosition;
    }
}
