using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour {
    Vector3 lp;
    public bool state1;
    public bool state2;
    public bool state3;


    // Use this for initialization
    void Start () {
        var RB = GetComponent<Rigidbody>();
        RB.centerOfMass = gameObject.transform.localPosition;
        lp = gameObject.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        CheckState();
        gameObject.transform.localPosition = lp;
        transform.localRotation = Quaternion.Euler(transform.localRotation.eulerAngles.x, 0, 0);
    }

    void CheckState()
    {
        if (gameObject.transform.localEulerAngles.x < 280 && gameObject.transform.localEulerAngles.x > 265)
        {
            state1 = true;
            state2 = false;
            state3 = false;
        } else if ( gameObject.transform.localEulerAngles.x > 350 || gameObject.transform.localEulerAngles.x < 5)
        {
            state1 = false;
            state2 = true;
            state3 = false;
        } else
        {
            state1 = false;
            state2 = false;
            state3 = true;

        }
    }


    private void FixedUpdate()
    {
        //if(transform.rotation.eulerAngles.x < 280 || transform.rotation.eulerAngles.x > 260)
        //{
        //    transform.rotation = Quaternion.Euler(270, 0, 0);
        //}
        //if (transform.rotation.eulerAngles.x > 350 || transform.rotation.eulerAngles.x < 260)
        //{
        //    transform.rotation = Quaternion.Euler(360, 0, 0);
        //}
    }
}
