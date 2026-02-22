using UnityEngine;
using UnityEngine.Tilemaps;

public class SnowSpawner : MonoBehaviour
{
    [Header("Tilemap")]
    public Tilemap snowTilemap;

    [Header("Snow Prefaby")]
    public GameObject[] snowPrefabs;

    [Header("Ustawienia")]
    [Range(0f, 1f)]
    public float spawnChance = 1f; // 80% szansy

    public bool randomRotation = true;
    public bool randomFlipX = true;
    public bool randomFlipY = false;

    void Start()
    {
        SpawnSnow();
    }

    void SpawnSnow()
    {
        BoundsInt bounds = snowTilemap.cellBounds;

        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if (!snowTilemap.HasTile(pos))
                continue;

            // Szansa na spawn
            if (Random.value > spawnChance)
                continue;

            Vector3 worldPos = snowTilemap.GetCellCenterWorld(pos);

            // Losowy prefab
            GameObject prefab = snowPrefabs[Random.Range(0, snowPrefabs.Length)];

            GameObject snow = Instantiate(prefab, worldPos, Quaternion.identity);

            // Losowy obrót
            if (randomRotation)
            {
                float rot = Random.Range(0f, 360f);
                snow.transform.rotation = Quaternion.Euler(0f, 0f, rot);
            }

            // Losowy flip (działa jeśli prefab ma SpriteRenderer)
            Vector3 scale = snow.transform.localScale;

            if (randomFlipX && Random.value > 0.5f)
                scale.x *= -1;

            if (randomFlipY && Random.value > 0.5f)
                scale.y *= -1;

            snow.transform.localScale = scale;
        }
    }
}
