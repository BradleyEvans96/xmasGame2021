using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class handleAnswer : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject errorText;
    public InputField answerField;

    string answer;
    void Start()
    {
        errorText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void handleAnswerClick()
    {
        answer = answerField.text.ToLower();
        Debug.Log(answer);
        if (answer != "big shiny blue baubles")
        {
            StartCoroutine(pulseShow());
        }
        else
        {
            SceneManager.LoadScene("FinalScene");
        }
    }

    IEnumerator pulseShow()
    {
        errorText.SetActive(true);
        yield return new WaitForSeconds(5);
        errorText.SetActive(false);
    }
}
