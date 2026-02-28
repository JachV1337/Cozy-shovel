using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakeSnow : MonoBehaviour
{
    [SerializeField] private float checkRadius = 1.5f; // maksymalny zasięg od gracza
    private Vector2? clickPos; // przechowuje pozycję kliknięcia
    private SnowManager snowManager;
    private float timeToDestroySnow = 3f;
    public Coroutine timeToDestroySnowCoroutine;
    public bool isTakingSnow;
    private void Start()
    {
        snowManager = GameObject.Find("SnowManager").GetComponent<SnowManager>();
    }
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
                        if (progres != null && !isTakingSnow && timeToDestroySnowCoroutine == null && snowManager.currentNumberOfSnow < snowManager.maxNumberOfSnow)
                        {
                            
                            StartToDestroySnow(snow, progres);
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
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Debug.Log("Mouse screen position: " + mousePos);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            worldPos.z = 0f;
            clickPos = worldPos;
            Debug.Log(clickPos.ToString());
        }
    }
    public void StartToDestroySnow(Snow snow, ProgresBar progres)
    {
        timeToDestroySnowCoroutine = StartCoroutine(TimeToDestroySnow(snow));
        progres.StartToTakeSnow(timeToDestroySnow);
        isTakingSnow = true;
    }
    IEnumerator TimeToDestroySnow(Snow snow)
    {
        yield return new WaitForSeconds(timeToDestroySnow);
        snow.DestroySnow();
        isTakingSnow = false;
        timeToDestroySnowCoroutine = null;
    }
    public void CancelTakingSnow()
    {
        StopCoroutine(timeToDestroySnowCoroutine);
        isTakingSnow = false;
        timeToDestroySnowCoroutine = null;
    }
}
