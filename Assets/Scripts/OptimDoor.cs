using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimDoor : MonoBehaviour {

    public bool isNear;
    Vector3 instance;
    Vector3 length;
    GameObject player;
    // Use this for initialization
    void Start()
    {
        instance = gameObject.transform.position;
        player = GameObject.Find("FPSController");



    }

    // Update is called once per frame
    void Update()
    {
        length = player.transform.position - instance + new Vector3(0, 0.8f, 0);
        if (length.magnitude < 70)
        {
            Enable();
        }
        else { Disable(); }
    }

    void Disable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

    void Enable()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

}
