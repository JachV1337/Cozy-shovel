using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeSnow : MonoBehaviour
{
    [SerializeField] private float checkRadius = 1.5f; // maksymalny zasięg od gracza
    private Vector2? clickPos; // przechowuje pozycję kliknięcia
    public Coroutine timeToDestroySnowCoroutine;
    public bool isTakingSnow;
    void OnDrawGizmosSelected()
    {
        // Zasięg gracza
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, checkRadius);

        // Punkt kliknięcia
        if (clickPos.HasValue)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(clickPos.Value, 0.2f);
        }
    }

    void Update()
    {
        if (clickPos.HasValue)
        {
            Vector2 worldPos2D = clickPos.Value;

            // Obliczamy odległość od gracza
            float distance = Vector2.Distance(transform.position, worldPos2D);
            if (distance <= checkRadius)
            {
                // Sprawdzenie czy kliknięto obiekt ze śniegiem
                Collider2D hitClick = Physics2D.OverlapPoint(worldPos2D);
                if (hitClick != null && hitClick.CompareTag("Snow"))
                {
                    Debug.Log("Śnieg w zasięgu kliknięcia: " + hitClick.name);
                    Snow snow = hitClick.GetComponent<Snow>();
                    if (snow != null)
                    {
                        ProgresBar progres = hitClick.GetComponent<ProgresBar>();
                        if (progres != null && !isTakingSnow)
                        {
                            progres.StartToTakeSnow();
                            StartToDestroySnow(snow);
                        }
                    }
                    else
                    {
                        clickPos = null;
                    }
                }
            }
            else
            {
                Debug.Log("Kliknięcie za daleko!");
            }

            clickPos = null; // resetujemy po obsłużeniu
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
    public void StartToDestroySnow(Snow snow)
    {
        timeToDestroySnowCoroutine = StartCoroutine(TimeToDestroySnow(snow));
        isTakingSnow = true;
    }
    IEnumerator TimeToDestroySnow(Snow snow)
    {
        yield return new WaitForSeconds(2.5f);
        snow.DestroySnow();
        isTakingSnow = false;
    }
    public void CancelTakingSnow()
    {
        StopCoroutine(timeToDestroySnowCoroutine);
        isTakingSnow = false;
    }
}
