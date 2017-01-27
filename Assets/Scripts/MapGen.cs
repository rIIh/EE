using System.Collections.Generic;
using UnityEngine;

public class MapGen : MonoBehaviour
{
    public string seed;
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
    public GameObject corner;
    public GameObject corridor;
    public GameObject threeway;
    public GameObject fourway;
    public GameObject deadEnd;
    int ebSize;
    public List<Vector3> DoorCoords;
    public bool Debug;

    void ResetVars()
    {
        tileCoords.Clear();
        treeRoots.Clear();
        linkCoords.Clear();
        orientation[0] = new Vector3(tileSize, 0, 0);
        orientation[1] = new Vector3(0, 0, -tileSize);
        orientation[2] = new Vector3(-tileSize, 0, 0);
        orientation[3] = new Vector3(0, 0, tileSize);
        tile.transform.localScale = new Vector3(tileSize / 100, (float)0.1, tileSize / 100);
        //root.transform.localScale = new Vector3(tileSize / 100, (float)0.2, tileSize / 100);
        link.transform.localScale = new Vector3(tileSize / 10, (float)0.3, tileSize / 10);
        ebSize = levelSize / 5;
    }


    void PlaceTile(Vector3 curLoc)
    {
        if (!tileCoords.Contains(curLoc))
        {
            tileCoords.Add(curLoc);
            if (Debug)
            {
                PlaceDebugTile(curLoc);
            }
        }
    }


    void PlaceDebugTile(Vector3 Location)
    {
        tile = Instantiate(tile, Location, Quaternion.identity, gameObject.transform);
        tile.name = "Tile";
    }

    void PlaceDebugRoot(Vector3 Location)
    {
        root = Instantiate(root, Location, Quaternion.identity, gameObject.transform);
        root.name = "Root";
    }

    void PlaceDebugLink(Vector3 Location)
    {
        link = Instantiate(link, Location, Quaternion.identity, gameObject.transform);
        link.name = "Link";
    }


    void Start()
    {
        Random.seed = seed.GetHashCode();
        ResetVars();
        PlaceTile(new Vector3(0, 0, 0));
        generateFirstBranch(new Vector3(0, 0, 0), levelSize);
        PlaceRootPoints();
        GenerateBranches(levelSize);
        PlaceLinks();
        LinkTiles();

        linkCoords.Clear();
        PlaceLinks();
        GenerateExtraBranches(ebSize);
        linkCoords.Clear();
        PlaceLinks();
        LinkTiles();

        linkCoords.Clear();
        PlaceLinks();
        GenerateExtraBranches(ebSize);
        linkCoords.Clear();
        PlaceLinks();
        LinkTiles();

        linkCoords.Clear();
        PlaceLinks();
        GenerateExtraBranches(ebSize);
        linkCoords.Clear();
        PlaceLinks();
        LinkTiles();


        PlaceCorridors();
        placeLights();
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
                !tileCoords.Contains(wannaBeLoc - orientation[orInd]))
            {
                currentPos = wannaBeLoc;
                PlaceTile(currentPos);
            }
            else if (
                !tileCoords.Contains(wannaBeLoc) &&
                (
                (
                !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc - currentOrient) &&
                !tileCoords.Contains(wannaBeLoc - currentOrient + orientation[orInd])
                )
                ||
                (
                !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
                !tileCoords.Contains(wannaBeLoc - currentOrient) &&
                !tileCoords.Contains(wannaBeLoc - currentOrient - orientation[orInd])
                )
                )

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



