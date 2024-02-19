using UnityEngine;

public class VoxelTerrain : MonoBehaviour
{
    public int width = 10;          // Number of cubes along the X-axis
    public int length = 10;         // Number of cubes along the Z-axis
    public int height = 5;          // Number of cubes along the Y-axis

    public GameObject cubePrefab;   // Reference to the cube prefab (grass, sand, etc.)

    void Start()
    {
        GenerateTerrain();
    }

    void GenerateTerrain()
    {
        // Loop through each coordinate in the grid
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    // Instantiate a cube at the current position
                    Vector3 spawnPosition = new Vector3(x, y, z);
                    GameObject cube = Instantiate(cubePrefab, spawnPosition, Quaternion.identity);
                    cube.transform.SetParent(transform); // Set the parent to this GameObject
                }
            }
        }
    }
}