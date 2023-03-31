using UnityEngine;
using UnityEngine.UI;

public class GridCell : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private Image image;
    [SerializeField] private Sprite crossSprite;
    [SerializeField] private Sprite zeroSprite;

    private GameController gameController;
    private int x;
    private int y;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        button.onClick.AddListener(OnClick);

        // Выключаем изображение на старте
        image.gameObject.SetActive(false);
    }

    private void OnClick()
    {
        if (gameController.IsGameActive())
        {
            if (gameController.SetCell(x, y))
            {
                UpdateLabel();
                gameController.SwitchPlayer();
            }
        }
    }

    public void UpdateLabel()
    {
        int cellValue = gameController.GetCellValue(x, y);
        if (cellValue == 0)
        {
            // Если значение ячейки равно 0, то выключаем изображение
            image.gameObject.SetActive(false);
        }
        else if (cellValue == 1)
        {
            image.sprite = crossSprite;
            // Включаем изображение после назначения спрайта
            image.gameObject.SetActive(true);
        }
        else if (cellValue == 2)
        {
            image.sprite = zeroSprite;
            // Включаем изображение после назначения спрайта
            image.gameObject.SetActive(true);
        }
    }

    public void SetPosition(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}