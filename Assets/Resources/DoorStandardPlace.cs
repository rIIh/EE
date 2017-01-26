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

    // Use this for initialization
    void Start() {

        transform.position.Set(Mathf.RoundToInt(transform.position.x), Mathf.RoundToInt(transform.position.y), Mathf.RoundToInt(transform.position.z));


        door = Resources.Load("Door");
        if (iscorner)
        {
            var door1 = (GameObject)Instantiate(door, transform.position + new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 0), gameObject.transform);
            var door2 = (GameObject)Instantiate(door, transform.position - new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
          gameObject.transform.rotation = rotator;
            door1.transform.position.Set(Mathf.RoundToInt(door1.transform.position.x), Mathf.RoundToInt(door1.transform.position.y), Mathf.RoundToInt(door1.transform.position.z));
            door2.transform.position.Set(Mathf.RoundToInt(door2.transform.position.x), Mathf.RoundToInt(door2.transform.position.y), Mathf.RoundToInt(door2.transform.position.z));
            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door1.transform.position))
            {
                print("Destroes");

               DestroyObject(door1);
            } else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door1.transform.position);

            }
            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door2.transform.position))
            {
                print("Destroes");
                DestroyObject(door2);
            } else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door2.transform.position);

            }
        }
        if (iscorrd)
        {
            var door1 = (GameObject)Instantiate(door, transform.position + new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
            var door2 = (GameObject)Instantiate(door, transform.position - new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
           gameObject.transform.rotation = rotator;
            door1.transform.position.Set(Mathf.RoundToInt(door1.transform.position.x), Mathf.RoundToInt(door1.transform.position.y), Mathf.RoundToInt(door1.transform.position.z));
            door2.transform.position.Set(Mathf.RoundToInt(door2.transform.position.x), Mathf.RoundToInt(door2.transform.position.y), Mathf.RoundToInt(door2.transform.position.z));

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door1.transform.position))
            {
                print("Destroes");

                DestroyObject(door1);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door1.transform.position);
                print(door1.transform.position);

            }
            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door2.transform.position))
            {
                print("Destroes");
                DestroyObject(door2);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door2.transform.position);
                print(door2.transform.position);

            }
        }
        if (isthree)
        {
            var door1 = (GameObject)Instantiate(door, transform.position + new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
            var door2 = (GameObject)Instantiate(door, transform.position + new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 0), gameObject.transform);
            var door3 = (GameObject)Instantiate(door, transform.position - new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
           gameObject.transform.rotation = rotator;
            door1.transform.position.Set(Mathf.RoundToInt(door1.transform.position.x), Mathf.RoundToInt(door1.transform.position.y), Mathf.RoundToInt(door1.transform.position.z));
            door2.transform.position.Set(Mathf.RoundToInt(door2.transform.position.x), Mathf.RoundToInt(door2.transform.position.y), Mathf.RoundToInt(door2.transform.position.z));
            door3.transform.position.Set(Mathf.RoundToInt(door3.transform.position.x), Mathf.RoundToInt(door3.transform.position.y), Mathf.RoundToInt(door3.transform.position.z));

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door1.transform.position))
            {
                print("Destroes");

                DestroyObject(door1);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door1.transform.position);
            }

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door2.transform.position))
            {
                print("Destroes");
               DestroyObject(door2);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door2.transform.position);

            }

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door3.transform.position))
            {
                print("Destroes");
                DestroyObject(door3);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door3.transform.position);

            }
        }

        if (isfour)
        {
            var door1 = (GameObject)Instantiate(door, transform.position + new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
            var door2 = (GameObject)Instantiate(door, transform.position + new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 0), gameObject.transform);
            var door3 = (GameObject)Instantiate(door, transform.position - new Vector3(0, 0, 10), Quaternion.Euler(0, 90, 0), gameObject.transform);
            var door4 = (GameObject)Instantiate(door, transform.position - new Vector3(10, 0, 0), Quaternion.Euler(0, 0, 0), gameObject.transform);
          gameObject.transform.rotation = rotator;
            door1.transform.position.Set(Mathf.RoundToInt(door1.transform.position.x), Mathf.RoundToInt(door1.transform.position.y), Mathf.RoundToInt(door1.transform.position.z));
            door2.transform.position.Set(Mathf.RoundToInt(door2.transform.position.x), Mathf.RoundToInt(door2.transform.position.y), Mathf.RoundToInt(door2.transform.position.z));
            door3.transform.position.Set(Mathf.RoundToInt(door3.transform.position.x), Mathf.RoundToInt(door3.transform.position.y), Mathf.RoundToInt(door3.transform.position.z));
            door4.transform.position.Set(Mathf.RoundToInt(door4.transform.position.x), Mathf.RoundToInt(door4.transform.position.y), Mathf.RoundToInt(door4.transform.position.z));


            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door1.transform.position))
            {
                print("Destroes");

                DestroyObject(door1);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door1.transform.position);
            }

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door2.transform.position))
            {
                print("Destroes");
                DestroyObject(door2);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door2.transform.position);

            }

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door3.transform.position))
            {
                print("Destroes");
               DestroyObject(door3);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door3.transform.position);

            }

            if (GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Contains(door4.transform.position))
            {
                print("Destroes");

                DestroyObject(door4);
            }
            else
            {
                GameObject.Find("MapGenerator").GetComponent<MapGen>().DoorCoords.Add(door4.transform.position);
            }


        }

        if (isdead)
        {
           gameObject.transform.rotation = rotator;
        }
    }


}
