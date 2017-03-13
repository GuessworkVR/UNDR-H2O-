using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmAnim : MonoBehaviour {
    Animator AlarmController;
    public bool IsActive;
    public float startTime = 10.0f;
    bool snooze = false;
    bool Alarming;
    bool Snoozing; 


	// Use this for initialization
	void Start () {
        AlarmController = GetComponent<Animator>();
        

	}
	
	// Update is called once per frame
	void Update () {
        //Collects information for parameters
        Alarming = AlarmController.GetBool("IsOn");
        Snoozing = AlarmController.GetBool("IsHit");
        //Countdown time until next ring
        float timer = Time.deltaTime;
        
        if (IsActive == true)
        {
            startTime -= timer;
        }
        
        //Activates ringing animation
        if (startTime <= 0)
        {
            AlarmController.SetBool("IsOn", true);
        }
        //Activates snooze
        if (snooze == true)
        {
            AlarmController.SetBool("IsHit", true);
            reset();
        }

    }

    private void reset()
    {
        //IsActive = false; (Optional)
        startTime = 120.0f; //May have to change this
        snooze = false;
        if (Alarming == true)
        {
            AlarmController.SetBool("IsOn", false);
        }

        if (Snoozing == true)
        {
            AlarmController.SetBool("IsHit", false);
        }



    }
    //Actuvates the snooze button
    private void OnTriggerEnter(Collider other)
    {
       
        
            snooze = true;
        
    }

}
