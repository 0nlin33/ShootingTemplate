using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    /*public GameObject[] gridCellPrefab; // Prefab for the grid cell*/

    public GameObject[] crystalPrefab;  // Reference to the crystal prefab

    public Vector2 cellSize = new Vector2(1f, 1f); // Size of each grid cell
    public int gridWidth = 10; // Number of grid cells in the X-axis
    public int gridHeight = 5; // Number of grid cells in the Y-axis


    private GameObject[,] gridObjects; // 2D array to store the instantiated objects

    [SerializeField]private ScoreKeeper scoreKeeper;



    private void Start()
    {
        GenerateGrid();

    }

    public void GenerateGrid()
    {
        gridObjects = new GameObject[gridWidth, gridHeight];

        Vector2 startPosition = transform.position - new Vector3((gridWidth - 1) * cellSize.x / 2f, (gridHeight - 1) * cellSize.y / 2f, 0f);


        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 spawnPosition = startPosition + new Vector2(x * cellSize.x, y * cellSize.y);

                GameObject randomPrefab = crystalPrefab[Random.Range(0, crystalPrefab.Length)];

                GameObject instantiatedObject=Instantiate(randomPrefab, spawnPosition, Quaternion.identity, transform);

                gridObjects[x, y] = instantiatedObject;
            }
        }
    }

    public void CheckNeighbors()
    {
        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                GameObject currentObject = gridObjects[x, y];
                if (currentObject != null)
                {
                    // Check if the current object has any neighboring objects
                    bool hasNeighbors = false;

                    // Check top neighbor
                    if (y > 0 && gridObjects[x, y - 1] != null)
                        hasNeighbors = true;

                    // Check bottom neighbor
                    if (y < gridHeight - 1 && gridObjects[x, y + 1] != null)
                        hasNeighbors = true;

                    // Check left neighbor
                    if (x > 0 && gridObjects[x - 1, y] != null)
                        hasNeighbors = true;

                    // Check right neighbor
                    if (x < gridWidth - 1 && gridObjects[x + 1, y] != null)
                        hasNeighbors = true;

                    if (!hasNeighbors)
                    {
                        // Add the desired component to the current object
                        currentObject.AddComponent<Rigidbody2D>();
                    }
                }
            }
        }
    }

    private void WinCheck()
    {
        foreach (GameObject obj in gridObjects)
        {
            if (obj != null)
            {
                Debug.Log("Not null yet.");
            }
            else
            {
                scoreKeeper.Win();
            }
        }
    }

    private void Update()
    {
        CheckNeighbors();
        WinCheck();
    }
}