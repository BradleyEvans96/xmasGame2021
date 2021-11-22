using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadLevel("SnowScene");
        }
    }

    public void loadSpecificLevel(string sceneName)
    {
        StartCoroutine(LoadLevel(sceneName));
    }
    IEnumerator LoadLevel(string sceneName)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(sceneName);
    }


}

