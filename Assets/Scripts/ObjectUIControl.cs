using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectUIControl : Interactable
{
    // Start is called before the first frame update

    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    public override void Interact()
    {
        uiObject.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
