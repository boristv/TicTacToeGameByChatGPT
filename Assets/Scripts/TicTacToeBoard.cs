using UnityEngine;

public class TicTacToeBoard : MonoBehaviour
{
    [SerializeField] private GameObject gridCellPrefab;
    [SerializeField] private int gridSize = 3;
    [SerializeField] private GameObject parentObject;

    private GridCell[,] gridCells;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        gridCells = new GridCell[gridSize, gridSize];

        for (int x = 0; x < gridSize; x++)
        {
            for (int y = 0; y < gridSize; y++)
            {
                GameObject gridCellObject = Instantiate(gridCellPrefab, parentObject.transform);
                RectTransform rectTransform = gridCellObject.GetComponent<RectTransform>();
                rectTransform.anchoredPosition = new Vector2((x - gridSize / 2) * rectTransform.rect.width, (y - gridSize / 2) * rectTransform.rect.height);
                GridCell gridCell = gridCellObject.GetComponent<GridCell>();
                gridCell.SetPosition(x, y);

                gridCells[x, y] = gridCell;
            }
        }
    }

    public GridCell GetGridCell(int x, int y)
    {
        return gridCells[x, y];
    }
}