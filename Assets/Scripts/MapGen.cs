using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour {

    public int levelSize;
    public float tileSize;
    public GameObject tile;
    Vector3 currentPos;
    Vector3 nextPos;
    Vector3[] orientation;

    void Awake()
    {
        orientation[0] = new Vector3(tileSize, 0, 0);
    }
    // Use this for initialization
    void OnStart() {
        mapGen();
	}


    void mapGen ()
    {
        currentPos = new Vector3(0,0,0);
        Instantiate(tile, currentPos, new Quaternion());
        for (int i = 0; i < levelSize; i++)
        {
            foreach (Vector3 orient in orientation)
            {
                if ( Random.Range(0, 100) > 70)
                {
                    print("huy");
                    currentPos = currentPos + orient;
                }
            }

            Instantiate(tile, currentPos, new Quaternion());

        }
    }

    void gridCreation()
    {
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
