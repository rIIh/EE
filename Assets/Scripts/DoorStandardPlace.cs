using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStandardPlace : MonoBehaviour {

    public bool iscorner;
    public bool iscorrd;
    public bool isthree;
    public bool isfour;
    public bool isdead;
    public Object door;
    public Quaternion rotator;
    public Vector3 d1loc;
    public Vector3 d2loc;
    public Vector3 d3loc;
    public Vector3 d4loc;
    // Use this for initialization
    void Start() {


        door = Resources.Load<GameObject>("Door");
       // gameObject.transform.rotation = rotator;

        if (iscorner)
        {
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d1loc))
            {
                var door1 = (GameObject)Instantiate(door, d1loc, Quaternion.Euler(0, 0, 0), gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d1loc);
                RotateDoor(d1loc, door1);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d2loc))
            {
                var door2 = (GameObject)Instantiate(door, d2loc, Quaternion.Euler(0, 0, 0), gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d2loc);
                RotateDoor(d2loc, door2);
            }
        }

        if (iscorrd)
        {
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d1loc))
            {
                var door1 = (GameObject)Instantiate(door, d1loc, Quaternion.Euler(0, 0, 0), gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d1loc);
                RotateDoor(d1loc, door1);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d2loc))
            {
                var door2 = (GameObject)Instantiate(door, d2loc, Quaternion.Euler(0, 0, 0), gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d2loc);
                RotateDoor(d2loc, door2);
            }
        }


        if (isthree)
        {
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d1loc))
            {
                var door1 = (GameObject)Instantiate(door, d1loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d1loc);
                RotateDoor(d1loc, door1);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d2loc))
            {
                var door2 = (GameObject)Instantiate(door, d2loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d2loc);
                RotateDoor(d2loc, door2);
            }

            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d3loc))
            {
                var door3 = (GameObject)Instantiate(door, d3loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d3loc);
                RotateDoor(d3loc, door3);
            }
        }

        if (isfour)
        {
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d1loc))
            {
                var door1 = (GameObject)Instantiate(door, d1loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d1loc);
                RotateDoor(d1loc, door1);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d2loc))
            {
                var door2 = (GameObject)Instantiate(door, d2loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d2loc);
                RotateDoor(d2loc, door2);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d3loc))
            {
                var door3 = (GameObject)Instantiate(door, d3loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d3loc);
                RotateDoor(d3loc, door3);
            }
            if (!GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(d4loc))
            {
                var door4 = (GameObject)Instantiate(door, d4loc, Quaternion.identity, gameObject.transform);
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(d4loc);
                RotateDoor(d4loc, door4);
            }
        }

        if (isdead)
        {
            
        }

    }

    void RotateDoor(Vector3 dloc, GameObject door)
    { var i = dloc.z;
        var k = dloc.x;
        int iter = 0;
        while (i % 10 == 0)
        {
            i /= 10;
            iter++;
            if (iter > 20)
            {
                break;
            }
        }
        iter = 0;
        while (k % 10 == 0)
        {
            k /= 10;
            iter++;
            if (iter > 20)
            {
                break;
            }
        }
        if (!Mathf.Approximately(i % 2, 0))
        {
            door.transform.eulerAngles = new Vector3(0, 90, 0);
        }

    }
}
