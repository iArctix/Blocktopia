using UnityEngine;

public class PlaceCubesOnPlane : MonoBehaviour
{
    public GameObject cubePrefab;
    public int gridSizeX = 10;
    public int gridSizeZ = 10;
    public float spacing = 1f;

    void Start()
    {
        PlaceCubes();
    }

    void PlaceCubes()
    {
        Vector3 planeSize = GetComponent<Renderer>().bounds.size;

        for (int x = 0; x < gridSizeX; x++)
        {
            for (int z = 0; z < gridSizeZ; z++)
            {
                Vector3 position = new Vector3(
                    x * spacing - (gridSizeX - 1) * spacing * 0.5f,
                    planeSize.y * 0.5f, // Adjust the height of the cubes as needed
                    z * spacing - (gridSizeZ - 1) * spacing * 0.5f
                );

                GameObject cube = Instantiate(cubePrefab, transform.position + position, Quaternion.identity);
                cube.transform.parent = transform;
            }
        }
    }
}