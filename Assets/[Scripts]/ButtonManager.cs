using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    private int nextSceneIndex;
    private int previousSceneIndex;

    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        previousSceneIndex = SceneManager.GetActiveScene().buildIndex - 1;

        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log(activeScene.name);
    }

    public void OnStartButtonPressed()
    {
        SceneManager.LoadScene("Main");
    }

    public void OnBackButtonPressed()
    {
        SceneManager.LoadScene(previousSceneIndex);
    }

    public void OnNextButtonPressed()
    {
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void OnMenuButtonPressed()
    {
        SceneManager.LoadScene("Start");
    }
}