            //if (
            //    !tileCoords.Contains(wannaBeLoc) &&
            //    !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
            //    !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
            //    (!tileCoords.Contains(wannaBeLoc + currentOrient - orientation[orInd])
            //    ||
            //    !tileCoords.Contains(wannaBeLoc + currentOrient + orientation[orInd]))
            //    )
            //{
            //    currentPos = wannaBeLoc;
            //    PlaceTile(currentPos);
            //}
            //else
            //{
            //    i--;
            //    safe++;
            //    if (safe > 40) { break; }
            //    continue;
            //}
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
                if (Debug)
                {
                    PlaceDebugRoot(curTile);
                }
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
                    !tileCoords.Contains(wannaBeLoc - orientation[orInd]))
                {
                    currentPos = wannaBeLoc;
                    PlaceTile(currentPos);
                }
                else if (
                    !tileCoords.Contains(wannaBeLoc) &&
                    (
                    (
                    !tileCoords.Contains(wannaBeLoc + orientation[orInd]) &&
                    !tileCoords.Contains(wannaBeLoc - currentOrient) &&
                    !tileCoords.Contains(wannaBeLoc - currentOrient + orientation[orInd])
                    )
                    ||
                    (
                    !tileCoords.Contains(wannaBeLoc - orientation[orInd]) &&
                    !tileCoords.Contains(wannaBeLoc - currentOrient) &&
                    !tileCoords.Contains(wannaBeLoc - currentOrient - orientation[orInd])
                    )
                    )

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
                            if (Debug)
                            {
                                PlaceDebugLink(placeLoc);
                            }
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
                            if (Debug)
                            {
                                PlaceDebugLink(placeLoc);
                                linkCoords.Add(placeLoc);
                                break;
                            }
                            linkCoords.Add(placeLoc);

                        }

                    }

                }
                ind++;
            }
        }
    }

    void LinkTiles()
    {
        var ind = 0;
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
                    PlaceTile(curPos);
                    break;
                }
            }
            ind++;
        }
    }

    void GenerateExtraBranches(int size)
    {
        foreach (Vector3 curLoc in linkCoords)
        {
            PlaceTile(curLoc);
            generateFirstBranch(curLoc, size);
        }
    }

    void PlaceCorridors()
    {
        foreach (Vector3 curPos in tileCoords)
        {
            for (int i = 0; i < 4; i++)
            {
                var orient = orientation[i];
                var ind = i + 1;
                if (ind == 4) { ind = 0; }
                bool isCorner = (
                    !tileCoords.Contains(curPos + orient) &
                    tileCoords.Contains(curPos - orient) &
                    tileCoords.Contains(curPos + orientation[ind]) &
                    !tileCoords.Contains(curPos - orientation[ind])
                    );

                bool isCorridor =
                    tileCoords.Contains(curPos + orient) &
                    tileCoords.Contains(curPos - orient) &
                    !tileCoords.Contains(curPos + orientation[ind]) &
                    !tileCoords.Contains(curPos - orientation[ind]);

                bool isThreeWay =
                    tileCoords.Contains(curPos + orient) &
                    tileCoords.Contains(curPos - orient) &
                    tileCoords.Contains(curPos + orientation[ind]) &
                    !tileCoords.Contains(curPos - orientation[ind]);

                bool isFourWay =
                    tileCoords.Contains(curPos + orient) &
                    tileCoords.Contains(curPos - orient) &
                    tileCoords.Contains(curPos + orientation[ind]) &
                    tileCoords.Contains(curPos - orientation[ind]);

                bool isDeadEnd =
                    tileCoords.Contains(curPos + orient) &
                    !tileCoords.Contains(curPos - orient) &
                    !tileCoords.Contains(curPos + orientation[ind]) &
                    !tileCoords.Contains(curPos - orientation[ind]);

                var rotator = Quaternion.identity;
                rotator.eulerAngles = new Vector3(0, (ind) * 90, 0);

                if (isCorner)
                {
                    Instantiate(corner, curPos + new Vector3(0, 1, 0), rotator, gameObject.transform);
                    corner.GetComponent<RoomGenerator>().isTileCorner = true;
                    corner.GetComponent<RoomGenerator>().rot = rotator;
                    corner.GetComponent<RoomGenerator>().d1loc = curPos - orient / 2 + new Vector3(0, 1, 0);
                    corner.GetComponent<RoomGenerator>().d2loc = curPos + orientation[ind] / 2 + new Vector3(0, 1, 0);
                    corner.tag = "Corner";

                    break;
                }
                else if (isCorridor)
                {
                    Instantiate(corridor, curPos + new Vector3(0, 1, 0), rotator, gameObject.transform);
                    corridor.GetComponent<RoomGenerator>().isTileCorridor = true;
                    corridor.GetComponent<RoomGenerator>().rot = rotator;
                    corridor.GetComponent<RoomGenerator>().d1loc = curPos + orient/2 + new Vector3(0, 1, 0);
                    corridor.GetComponent<RoomGenerator>().d2loc = curPos - orient/2 + new Vector3(0, 1, 0);

                    corridor.tag = "Corridor";
                    break;
                }
                else if (isThreeWay)
                {
                    Instantiate(threeway, curPos + new Vector3(0, 1, 0), rotator, gameObject.transform);
                    threeway.GetComponent<RoomGenerator>().isTileThreeWay = true;
                    threeway.GetComponent<RoomGenerator>().rot = rotator;
                    threeway.GetComponent<RoomGenerator>().d1loc = curPos + orient/2 + new Vector3(0, 1, 0);
                    threeway.GetComponent<RoomGenerator>().d2loc = curPos + orientation[ind]/2 + new Vector3(0, 1, 0);
                    threeway.GetComponent<RoomGenerator>().d3loc = curPos - orient/2 + new Vector3(0, 1, 0);
                    threeway.tag = "ThreeWay";
                    break;

                }
                else if (isFourWay)
                {
                    Instantiate(fourway, curPos + new Vector3(0, 1, 0), rotator, gameObject.transform);
                    fourway.GetComponent<RoomGenerator>().isTileFourWay = true;
                    fourway.GetComponent<RoomGenerator>().rot = rotator;
                    fourway.GetComponent<RoomGenerator>().d1loc = curPos +  orient/2 + new Vector3(0, 1, 0);
                    fourway.GetComponent<RoomGenerator>().d2loc = curPos + orientation[ind]/2 + new Vector3(0, 1, 0);
                    fourway.GetComponent<RoomGenerator>().d3loc = curPos - orientation[ind]/2 + new Vector3(0, 1, 0);
                    fourway.GetComponent<RoomGenerator>().d4loc = curPos - orient/2 + new Vector3(0, 1, 0);
                    fourway.tag = "FourWay";
                    break;

                }
                else if (isDeadEnd)
                {
                    Instantiate(deadEnd, curPos + new Vector3(0, 1, 0), rotator, gameObject.transform);
                    deadEnd.GetComponent<RoomGenerator>().isTileDeadEnd = true;
                    deadEnd.GetComponent<RoomGenerator>().rot = rotator;
                    deadEnd.tag = "DeadEnd";
                    deadEnd.GetComponent<RoomGenerator>().d1loc = curPos + orient / 2 + new Vector3(0, 1, 0);
                    break;
                } 

            }
        }
    }

    void placeLights()
    {
        foreach (Vector3 tile in tileCoords)
        {
            var light = new GameObject("Light");
            light.transform.position = tile + new Vector3(0, 3.5f, 0);
            light.transform.parent = gameObject.transform;
            Light lightComp = light.AddComponent<Light>();
            lightComp.shadows = LightShadows.Soft;
            lightComp.intensity = 1.2F;
            lightComp.range = 20;
        }

    }

 

}




