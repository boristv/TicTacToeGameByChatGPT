using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private TicTacToeBoard ticTacToeBoard;

    public Color lineColor;
    public List<Vector2Int> cells;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.startColor = lineColor;
        lineRenderer.endColor = lineColor;
        DrawLine();
    }

    public void DrawLine()
    {
        lineRenderer.positionCount = cells.Count;
        for (int i = 0; i < cells.Count; i++)
        {
            GridCell gridCell = ticTacToeBoard.GetGridCell(cells[i].x, cells[i].y);
            Vector3 cellPos = gridCell.transform.position;
            lineRenderer.SetPosition(i, cellPos);
        }
    }
}