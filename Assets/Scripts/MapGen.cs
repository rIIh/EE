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
    public List<Vector3> linkCoords = new List<Vector3>();
    Vector3 currentOrient;
    Vector3 wannaBeLoc;
    public GameObject root;
    public GameObject link;
    List<GameObject> links = new List<GameObject>();
    List<GameObject> roots = new List<GameObject>();

    void ResetVars()
    {
        tileCoords.Clear();
        orientation[0] = new Vector3(tileSize, 0, 0);
        orientation[1] = new Vector3(0, 0, tileSize);
        orientation[2] = new Vector3(-tileSize, 0, 0);
        orientation[3] = new Vector3(0, 0, -tileSize);
        tile.transform.localScale = new Vector3(tileSize / 100, (float)0.1, tileSize / 100);
        root.transform.localScale = new Vector3(tileSize / 100, (float)0.2, tileSize / 100);
        link.transform.localScale = new Vector3(tileSize / 10, (float)0.1, tileSize / 10);
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
        root = Instantiate(root, Location, new Quaternion());
        roots.Add(root);
        root.name = root.name.Replace("(Clone)", "");
        root.transform.parent = gameObject.transform;
    }

    void PlaceDebugLink(Vector3 Location)
    {
        link = Instantiate(link, Location, new Quaternion());
        links.Add(link);
        link.name = link.name.Replace("(Clone)", "");
        link.transform.parent = gameObject.transform;
    }

    void Start()
    {
        ResetVars();
        PlaceTile(new Vector3(0, 0, 0));
        generateFirstBranch(new Vector3(0,0,0), levelSize);
        PlaceRootPoints();
        GenerateBranches(levelSize);
        PlaceLinks();
        LinkTiles();
        linkCoords.Clear();
        PlaceLinks();
        GenerateExtraBranches(3);
        linkCoords.Clear();
        PlaceLinks();
        LinkTiles();
    }


    void generateFirstBranch(Vector3 currentPos, int size)
    {
        currentOrient = new Vector3(0, 0, 0);
        var safe = 0;
        for (int i = 0; i < size - 1; i++)
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
                (!tileCoords.Contains(wannaBeLoc + currentOrient - orientation[orInd])
                ||
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
                if(safe > 40) { break; }
                continue;
            }
        }
    }

    void PlaceRootPoints()
    {
        foreach (Vector3 curTile in tileCoords)
        {
            if (
                curTile != new Vector3(0, 0, 0) &&

                !treeRoots.Contains(curTile + orientation[0]) &&
                !treeRoots.Contains(curTile + orientation[1]) &&
                !treeRoots.Contains(curTile + orientation[2]) &&
                !treeRoots.Contains(curTile + orientation[3]) &&

                !treeRoots.Contains(curTile + orientation[0] + orientation[1]) &&
                !treeRoots.Contains(curTile + orientation[1] + orientation[2]) &&
                !treeRoots.Contains(curTile + orientation[2] + orientation[3]) &&
                !treeRoots.Contains(curTile + orientation[3] + orientation[0]) &&

                !treeRoots.Contains(curTile + 2 * orientation[0]) &&
                !treeRoots.Contains(curTile + 2 * orientation[1]) &&
                !treeRoots.Contains(curTile + 2 * orientation[2]) &&
                !treeRoots.Contains(curTile + 2 * orientation[3]) &&

                Random.Range(0, 100) > 30
               )
            {
                treeRoots.Add(curTile);
                PlaceDebugRoot(curTile);
            }
        }

    }

    void GenerateBranches(int branchSize)
    {
        foreach (Vector3 curRoot in treeRoots)
        {
            currentPos = curRoot;
            int safe = 0;
            for (int i = 0; i < branchSize - 1; i++)
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

    void PlaceLinks()
    {
        int i;
        Vector3 placeLoc;
        foreach (Vector3 loc in tileCoords)
        {
            var ind = 0; 
            foreach (Vector3 orient in orientation)
            {
                i = ind + 1;
                if (i == 4) { i = 0; }
                if (
                    tileCoords.Contains(loc + orient) &&
                    tileCoords.Contains(loc - orient) &&
                    !tileCoords.Contains(loc + orientation[i]) &&
                    !tileCoords.Contains(loc - orientation[i])
                    )
                {
                    if (
                        !tileCoords.Contains(loc + orientation[i] + orient) &&
                        !tileCoords.Contains(loc + orientation[i] - orient) &&
                        !tileCoords.Contains(loc + orientation[i]) &&

                        !linkCoords.Contains(loc + orient - orientation[i]) &&
                        !linkCoords.Contains(loc + orient + orientation[i]) &&
                        !linkCoords.Contains(loc - orient + orientation[i]) &&
                        !linkCoords.Contains(loc - orient - orientation[i])
                        )
                    {
                        placeLoc = loc + orientation[i];
                        if (linkCoords.Contains(placeLoc))
                        {
                        }
                        else
                        {
                            PlaceDebugLink(placeLoc);
                            linkCoords.Add(placeLoc);
                        }
                    }


                    if (
                            !tileCoords.Contains(loc - orientation[i] + orient) &&
                            !tileCoords.Contains(loc - orientation[i] - orient) &&
                            !tileCoords.Contains(loc - orientation[i]) &&

                            !linkCoords.Contains(loc + orient - orientation[i]) &&
                            !linkCoords.Contains(loc + orient + orientation[i]) &&
                            !linkCoords.Contains(loc - orient + orientation[i]) &&
                            !linkCoords.Contains(loc - orient - orientation[i])
                        )
                    {
                        placeLoc = loc - orientation[i];
                        if (linkCoords.Contains(placeLoc))
                        {
                            break;
                        }
                        else
                        {
                            PlaceDebugLink(placeLoc);
                            linkCoords.Add(placeLoc);
                            break;
                        }

                    }
                    
                } else { print(false); }
                ind++;
            }
        }
    }

    void LinkTiles()
    { var ind = 0;
        foreach (Vector3 curPos in linkCoords)
        {
            for (int i = 0; i < 4; i++)
            {
                var orient = orientation[i];
                var side = i + 1;
                if (side == 4) { side = 0; }
                if (
                        (
                        tileCoords.Contains(curPos + orient + orientation[side]) &&
                        tileCoords.Contains(curPos + orient) &&
                        tileCoords.Contains(curPos + orient - orientation[side]) &&
                        tileCoords.Contains(curPos - orient + orientation[side]) &&
                        tileCoords.Contains(curPos - orient) &&
                        tileCoords.Contains(curPos - orient - orientation[side])
                        )
                    ||
                        (
                        tileCoords.Contains(curPos + orient + orientation[side]) &&
                        tileCoords.Contains(curPos + orient - orientation[side]) &&
                        tileCoords.Contains(curPos + orient)
                        &&
                        (tileCoords.Contains(curPos - orient - orientation[side]) 
                        ||
                        tileCoords.Contains(curPos - orient + orientation[side]))
                        &&
                        tileCoords.Contains(curPos - orient) &&
                        !tileCoords.Contains(curPos + orientation[side]) &&
                        !tileCoords.Contains(curPos - orientation[side])
                        )
                    )
                {
                    print(true);
                    PlaceTile(curPos);
                    break;
                }
            }
            ind++;
        }
    }

    void GenerateExtraBranches(int size)
    {
        foreach(Vector3 curLoc in linkCoords)
        {
            PlaceTile(curLoc);
            generateFirstBranch(curLoc, size);
        }
    }
}




