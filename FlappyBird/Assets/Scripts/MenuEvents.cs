using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetGUIVisibile(GameObject go)
    {
        go.SetActive(true);
    }

    public void SetGUIInvisibile(GameObject go)
    {
        go.SetActive(false);
    }

    public void OpenMenu(GameObject panel)
    {
        panel.SetActive(true);
    }

    public void CloseMenu(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void togglePause(bool pause)
    {
        if (pause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
