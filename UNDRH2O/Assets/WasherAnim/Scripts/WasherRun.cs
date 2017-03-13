﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasherRun : MonoBehaviour {

    Animator WasherController;
    bool buttonPressed = false;
    float timer=0;
    public GameObject hazard;
    float waterHeight;
    public float maxWaterHeight = 0.21f;
    public bool animationTimeLimit;
    //Don't worry about unless animationTimeLimit is true
    public float timeLimit = 7;

	// Use this for initialization
	void Start () {

        WasherController = GetComponent<Animator>();
        
		
	}
	
	// Update is called once per frame
	void Update () {

        waterHeight = hazard.transform.position.y;
        //Activates Animation
        if (buttonPressed == true)
        {
            WasherController.SetBool("IsOn", true);
            timer += Time.deltaTime;
            WasherController.SetFloat("RunTime", 0);
        }

        //Puts animation on a timer, then turns it back off.
        if (animationTimeLimit == true)
        {
             if (timer >= timeLimit)
            {

                WasherController.SetFloat("RunTime", 5);
                WasherController.SetBool("IsOn", false);
                Reset();
            }
        }

        //Activates dying animation.
        if (waterHeight >= maxWaterHeight)
        {
            WasherController.SetBool("IsWet", true);
        }

    }
    //resets animation to 0
    private void Reset()
    {
        timer = 0;
        buttonPressed = false;
        
    }
    //Activates animation
    private void OnTriggerEnter(Collider other)
    {

        

            buttonPressed = true;

       

    }

}
