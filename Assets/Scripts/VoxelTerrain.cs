using UnityEngine;

public class VoxelTerrainGenerator : MonoBehaviour
{
    public int width = 50;                  // Number of cubes along the X-axis
    public int length = 50;                 // Number of cubes along the Z-axis
    public float scale = 10f;               // Scale of the Perlin noise
    public float heightMultiplier = 10f;    // Multiplier for the height of the terrain
    public float yOffset = 0f;              // Offset to adjust the terrain vertically

    public GameObject cubePrefab;           // Reference to the cube prefab (grass, sand, etc.)

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        // Loop through each coordinate in the grid
        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < length; z++)
            {
                // Calculate the height using Perlin noise
                float y = Mathf.PerlinNoise((float)x / scale, (float)z / scale) * heightMultiplier + yOffset;

                // Round y to the nearest integer
                int roundedY = Mathf.RoundToInt(y);

                // Instantiate a cube at the current position
                Vector3 spawnPosition = new Vector3(x, roundedY, z);
                GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                cube.transform.SetParent(transform); // Set the parent to this GameObject
            }
        }
    }
}
