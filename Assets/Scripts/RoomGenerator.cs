using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public bool isTileCorner;
    public bool isTileCorridor;
    public bool isTileDeadEnd;
    public bool isTileFourWay;
    public bool isTileThreeWay;
    public List<GameObject> CornerInstances;
    public List<GameObject> CorridorInstances;
    public List<GameObject> DeadEndInstances;
    public List<GameObject> ThreeWayInstances;
    public List<GameObject> FourWayInstances;
    public Vector3 d1loc;
    public Vector3 d2loc;
    public Vector3 d3loc;
    public Vector3 d4loc;
    public Quaternion rot;
    public GameObject type;

    void CreateInstances()
    {

        CornerInstances.AddRange(Resources.LoadAll<GameObject>("CornerMeshes/CornerPrefabs"));

        CorridorInstances.AddRange(Resources.LoadAll<GameObject>("CorridorMeshes/CorridorPrefabs"));

        DeadEndInstances.AddRange(Resources.LoadAll<GameObject>("DeadEndMeshes/DeadEndPrefabs"));

        FourWayInstances.AddRange(Resources.LoadAll<GameObject>("FourWayMeshes/FourWayPrefabs"));
        
        ThreeWayInstances.AddRange(Resources.LoadAll<GameObject>("ThreeWayMeshes/ThreeWayPrefabs"));
    }

    void ResetInst()
    {
        CornerInstances.Clear();
        CorridorInstances.Clear();
        DeadEndInstances.Clear();
        ThreeWayInstances.Clear();
        FourWayInstances.Clear();

    }

    void Awake()
    {
        ResetInst();
        CreateInstances();
        CreateRandomCornerInstance();
        CreateRandomCorridorInstance();
        CreateRandomDeadEndInstance();
        CreateRandomFourWayInstance();
        CreateRandomThreeWayInstance();
    }

    void CreateRandomCornerInstance()
    {
        if (isTileCorner)
        {
            var rand = Random.Range(0, CornerInstances.Count);
            var corner = Instantiate(CornerInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            corner.name = "CornerInstance";
            type = corner;
        
            corner.AddComponent<DoorStandardPlace>();
            corner.GetComponent<DoorStandardPlace>().iscorner = true;
            corner.GetComponent<DoorStandardPlace>().rotator = rot;
            corner.GetComponent<DoorStandardPlace>().d1loc = d1loc;
            corner.GetComponent<DoorStandardPlace>().d2loc = d2loc;
        }
    }
    void CreateRandomCorridorInstance()
    {
        if (isTileCorridor)
        {
            var rand = Random.Range(0, CorridorInstances.Count);
            var corridor = Instantiate(CorridorInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            corridor.name = "CorridorInstance";
            type = corridor;

            corridor.AddComponent<DoorStandardPlace>();
            corridor.GetComponent<DoorStandardPlace>().rotator = rot;
            corridor.GetComponent<DoorStandardPlace>().iscorrd = true;
            corridor.GetComponent<DoorStandardPlace>().d1loc = d1loc;
            corridor.GetComponent<DoorStandardPlace>().d2loc = d2loc;

        }
    }

    void CreateRandomDeadEndInstance()
    {
        if (isTileDeadEnd)
        {
            var rand = Random.Range(0, DeadEndInstances.Count);
            var dd = Instantiate(DeadEndInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            dd.name = "DeadEndInstance";
            type = dd;

            dd.AddComponent<DoorStandardPlace>();
            dd.GetComponent<DoorStandardPlace>().rotator = rot;

            dd.GetComponent<DoorStandardPlace>().isdead = true;
            dd.GetComponent<DoorStandardPlace>().d1loc = d1loc;

        }
    }

    void CreateRandomThreeWayInstance()
    {
        if (isTileThreeWay)
        {
            var rand = Random.Range(0, ThreeWayInstances.Count);
            var tw = Instantiate(ThreeWayInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            tw.name = "ThreeWayInstance";
            type = tw;

            tw.AddComponent<DoorStandardPlace>();
            tw.GetComponent<DoorStandardPlace>().rotator = rot;
            tw.GetComponent<DoorStandardPlace>().isthree = true;
            tw.GetComponent<DoorStandardPlace>().d1loc = d1loc;
            tw.GetComponent<DoorStandardPlace>().d2loc = d2loc;
            tw.GetComponent<DoorStandardPlace>().d3loc = d3loc;
        }
    }

    void CreateRandomFourWayInstance()
    {
        if (isTileFourWay)
        {
            var rand = Random.Range(0, FourWayInstances.Count);
            var fw = Instantiate(FourWayInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            fw.name = "FourWayInstance";
            type = fw;

            fw.AddComponent<DoorStandardPlace>();
            fw.GetComponent<DoorStandardPlace>().rotator = rot;
            fw.GetComponent<DoorStandardPlace>().isfour = true;
            fw.GetComponent<DoorStandardPlace>().d1loc = d1loc;
            fw.GetComponent<DoorStandardPlace>().d2loc = d2loc;
            fw.GetComponent<DoorStandardPlace>().d3loc = d3loc;
            fw.GetComponent<DoorStandardPlace>().d4loc = d4loc;
        }
    }

}
