using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeSnow : MonoBehaviour
{
    [SerializeField] private float checkRadius = 1f;
    private Vector2? clickPos; // przechowuje pozycję kliknięcia

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);

        // jeśli kliknięto, pokaż miejsce kliknięcia
        if (clickPos.HasValue)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(clickPos.Value, 0.2f);
        }
    }

    // Update jest idealnym miejscem do wykonania akcji
    void Update()
    {
        if (clickPos.HasValue)
        {
            Vector2 worldPos2D = clickPos.Value;

            // Sprawdzenie śniegu wokół obiektu
            Collider2D hit = Physics2D.OverlapCircle(transform.position, checkRadius);
            if (hit != null && hit.CompareTag("Snow"))
            {
                Debug.Log("Śnieg w zasięgu!");
                Collider2D hitClick = Physics2D.OverlapPoint(worldPos2D);
                if (hitClick != null)
                {
                    Debug.Log("Kliknięto: " + hitClick.name);
                    Snow snow = hitClick.GetComponent<Snow>();
                    if (snow != null)
                    {
                        snow.DestroySnow();
                    }
                }

                clickPos = null; // resetujemy po obsłużeniu
            }
            else
            {
                //Debug.Log("Nie ma śniegu w zasięgu.");
            }

        }
    }

    // Input System callback — tylko zapisuje pozycję kliknięcia
    public void TakeSnowMethod(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            worldPos.z = 0f;
            clickPos = worldPos;
        }
    }
}
