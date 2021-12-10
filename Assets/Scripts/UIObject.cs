using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIObject : MonoBehaviour
{

    // Start is called before the first frame update
    public GameObject UIImage;
    public InputField UIInputField;
    void Start()
    {
        UIImage.SetActive(false);
    }

    public void closeUIObject()
    {
        if (UIInputField != null)
        {
            UIInputField.text = "";
        }

        UIImage.SetActive(false);
    }
}
