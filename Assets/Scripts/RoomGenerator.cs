using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MonoBehaviour {

    public bool isTileCorner;
    public bool isTileCorridor;
    public bool isTileDeadEnd;
    public bool isTileFourWay;
    public bool isTileThreeWay;
    public List<Object> CornerInstances;
    public List<Object> CorridorInstances;
    public List<Object> DeadEndInstances;
    public List<Object> ThreeWayInstances;
    public List<Object> FourWayInstances;


    void SetInstances()
    {
        if (isTileCorner)
        {
            CornerInstances.AddRange(Resources.LoadAll<GameObject>("CornerMeshes/"));
        }

        if (isTileCorridor)
        {
            CorridorInstances.AddRange(Resources.LoadAll<GameObject>("CorridorMeshes/"));
        }

        if (isTileDeadEnd)
        {
            DeadEndInstances.AddRange(Resources.LoadAll<GameObject>("DeadEndMeshes/"));
        }

        if (isTileFourWay)
        {
            FourWayInstances.AddRange(Resources.LoadAll<GameObject>("FourWayMeshes/"));
        }

        if (isTileThreeWay)
        {
            ThreeWayInstances.AddRange(Resources.LoadAll<GameObject>("ThreeWayMeshes/"));
        }

    }

    void Awake()
    {
        SetInstances();
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
        }
    }
    void CreateRandomCorridorInstance()
    {
        if (isTileCorridor)
        {
            var rand = Random.Range(0, CorridorInstances.Count);
            var corridor = Instantiate(CorridorInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            corridor.name = "CorridorInstance";
        }
    }
    void CreateRandomDeadEndInstance()
    {
        if (isTileDeadEnd)
        {
            var rand = Random.Range(0, DeadEndInstances.Count);
            var dd = Instantiate(DeadEndInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            dd.name = "DeadEndInstance";
        }
    }
    void CreateRandomThreeWayInstance()
    {
        if (isTileThreeWay)
        {
            var rand = Random.Range(0, ThreeWayInstances.Count);
            var tw = Instantiate(ThreeWayInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            tw.name = "CornerInstance";
        }
    }
    void CreateRandomFourWayInstance()
    {
        if (isTileFourWay)
        {
            var rand = Random.Range(0, FourWayInstances.Count);
            var fw = Instantiate(FourWayInstances[rand], gameObject.transform.position, gameObject.transform.rotation, gameObject.transform);
            fw.name = "CornerInstance";
        }
    }














}
