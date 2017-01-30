using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimisationTest : MonoBehaviour {

    public bool isNear;
    Transform instance;
    Vector3 length;
    GameObject player;
    GameObject s173;
    Vector3 lengthToS173;


    // Use this for initialization
    void Start () {
        instance = gameObject.GetComponentInChildren<Transform>();
         player = GameObject.Find("FPSController");
        s173 = GameObject.Find("173");



    }

    // Update is called once per frame
    void Update () {
        lengthToS173 = s173.transform.position - instance.position + new Vector3(0, 0.8f, 0);

        length = player.transform.position - instance.position + new Vector3(0, 0.8f, 0);
        if (length.magnitude < 70 || lengthToS173.magnitude < 40) 
        {
            Enable();
        } else { Disable(); }
    }

    void Disable()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }

    void Enable()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }


}
