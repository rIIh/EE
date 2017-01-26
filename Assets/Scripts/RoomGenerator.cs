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
    public Vector3 orient;
    public Vector3 sideorient;

    void CreateInstances()
    {

        CornerInstances.AddRange(Resources.LoadAll<GameObject>("CornerMeshes/"));

        CorridorInstances.AddRange(Resources.LoadAll<GameObject>("CorridorMeshes/"));

        DeadEndInstances.AddRange(Resources.LoadAll<GameObject>("DeadEndMeshes/"));

        FourWayInstances.AddRange(Resources.LoadAll<GameObject>("FourWayMeshes/"));
        
        ThreeWayInstances.AddRange(Resources.LoadAll<GameObject>("ThreeWayMeshes/"));
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
            var corner = Instantiate(CornerInstances[rand], gameObject.transform.position, Quaternion.identity, gameObject.transform);
            corner.name = "CornerInstance";
        
            corner.AddComponent<DoorStandardPlace>();
            corner.GetComponent<DoorStandardPlace>().rotator = gameObject.transform.rotation;
            corner.GetComponent<DoorStandardPlace>().iscorner = true;

        }
    }
    void CreateRandomCorridorInstance()
    {
        if (isTileCorridor)
        {
            var rand = Random.Range(0, CorridorInstances.Count);
            var corridor = Instantiate(CorridorInstances[rand], gameObject.transform.position, Quaternion.identity, gameObject.transform);
            corridor.name = "CorridorInstance";
       

                corridor.AddComponent<DoorStandardPlace>();
            corridor.GetComponent<DoorStandardPlace>().iscorrd = true;
        }
    }
    void CreateRandomDeadEndInstance()
    {
        if (isTileDeadEnd)
        {
            var rand = Random.Range(0, DeadEndInstances.Count);
            var dd = Instantiate(DeadEndInstances[rand], gameObject.transform.position, Quaternion.identity, gameObject.transform);
            dd.name = "DeadEndInstance";
       

                dd.AddComponent<DoorStandardPlace>();

            dd.GetComponent<DoorStandardPlace>().isdead = true;
        }
    }
    void CreateRandomThreeWayInstance()
    {
        if (isTileThreeWay)
        {
            var rand = Random.Range(0, ThreeWayInstances.Count);
            var tw = Instantiate(ThreeWayInstances[rand], gameObject.transform.position, Quaternion.identity, gameObject.transform);
            tw.name = "ThreeWayInstance";
       

            tw.AddComponent<DoorStandardPlace>();

            tw.GetComponent<DoorStandardPlace>().isthree = true;
        }
    }

    void CreateRandomFourWayInstance()
    {
        if (isTileFourWay)
        {
            var rand = Random.Range(0, FourWayInstances.Count);
            var fw = Instantiate(FourWayInstances[rand], gameObject.transform.position, Quaternion.identity, gameObject.transform);
            fw.name = "FourWayInstance";


                fw.AddComponent<DoorStandardPlace>();

            fw.GetComponent<DoorStandardPlace>().isfour = true;
        }
    }

}
