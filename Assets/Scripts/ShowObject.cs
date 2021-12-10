using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : Interactable
{
    // Start is called before the first frame update
    public GameObject objectToShow;
    void Start()
    {
        objectToShow.SetActive(false);
    }

    public override void Interact()
    {
        objectToShow.SetActive(true);
    }
    // Update is called once per frame
}
