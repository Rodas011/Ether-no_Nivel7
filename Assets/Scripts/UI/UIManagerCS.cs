using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerCS : MonoBehaviour
{
    // Referencia al Canvas que muestra la pantalla de Game Over
    public GameObject gameOverCanvas;

    private bool isGameOver = false;

    void Start()
    {
        // Asegúrate de que el Canvas de Game Over esté desactivado al iniciar el juego
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        // Aquí puedes definir la lógica para detectar cuándo pierdes
        // Por ejemplo, si tienes una variable de vida o condiciones específicas
        if (!isGameOver && CheckIfGameOver())
        {
            
            ShowGameOver();
        }
    }

    private bool CheckIfGameOver()
    {
        // Simulación de lógica de fin de juego (reemplázalo con tu lógica real)
        // Ejemplo: si la vida es menor o igual a 0
        return false; // Cambia esta condición según tu juego
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        // Pausar el juego si es necesario
        Time.timeScale = 0f; // Pausa el tiempo
    }

    // Método llamado al presionar el botón de Reintentar
    public void Retry()
    {
        Time.timeScale = 1f; // Restablece el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }

    // Método llamado al presionar el botón de Volver al Menú
    public void BackToMenu()
    {
        Time.timeScale = 1f; // Restablece el tiempo
        SceneManager.LoadScene("Menu"); // Carga la escena del menú (asegúrate de que la escena esté en la Build Settings)
    }
}
