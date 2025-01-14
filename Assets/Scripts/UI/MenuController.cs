using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Debug.Log("Scene changed to: " + sceneName);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
