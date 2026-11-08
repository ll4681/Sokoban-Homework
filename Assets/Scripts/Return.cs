using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnToLevel1 : MonoBehaviour
{
    private bool isLoading = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isLoading)
        {
            StartCoroutine(ReturnToTest1());
        }
    }

    private IEnumerator ReturnToTest1()
    {
        isLoading = true;

        Scene endScene = gameObject.scene;

        Scene test1 = SceneManager.GetSceneByName("test1");

        if (!test1.isLoaded)
        {
            yield return SceneManager.LoadSceneAsync("test1",LoadSceneMode.Additive);

            test1 = SceneManager.GetSceneByName("test1");
        }

        SceneManager.SetActiveScene(test1);

        if (endScene.isLoaded && endScene != test1)
        {
            yield return SceneManager.UnloadSceneAsync(endScene);
        }

        isLoading = false;
    }
}

