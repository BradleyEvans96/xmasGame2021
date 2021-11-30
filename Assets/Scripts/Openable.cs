using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class Openable : Interactable
{
    public Sprite open;
    public Sprite closed;

    private SpriteRenderer sr;
    private bool isOpen;
    public GameObject inventoryItem;

    public override void Interact()
    {
        if (isOpen)
        {
            sr.sprite = closed;
            if (inventoryItem != null)
            {
                inventoryItem.SetActive(false);
            }
        }
        else
        {
            sr.sprite = open;
            if (inventoryItem != null)
            {
                inventoryItem.SetActive(true);
            }
        }
        isOpen = !isOpen;
    }

    private void Start()
    {
        if (inventoryItem != null)
        {
            inventoryItem.SetActive(false);
        }
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = closed;
    }

}
