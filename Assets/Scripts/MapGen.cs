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
    public List<Vector3> treeRoots = new List<Vector3>();
    Vector3 currentOrient;
    Vector3 wannaBeLoc;
    public GameObject root;
    void ResetVars()
    {
        tileCoords.Clear();
        orientation[0] = new Vector3(tileSize, 0, 0);
        orientation[1] = new Vector3(0, 0, tileSize);
        orientation[2] = new Vector3(-tileSize, 0, 0);
        orientation[3] = new Vector3(0, 0, -tileSize);
        tile.transform.localScale = new Vector3(tileSize / 100, (float)0.1, tileSize / 100);
        root.transform.localScale = new Vector3(tileSize / 100, (float)0.2, tileSize / 100);
    }

    void PlaceTile(Vector3 curLoc)
    {
        tileCoords.Add(curLoc);
        tile = Instantiate(tile, curLoc, new Quaternion());
        tile.transform.parent = gameObject.transform;
        tile.name = tile.name.Replace("(Clone)", "");
    }

    void PlaceDebugRoot(Vector3 Location)
    {
        root = Instantiate(root, Location , new Quaternion());
        root.name = root.name.Replace("(Clone)", "");
        root.transform.parent = gameObject.transform;
    }

    void Start()
    {
        ResetVars();
        PlaceTile(new Vector3(0, 0, 0));
        generateFirstBranch();
        PlaceRootPoints();
        GenerateBranches();
    }


    void generateFirstBranch()
    {
        currentPos = new Vector3(0, 0, 0);
        currentOrient = new Vector3(0, 0, 0);
        for (int i = 0; i < levelSize - 1; i++)
        {

            int orInd = Random.Range(0, 99) % 4;
            currentOrient = orientation[orInd];
            wannaBeLoc = currentPos + currentOrient;
            orInd++;

            if (orInd == 4)
            {
                orInd = 0;
            }


            if (
                !tileCoords.Contains(wannaBeLoc) &&
                !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
                (!tileCoords.Contains(wannaBeLoc + currentOrient - orientation[orInd]) ||
                !tileCoords.Contains(wannaBeLoc + currentOrient + orientation[orInd]))
                )
            {
                currentPos = wannaBeLoc;
                PlaceTile(currentPos);
            }
            else
            {
                i--;
                continue;
            }

        }
    }

    void PlaceRootPoints()
    {
        foreach(Vector3 curTile in tileCoords)
        {
            if (
                curTile != new Vector3(0,0,0) &&

                !treeRoots.Contains(curTile + orientation[0]) &&
                !treeRoots.Contains(curTile + orientation[1]) &&
                !treeRoots.Contains(curTile + orientation[2]) &&
                !treeRoots.Contains(curTile + orientation[3]) &&

                !treeRoots.Contains(curTile + orientation[0]+orientation[1]) &&
                !treeRoots.Contains(curTile + orientation[1]+orientation[2]) &&
                !treeRoots.Contains(curTile + orientation[2]+orientation[3]) &&
                !treeRoots.Contains(curTile + orientation[3]+orientation[0]) &&

                !treeRoots.Contains(curTile + 2*orientation[0]) &&
                !treeRoots.Contains(curTile + 2*orientation[1]) &&
                !treeRoots.Contains(curTile + 2*orientation[2]) &&
                !treeRoots.Contains(curTile + 2*orientation[3]) &&

                Random.Range(0,100) > 30
               )
            {
                treeRoots.Add(curTile);
                PlaceDebugRoot(curTile);
            }
        }

    }

    void GenerateBranches()
    {
        foreach(Vector3 curRoot in treeRoots)
        {
            currentPos = curRoot;
            int safe = 0;
            for(int i = 0; i < levelSize - 1; i++)
            {

                int orInd = Random.Range(0, 99) % 4;
                currentOrient = orientation[orInd];
                wannaBeLoc = currentPos + currentOrient;
                orInd++;

                if (orInd == 4)
                {
                    orInd = 0;
                }

                if (
                    !tileCoords.Contains(wannaBeLoc) &&
                    !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
                    !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
                    (!tileCoords.Contains(wannaBeLoc + currentOrient - orientation[orInd]) ||
                    !tileCoords.Contains(wannaBeLoc + currentOrient + orientation[orInd]))
                    )
                {
                    currentPos = wannaBeLoc;
                    PlaceTile(currentPos);
                }
                else
                {
                    i--;
                    safe++;
                    if (safe == levelSize)
                    {
                        break;
                    }
                    continue;
                }


            }
        }
    }

}



