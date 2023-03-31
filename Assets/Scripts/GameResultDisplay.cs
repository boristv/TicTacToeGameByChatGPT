using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class GameResultDisplay : MonoBehaviour
{
    [SerializeField] private GameController gameController;
    [SerializeField] private TextMeshProUGUI resultText;
    [SerializeField] private Image currentPlayerImage;
    [SerializeField] private Sprite crossSprite;
    [SerializeField] private Sprite circleSprite;

    private void Start()
    {
        // Подписываем методы на события победы, ничьи и смены игрока
        gameController.OnWin += DisplayWinMessage;
        gameController.OnDraw += DisplayDrawMessage;
        gameController.OnPlayerSwitch += DisplayPlayerSwitchMessage;

        // Отображаем чей ход и соответствующую картинку
        DisplayPlayerSwitchMessage(gameController.GetCurrentPlayer());
    }

    private void OnDestroy()
    {
        // Отписываем методы от событий при уничтожении объекта
        gameController.OnWin -= DisplayWinMessage;
        gameController.OnDraw -= DisplayDrawMessage;
        gameController.OnPlayerSwitch -= DisplayPlayerSwitchMessage;
    }

    private void DisplayWinMessage(int winner)
    {
        resultText.text = $"Player {winner} wins!";

        // Обновляем картинку для победителя
        if (winner == 1)
        {
            currentPlayerImage.sprite = crossSprite;
        }
        else if (winner == 2)
        {
            currentPlayerImage.sprite = circleSprite;
        }
    }

    private void DisplayDrawMessage()
    {
        resultText.text = "It's a draw!";
        currentPlayerImage.gameObject.SetActive(false); // отключаем картинку
    }

    private void DisplayPlayerSwitchMessage(int currentPlayer)
    {
        resultText.text = $"Player {currentPlayer}'s turn";

        // Изменяем картинку в зависимости от игрока, делающего ход
        if (currentPlayer == 1)
        {
            currentPlayerImage.sprite = crossSprite;
        }
        else if (currentPlayer == 2)
        {
            currentPlayerImage.sprite = circleSprite;
        }

        currentPlayerImage.gameObject.SetActive(true); // включаем картинку
    }
}
