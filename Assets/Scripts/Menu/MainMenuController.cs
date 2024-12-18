using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private Object nextScene;

    public void OnClickPlay() {
        SceneManager.LoadScene(nextScene.name);
        Debug.Log("Play");
    }

    public void OnClickQuit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
