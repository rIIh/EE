using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeCut : MonoBehaviour {

    IEnumerator IntroSequence()
    {
        gameObject.GetComponent<AudioSource>().PlayOneShot(door);

        yield return new WaitForSeconds(1.5f);
        gameObject.GetComponent<AudioSource>().PlayOneShot(click);
        yield return new WaitForSeconds(0.6f);

        gameObject.GetComponent<AudioSource>().PlayOneShot(lights);
        gameObject.GetComponent<Animator>().SetTrigger("CutStart");

    }



    AudioClip lights;
    AudioClip door;
    float time;
    AudioClip click;

    private void Awake()
    {
        lights = Resources.Load<AudioClip>("Sounds/Intro/flickering lamp");
        door = Resources.Load<AudioClip>("Sounds/DoorClose1");
        click = Resources.Load<AudioClip>("Sounds/Interact/Button");
    }


    // Use this for initialization
    void Start () {
        StartCoroutine("IntroSequence");
    }

    // Update is called once per frame
    void Update () {

    }
}
