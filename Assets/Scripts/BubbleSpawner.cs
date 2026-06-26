using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;
    public int minBubbles = 2;
    public int maxBubbles = 5;

    void Start()
    {
        SpawnBubbles();
    }

    void SpawnBubbles()
    {
        int count = Random.Range(minBubbles, maxBubbles + 1);

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(2f, 4f);
            Vector3 spawnPos = new Vector3(x, y, 0f);

            Instantiate(bubblePrefab, spawnPos, Quaternion.identity);
        }
    }
}