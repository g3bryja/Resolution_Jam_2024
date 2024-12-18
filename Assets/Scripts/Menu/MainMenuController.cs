using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField]
    private string nextScene;

    public void OnClickPlay() {
        SceneManager.LoadScene(nextScene);
        Debug.Log("Play");
    }

    public void OnClickQuit() {
        Application.Quit();
        Debug.Log("Quit");
    }
}
