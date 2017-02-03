using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s173 : MonoBehaviour {
    public float timer = 1f;
    GameObject player;
    public List<Vector3> extents;
    BoxCollider headCol;
    BoxCollider bodyCol;
    public bool isVisible;
    public List<bool> state;
    Vector3 directionToExtent;
    int hit;
    public AudioClip move;
    Vector3 lasttransform;
    Vector3 deltaTransform;
    Vector3 lengthToPlayer;
    float randomTime;
    public LayerMask LayerMask;
    public AudioClip NeckSnap;

    private void Awake()
    {

    }
    // Use this for initialization
    void Start ()
    {

        player = GameObject.Find("FPSController");
        lasttransform = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update() {

        IsPlayerNear();
        deltaTransform = gameObject.transform.position - lasttransform;
        lasttransform = gameObject.transform.position;

        if (gameObject.GetComponent<AudioSource>().time > randomTime + 0.25f)
        {
            gameObject.GetComponent<AudioSource>().Stop();
        }

        if (isVisible)
        {
            gameObject.GetComponent<AIPath>().speed = 0;
            gameObject.GetComponent<AIPath>().turningSpeed = 0;

        }
        else
        {
            gameObject.GetComponent<AIPath>().speed = 20;
            gameObject.GetComponent<AIPath>().turningSpeed = 20;

        }

        if (deltaTransform.magnitude > 0.15 & !gameObject.GetComponent<AudioSource>().isPlaying) {
            gameObject.GetComponent<AudioSource>().clip = move;
            randomTime = Random.Range(0, 5);
            gameObject.GetComponent<AudioSource>().time = randomTime;

            gameObject.GetComponent<AudioSource>().Play();
        }


    }

    void IsPlayerNear()
    {

        lengthToPlayer = player.transform.position - gameObject.transform.position + new Vector3(0, 0.8f, 0);
        if (lengthToPlayer.magnitude < 40)
        {
            gameObject.GetComponent<AIPath>().target = player.transform;
            CheckObstacles();

        }
        else
        {
            gameObject.GetComponent<AIPath>().target = null;
        }

        if(lengthToPlayer.magnitude < 3f && !isVisible)
        {

            player.GetComponent<Character>().damage = 100;
             player.GetComponent<Character>().TakeDamage();
            gameObject.GetComponent<AudioSource>().PlayOneShot(NeckSnap);
        }
    }

    void CheckObstacles()
    {
        Vector3 directiontoPlayer = player.transform.position - gameObject.transform.position;
        state.Clear();
        extents.Clear();
        headCol = gameObject.transform.FindChild("HeadCol").GetComponent<BoxCollider>();
        bodyCol = gameObject.transform.FindChild("BodyCol").GetComponent<BoxCollider>();
        getVerts(headCol);
        getVerts(bodyCol);

        if (player.GetComponent<Character>().blink == true)
        {
            isVisible = false;
        }
        else
        {
            foreach (Vector3 extent in extents)
            {
                directionToExtent = extent - player.transform.position + new Vector3(0, 0.8f, 0);

                if (!Physics.Linecast(extent, player.transform.position + new Vector3(0, 0.8f, 0), LayerMask) && (Camera.main.WorldToViewportPoint(extent).x > 0 && Camera.main.WorldToViewportPoint(extent).y > 0 && Camera.main.WorldToViewportPoint(extent).x < 1 && Camera.main.WorldToViewportPoint(extent).y < 1 && Camera.main.WorldToViewportPoint(extent).z > 0))
                {

                    Debug.DrawLine(extent, player.transform.position + new Vector3(0, 0.8f, 0), Color.blue);
                    isVisible = true;
                    break;
                }
                else
                {
                    isVisible = false;
                    Debug.DrawLine(extent, player.transform.position + new Vector3(0, 0.8f, 0), Color.red);
                }


                //if ((!Physics.Linecast(extent, player.transform.position + new Vector3(0, 0.8f, 0), LayerMask) && (Vector3.Angle(directionToExtent, player.transform.forward) < 52 || Vector3.Angle(directionToExtent, player.transform.forward) > 308)))
                //{

                //    Debug.DrawLine(extent, player.transform.position + new Vector3(0, 0.8f, 0), Color.blue);
                //    isVisible = true;
                //    break;
                //}
                //else
                //{
                //    isVisible = false;
                //    Debug.DrawLine(extent, player.transform.position + new Vector3(0, 0.8f, 0), Color.red);
                //}
            }
        }
    }



    void getVerts(BoxCollider collider)
    {
        var center = collider.center;
        var xsize = collider.size.x;
        var ysize = collider.size.y;
        var zsize = collider.size.z;

        extents.Add(gameObject.transform.TransformPoint(center));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(xsize, ysize,zsize)/2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(xsize, ysize, -zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(-xsize, ysize, zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(-xsize, ysize, -zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(xsize, -ysize, zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(xsize, -ysize, -zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(-xsize, -ysize, zsize) / 2));
        extents.Add(gameObject.transform.TransformPoint(center + new Vector3(-xsize, -ysize, -zsize) / 2));


    }
}
