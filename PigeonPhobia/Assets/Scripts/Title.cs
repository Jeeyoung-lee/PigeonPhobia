using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(LoadScene("GameScene"));
    }

    IEnumerator LoadScene(string sceneName)
    {
        var loadScene = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

        while (!loadScene.isDone)
            yield return null;
    }
}
