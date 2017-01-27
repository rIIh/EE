using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimisationTest : MonoBehaviour {

    public bool isNear;
    Transform instance;
    Vector3 length;
    GameObject player;
    // Use this for initialization
    void Start () {
        instance = gameObject.GetComponentInChildren<Transform>();
         player = GameObject.Find("FPSController");



    }

    // Update is called once per frame
    void Update () {
        length = player.transform.position - instance.position + new Vector3(0, 0.8f, 0);
        if (length.magnitude < 70)
        {
            Enable();
        } else { Disable(); }
    }

    void Disable()
    {
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = false;
    }

    void Enable()
    {
        transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().enabled = true;
    }


}
