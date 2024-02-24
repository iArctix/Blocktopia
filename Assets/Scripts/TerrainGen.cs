using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public int width = 10;
    public int depth = 10;
    public int height = 5;
    public float scale = 0.1f;
    public float heightScale = 2f;

    public GameObject voxelPrefab;

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < depth; z++)
            {
                float y = CalculateHeight(x, z);
                Vector3 position = new Vector3(x, y, z);
                InstantiateVoxel(position);
            }
        }
    }

    float CalculateHeight(int x, int z)
    {
        float xCoord = (float)x / width * scale;
        float zCoord = (float)z / depth * scale;

        float heightValue = Mathf.PerlinNoise(xCoord, zCoord) * heightScale;
        return heightValue;
    }

    void InstantiateVoxel(Vector3 position)
    {
        for (int y = 0; y < height; y++)
        {
            Vector3 spawnPosition = position + Vector3.up * y;
            GameObject voxel = Instantiate(voxelPrefab, spawnPosition, Quaternion.identity);
            voxel.transform.parent = transform;
        }
    }
}