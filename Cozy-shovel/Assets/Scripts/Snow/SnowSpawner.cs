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
    public float spawnChance = 1f; // 100% szansy


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
        }
    }
}
