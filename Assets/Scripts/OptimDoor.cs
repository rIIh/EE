using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptimDoor : MonoBehaviour {

    public bool isNear;
    Vector3 instance;
    Vector3 lengthToPlayer;
    Vector3 lengthToS173;
    GameObject player;
    GameObject s173;
    // Use this for initialization
    void Start()
    {
        instance = gameObject.transform.position;
        player = GameObject.Find("FPSController");
        s173 = GameObject.Find("173");


    }

    // Update is called once per frame
    void Update()
    {
        lengthToPlayer = player.transform.position - instance + new Vector3(0, 0.8f, 0);
        lengthToS173 = s173.transform.position - instance + new Vector3(0, 0.8f, 0);

        if (lengthToPlayer.magnitude < 70 || lengthToS173.magnitude < 70)
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
