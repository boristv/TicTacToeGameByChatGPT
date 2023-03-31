using System;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private LineDrawer lineDrawer;
    [SerializeField] private int size = 3;
    
    private int[,] gameBoard;
    private int currentPlayer = 1;
    private bool gameActive = true;

    public event Action<int> OnWin;
    public event Action OnDraw;
    public event Action<int> OnPlayerSwitch;

    private void Start()
    {
        gameBoard = new int[size, size];
    }
    
    public int GetCurrentPlayer()
    {
        return currentPlayer;
    }

    public bool SetCell(int x, int y)
    {
        if (gameBoard[x, y] == 0)
        {
            gameBoard[x, y] = currentPlayer;
            return true;
        }
        return false;
    }

    public int GetCellValue(int x, int y)
    {
        return gameBoard[x, y];
    }

    public void SwitchPlayer()
    {
        if (CheckWin())
        {
            Debug.Log($"Win {currentPlayer}");
            gameActive = false;
            OnWin?.Invoke(currentPlayer);
        }
        else if (CheckDraw())
        {
            Debug.Log($"Draw");
            gameActive = false;
            OnDraw?.Invoke();
        }
        else
        {
            currentPlayer = currentPlayer == 1 ? 2 : 1;
            OnPlayerSwitch?.Invoke(currentPlayer);
        }
    }

    private bool CheckWin()
    {
        for (int i = 0; i < size; i++)
        {
            if (gameBoard[i, 0] != 0 && gameBoard[i, 0] == gameBoard[i, 1] && gameBoard[i, 1] == gameBoard[i, 2])
            {
                lineDrawer.cells = new List<Vector2Int>() { new Vector2Int(i, 0), new Vector2Int(i, 1), new Vector2Int(i, 2) };
                lineDrawer.DrawLine();
                return true;
            }
            if (gameBoard[0, i] != 0 && gameBoard[0, i] == gameBoard[1, i] && gameBoard[1, i] == gameBoard[2, i])
            {
                lineDrawer.cells = new List<Vector2Int>() { new Vector2Int(0, i), new Vector2Int(1, i), new Vector2Int(2, i) };
                lineDrawer.DrawLine();
                return true;
            }
        }
        if (gameBoard[1, 1] != 0 && ((gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2]) || (gameBoard[0, 2] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 0])))
        {
            if (gameBoard[0, 0] == gameBoard[1, 1] && gameBoard[1, 1] == gameBoard[2, 2])
            {
                lineDrawer.cells = new List<Vector2Int>() { new Vector2Int(0, 0), new Vector2Int(1, 1), new Vector2Int(2, 2) };
                lineDrawer.DrawLine();
            }
            else
            {
                lineDrawer.cells = new List<Vector2Int>() { new Vector2Int(0, 2), new Vector2Int(1, 1), new Vector2Int(2, 0) };
                lineDrawer.DrawLine();
            }
            return true;
        }
        return false;
    }

    private bool CheckDraw()
    {
        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                if (gameBoard[x, y] == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public bool IsGameActive()
    {
        return gameActive;
    }
}
