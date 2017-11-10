﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVisualController : MonoBehaviour
{
    private bool pressed = false;
    
    /// <summary>
    /// Makes all the grid turn of its image
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    /// <summary>
    /// Makes the grid show or hide.
    /// </summary>
    public void Update()
    {
        if (Input.GetAxisRaw("Inventory") == 1 && pressed == false)
        {
            for (int i = 0; i < 40; i++)
            {
                if (this.transform.GetChild(i).GetComponent<Image>().enabled == false) this.transform.GetChild(i).GetComponent<Image>().enabled = true; else this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            }
            pressed = true;
        }
            else if (Input.GetAxisRaw("Inventory") == 0) pressed = false;
    }
}