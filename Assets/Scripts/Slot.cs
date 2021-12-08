using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public void UseItem()
    {
        foreach (Transform child in transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

    public bool MatchObject(GameObject item)
    {
        bool objectMatched = false;
        foreach (Transform child in transform)
        {
            if (child.gameObject == item)
            {
                objectMatched = true;
            }
        }
        return objectMatched;
    }
}
