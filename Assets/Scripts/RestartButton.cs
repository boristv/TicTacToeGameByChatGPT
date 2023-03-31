using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    private void Start()
    {
        // Подписываемся на событие нажатия на кнопку
        restartButton.onClick.AddListener(RestartGame);
    }

    private void OnDestroy()
    {
        // Отписываемся от события при уничтожении объекта
        restartButton.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        // Загружаем текущую сцену заново, чтобы перезапустить игру
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
