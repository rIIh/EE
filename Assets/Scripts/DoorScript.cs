using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    public GameObject character;
    public bool isOpened;
    public int animationSpeed;
    AudioClip doorClose;
    AudioClip doorOpen;

    //void OnTriggerEnter(Collider collision)
    //{
    //    if (!isOpened)
    //    {
    //        var anim = GetComponent<Animation>();
    //        foreach (AnimationState state in anim)
    //        {
    //            state.speed = 6F;
    //        }
    //        GetComponent<Animation>().Play();
    //        print("Opened");
    //        isOpened = true;

    //    }


    //}

    private void OnTriggerStay(Collider other)
    {






        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isOpened && !gameObject.GetComponent<Animation>().isPlaying)
            {
                GetComponent<Animation>().CrossFade("Open");
                print("Opened");
                isOpened = true;
                gameObject.GetComponent<AudioSource>().clip = doorOpen;
                gameObject.GetComponent<AudioSource>().Play();

            }
            else if(!gameObject.GetComponent<Animation>().isPlaying)

             {
                GetComponent<Animation>().CrossFade("Close");
                gameObject.GetComponent<AudioSource>().clip = doorClose;
                gameObject.GetComponent<AudioSource>().Play();
                print("Closed");
                isOpened = false;
            }
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (isOpened)
    //    {
    //        var anim = GetComponent<Animation>();
    //        foreach (AnimationState state in anim)
    //        {
    //            state.speed = -6F;
    //        }
    //        GetComponent<Animation>().Play();
    //        isOpened = false;
    //        print("Closed");

    //    }
    //}

    void Awake()
    {
        doorOpen = Resources.Load<AudioClip>("Sounds/DoorOpen1");
        doorClose = Resources.Load<AudioClip>("Sounds/DoorClose1");
        gameObject.GetComponent<Animation>()["Open"].speed = 0.5f;
        gameObject.GetComponent<Animation>()["Close"].speed = 0.5f;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
