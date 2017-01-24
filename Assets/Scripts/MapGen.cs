using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    
    public int levelSize;
    public float tileSize;
    public GameObject tile;
    Vector3 currentPos;
    Vector3[] orientation = new Vector3[4];
    public List<Vector3> tileCoords = new List<Vector3>();
    Vector3 currentOrient;
    Vector3 wannaBeLoc;

    void ResetVars()
    {
        tileCoords.Clear();
        orientation[0] = new Vector3(tileSize, 0, 0);
        orientation[1] = new Vector3(0, 0, tileSize);
        orientation[2] = new Vector3(-tileSize, 0, 0);
        orientation[3] = new Vector3(0, 0, -tileSize);
        tile.transform.localScale = new Vector3(tileSize / 100, (float)0.1, tileSize / 100);
    }

    void PlaceTile(Vector3 CurLoc, int ind)
    {
        tileCoords.Add(CurLoc);
        tile = Instantiate(tile, currentPos + new Vector3(0, ((float)ind+1)/5, 0), new Quaternion());
        tile.transform.parent = gameObject.transform;
        tile.name = tile.name.Replace("(Clone)", "");
    }

    void Start()
    {
        ResetVars();
        PlaceTile(new Vector3(0, 0, 0), -1);
        generateFirstBranch();
    }


    void generateFirstBranch()
    {
        currentPos = new Vector3(0, 0, 0);
        currentOrient = new Vector3(0, 0, 0);
        for (int i = 0; i < levelSize - 1; i++)
        {
            int orInd = 0;
            foreach ( Vector3 orient in orientation)
            {
                orInd++;
                if (Random.Range(0, 100) > Random.Range(60, 80))
                { 
                    wannaBeLoc = currentPos + orient;
                    currentOrient = orient;
                    break;
                }
            }

            //orInd++;

            if (orInd == 4)
            {
                orInd = 0;
            }

            if(orInd > 4)
            {
                i--;
                continue;
            }


            if (
                !tileCoords.Contains(wannaBeLoc) &&
 //               !tileCoords.Contains(wannaBeLoc + currentOrient) &&
                !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc + currentOrient - orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc + currentOrient + orientation[orInd])
                )
            {
                currentPos = wannaBeLoc;
                PlaceTile(currentPos, i);
            }
            else
            {
                i--;
                continue;
            }

        }
    }


}



