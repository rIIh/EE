using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScriptOnAnimator : MonoBehaviour {

    public GameObject character;
    public bool isOpened;
    public int animationSpeed;
    AudioClip doorClose;
    AudioClip doorOpen;
    Transform but2;
    Transform but1;
    public GameObject icon;
    GameObject icon1;
    GameObject icon2;
    Vector3 but1toPlayer;
    Vector3 but2toPlayer;
    Vector3 but1R;
    Vector3 but2R;
    public string CloseAnim;
    public string OpenAnim;
    public string But1;
    public string But2;
    public bool notToRand;
    public bool isMalf;
    public bool isLocked;

    private void Start()
    {
        if(isMalf)
        {
            gameObject.GetComponent<Animator>().SetBool("isMalf", true);

        }
        if (Random.value >= 0.7 && !notToRand)
        if (!isOpened)
        {
            gameObject.GetComponent<Animator>().SetTrigger("Opened");
            // gameObject.GetComponent<Animator>().SetBool("isOpened", true);
            isOpened = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {   if (other.tag == "Player")
        {
            Icons();
        }

    if (other.tag == "173" && !isOpened && !isLocked && Random.value < 0.005f && !other.gameObject.GetComponent<s173>().isVisible)
        {
            isOpened = true;
            gameObject.GetComponent<Animator>().SetTrigger("Opened");
            gameObject.GetComponent<AudioSource>().clip = doorOpen;
            gameObject.GetComponent<AudioSource>().Play();

        }




        if (Input.GetKeyDown(KeyCode.Mouse0) && !isLocked && other.tag == "Player")
        {
            if(!isOpened)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Opened");
                // gameObject.GetComponent<Animator>().SetBool("isOpened", true);
                gameObject.GetComponent<AudioSource>().clip = doorOpen;
                gameObject.GetComponent<AudioSource>().Play();

                isOpened = true;
            } else

            if (isOpened)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Closed");
                gameObject.GetComponent<AudioSource>().clip = doorClose;
                gameObject.GetComponent<AudioSource>().Play();

                // gameObject.GetComponent<Animator>().SetBool("isOpened", false);
                isOpened = false;
            }
        }

        }
    


    private void OnTriggerEnter(Collider other)
    { if (other.tag == "Player")
        {
            but1 = gameObject.GetComponentInChildren<Transform>().FindChild(But1);
            but2 = gameObject.GetComponentInChildren<Transform>().FindChild(But2);
            icon1 = Instantiate(icon, new Vector3(0, 0, 0), Quaternion.identity, transform);
            icon2 = Instantiate(icon, new Vector3(0, 0, 0), Quaternion.identity, transform);
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.Destroy(icon1);
            GameObject.Destroy(icon2);
        }
    }

    void Icons()
    { 
        var player = GameObject.Find("FPSController");
        var camera = GameObject.Find("FirstPersonCharacter");
        but1toPlayer = player.transform.position - but1.transform.position + new Vector3(0, 1, 0);
        but2toPlayer = player.transform.position - but2.transform.position + new Vector3(0, 1, 0);
        //var playerfv1 = (camera.transform.GetComponent<Camera>().transform.forward - new Vector3(0, 0, camera.transform.GetComponent<Camera>().transform.forward.z)) / 5;
        //var playerfv2 = (camera.transform.GetComponent<Camera>().transform.forward + new Vector3(0, 0, camera.transform.GetComponent<Camera>().transform.forward.z)) / 5;
        but1toPlayer = but1toPlayer / 4;
        but2toPlayer = but2toPlayer / 4;

        if (but1toPlayer.sqrMagnitude > but2toPlayer.sqrMagnitude)
        {
            icon2.GetComponent<MeshRenderer>().enabled = true;
            icon1.GetComponent<MeshRenderer>().enabled = false;

            icon2.transform.position = but2.transform.position + but2toPlayer;
            icon2.transform.LookAt(player.transform.position + new Vector3(0, 1, 0));
        }
        else
        {
            icon1.GetComponent<MeshRenderer>().enabled = true;
            icon2.GetComponent<MeshRenderer>().enabled = false;

            icon1.transform.position = but1.transform.position + but1toPlayer;
            icon1.transform.LookAt(player.transform.position + new Vector3(0, 1, 0));

        }
    }

    private void Awake()
    {
        doorOpen = Resources.Load<AudioClip>("Sounds/DoorOpen1");
        doorClose = Resources.Load<AudioClip>("Sounds/DoorClose1");

    }
}
