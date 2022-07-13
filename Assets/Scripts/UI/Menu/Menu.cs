using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject _menuWindow;
    [SerializeField] private MonoBehaviour[] _componentsToDisable;

    public void OpenMenuWindow()
    {
        _menuWindow.SetActive(true);

        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = false;
        }

        Time.timeScale = 0.001f;
    }

    public void CloseMenuWindow()
    {
        _menuWindow.SetActive(false);

        for (int i = 0; i < _componentsToDisable.Length; i++)
        {
            _componentsToDisable[i].enabled = true;
        }

        Time.timeScale = 1f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeControl()
    {
        EventSystem.OnControlChanged();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
