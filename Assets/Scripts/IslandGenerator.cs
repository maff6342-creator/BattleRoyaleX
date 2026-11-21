
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class IslandGenerator : MonoBehaviour
{
    public int resolution = 129;
    public float islandSize = 1000f;
    public float maxHeight = 100f;
    public float noiseScale = 5f;

    void Start()
    {
        GenerateIsland();
    }

    void GenerateIsland()
    {
        Mesh mesh = new Mesh();

        int count = resolution;
        Vector3[] vertices = new Vector3[count * count];
        int[] triangles = new int[(count - 1) * (count - 1) * 6];

        for (int z = 0; z < count; z++)
        {
            for (int x = 0; x < count; x++)
            {
                float px = (float)x / (count - 1);
                float pz = (float)z / (count - 1);

                float nx = px * 2f - 1f;
                float nz = pz * 2f - 1f;

                float distance = Mathf.Sqrt(nx * nx + nz * nz);

                float falloff = Mathf.Clamp01(1f - distance);

                float noise = Mathf.PerlinNoise(
                    px * noiseScale,
                    pz * noiseScale
                );

                float height = noise * maxHeight * falloff;

                vertices[z * count + x] = new Vector3(
                    px * islandSize,
                    height,
                    pz * islandSize
                );
            }
        }

        int index = 0;

        for (int z = 0; z < count - 1; z++)
        {
            for (int x = 0; x < count - 1; x++)
            {
                int i = z * count + x;

                triangles[index++] = i;
                triangles[index++] = i + count;
                triangles[index++] = i + 1;

                triangles[index++] = i + 1;
                triangles[index++] = i + count;
                triangles[index++] = i + count + 1;
            }
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
