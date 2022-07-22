using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;
    public int loadSceneIndex;

    void Start()
    {
        StartCoroutine(LoadAsynchronously(loadSceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        //loadSceneIndex = SelectLevelsMenu.getIndexScene();

        if (loadSceneIndex == 2)
        {
            operation = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex + 1));
        }
        else if (loadSceneIndex == 3)
        {
            operation = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex + 2));
        }

        else if (loadSceneIndex == 4)
        {
            operation = SceneManager.LoadSceneAsync((SceneManager.GetActiveScene().buildIndex + 3));
        }

        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            progressText.text = progress * 100f + "%";

            yield return null;
        }
    }
}