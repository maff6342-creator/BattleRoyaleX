
using UnityEngine;

public class EnvironmentGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public GameObject rockPrefab;
    public int treeCount = 300;
    public int rockCount = 60;
    public float islandSize = 1000f;

    void Start()
    {
        GenerateObjects(treePrefab, treeCount);
        GenerateObjects(rockPrefab, rockCount);
    }

    void GenerateObjects(GameObject prefab, int count)
    {
        if (prefab == null) return;

        for (int i = 0; i < count; i++)
        {
            float x = Random.Range(20f, islandSize - 20f);
            float z = Random.Range(20f, islandSize - 20f);

            Vector3 position = new Vector3(x, 0, z);

            Instantiate(
                prefab,
                position,
                Quaternion.Euler(0, Random.Range(0, 360), 0)
            );
        }
    }
}
