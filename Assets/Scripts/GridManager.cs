using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    public GameObject SquarePrefab; // Przypnij TilePrefab w Inspectorze
    public int gridWidth = 9;
    public int gridHeight = 9;
    public float cellSize = 1f; // Rozmiar pojedynczej komórki w jednostkach Unity

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        // Opcjonalnie: Przesuñ ca³y grid, aby jego œrodek by³ w (0,0) lub w lewym dolnym rogu
        //float startX = -(gridWidth * cellSize) / 2f + cellSize / 2f; // Dla œrodka
        //float startY = -(gridHeight * cellSize) / 2f + cellSize / 2f; // Dla œrodka

        float startX = 0f; // Dla lewego dolnego rogu jako (0,0)
        float startY = 0f; // Dla lewego dolnego rogu jako (0,0)

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                Vector2 spawnPos = new Vector2(startX + x * cellSize, startY + y * cellSize);
                GameObject tile = Instantiate(SquarePrefab, spawnPos, Quaternion.identity);
                tile.transform.parent = this.transform; // Uporz¹dkuj hierarchiê
                tile.name = $"Tile_{x}_{y}";
            }
        }
    }
}