using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

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
    public bool isLocked;



    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "173" && !isOpened && !isLocked && Random.value<0.005f && !other.gameObject.GetComponent<s173>().isVisible)
        {
            GetComponent<Animation>().CrossFade(OpenAnim);
            isOpened = true;
            gameObject.GetComponent<AudioSource>().clip = doorOpen;
            gameObject.GetComponent<AudioSource>().Play();
        }
        
             if (other.tag == "Player")
        {
            var player = GameObject.Find("FPSController");
            var camera = GameObject.Find("FirstPersonCharacter");
            but1toPlayer = player.transform.position - but1.position + new Vector3(0, 1, 0);
            but2toPlayer = player.transform.position - but2.position + new Vector3(0, 1, 0);
            but1toPlayer = but1toPlayer / 4;
            but2toPlayer = but2toPlayer / 4;

            if (but1toPlayer.sqrMagnitude > but2toPlayer.sqrMagnitude)
            {
                icon2.GetComponent<MeshRenderer>().enabled = true;
                icon1.GetComponent<MeshRenderer>().enabled = false;

                icon2.transform.position = but2.position + but2toPlayer;
                icon2.transform.LookAt(player.transform.position + new Vector3(0, 1, 0));
            }
            else
            {
                icon1.GetComponent<MeshRenderer>().enabled = true;
                icon2.GetComponent<MeshRenderer>().enabled = false;

                icon1.transform.position = but1.position + but1toPlayer;
                icon1.transform.LookAt(player.transform.position + new Vector3(0, 1, 0));

            }
            if (Input.GetKeyDown(KeyCode.Mouse0) && !isLocked)
            {
                if (!isOpened && !gameObject.GetComponent<Animation>().isPlaying && !isLocked)
                {
                    GetComponent<Animation>().CrossFade(OpenAnim);
                    isOpened = true;
                    gameObject.GetComponent<AudioSource>().clip = doorOpen;
                    gameObject.GetComponent<AudioSource>().Play();

                }
                else if (!gameObject.GetComponent<Animation>().isPlaying && !isLocked)

                {
                    GetComponent<Animation>().CrossFade(CloseAnim);
                    gameObject.GetComponent<AudioSource>().clip = doorClose;
                    gameObject.GetComponent<AudioSource>().Play();
                    isOpened = false;
                }
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            but1 = gameObject.GetComponentInChildren<Transform>().FindChild("Door").GetComponentInChildren<Transform>().FindChild(But1);
            but2 = gameObject.GetComponentInChildren<Transform>().FindChild("Door").GetComponentInChildren<Transform>().FindChild(But2);
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

    void Awake()
    {
        doorOpen = Resources.Load<AudioClip>("Sounds/DoorOpen1");
        doorClose = Resources.Load<AudioClip>("Sounds/DoorClose1");
        gameObject.GetComponent<Animation>()[OpenAnim].speed = 0.5f;
        gameObject.GetComponent<Animation>()[CloseAnim].speed = 0.5f;


    }

}
