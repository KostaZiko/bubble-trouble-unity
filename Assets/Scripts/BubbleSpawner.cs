using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public GameObject bubblePrefab;

   public void SpawnBubbles(int count)
    {

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(-8f, 8f);
            float y = Random.Range(2f, 4f);

            Instantiate(bubblePrefab, new Vector3(x, y, 0f), Quaternion.identity);
        }
    }
}