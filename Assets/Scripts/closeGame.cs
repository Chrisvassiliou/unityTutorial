﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closeGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    //this function is needed to close the game and make the available on click events for the button
    
    public void quitGame()
    {
        Application.Quit();
    }
}