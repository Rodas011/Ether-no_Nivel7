using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Función para cargar la escena número 1
    public void LoadScene1()
    {
        SceneManager.LoadScene(1);
    }

    // Función para cargar la escena número 2
    public void LoadScene2()
    {
        SceneManager.LoadScene(2);
    }

    // Función para cargar la escena número 0
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
    }

}
