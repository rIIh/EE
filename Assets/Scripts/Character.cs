using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Character : MonoBehaviour {
    public int health;
    public int damage;
    public bool godmode;
    public int processnow;
    public bool blink;
    public int progress;
    public float defx;
    public float defy;
    public bool invOpen;
    public GameObject[] items;
    public LayerMask interactive;

    IEnumerator BlinkScreen()
    { 
        //gameObject.GetComponentInChildren<Camera>().enabled = false;
        GameObject.Find("BlackScrCam").GetComponent<Camera>().enabled = true;
        yield return new WaitForSeconds(0.5f);
        if (!Input.GetKey(KeyCode.Space))
        {
            StopCoroutine("BlinkScreen");
            //gameObject.GetComponentInChildren<Camera>().enabled = true;
            GameObject.Find("BlackScrCam").GetComponent<Camera>().enabled = false;
            StartCoroutine("Blinking");

        }
    }


    IEnumerator Blinking()
    {

        while(true)
        {
            if(progress == 0)
            {

            }
            progress--;
            if (progress == -1)
            {
                blink = true;
                progress = 20;
                GameObject.Find("BlinkProgress").GetComponent<BlinkMeter>().ResetMeter();
                StopCoroutine("Blinking");
                 
            }

            if (progress != 20)
            {
                blink = false;
                GameObject.Find("BlinkProgress").GetComponent<BlinkMeter>().blinkProg = progress;
                GameObject.Find("BlinkProgress").GetComponent<BlinkMeter>().Change();
            }
            yield return new WaitForSeconds(0.5f);
            
        }
        
    }




    // Use this for initialization
    void Start()
    {
        items = new GameObject[10];

        GameObject.Find("System").transform.FindChild("Inventory").gameObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        invOpen = false;
        progress = 20;
        health = 100;
        StartCoroutine("Blinking");
        defx = gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity;
        defy = gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity;
    }

    public void TakeDamage()
    {
        if (!godmode)
        {
            health -= damage;
        }
    }




    void Death()
    {
        GameObject.Destroy(gameObject);
    }

    void Blink()
    {

        if(Input.GetKey(KeyCode.Space))
        {
            blink = true;
            StopCoroutine("Blinking");
            progress = 20;
            GameObject.Find("BlinkProgress").GetComponent<BlinkMeter>().ResetMeter();

        }




    }

	// Update is called once per frame
	void Update () {
        print(500f / (float)Screen.height);

        bool examining = GameObject.Find("System").transform.FindChild("Inventory").gameObject.GetComponent<Inventory>().examining;
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (invOpen)
            {
                if (examining == true)
                {
                    //GameObject.Find("System").transform.FindChild("Inventory").gameObject.GetComponent<Canvas>().enabled = true;
                       
                }
                else
                {
                    GameObject.Find("System").transform.FindChild("Inventory").gameObject.SetActive(false);
                    invOpen = false;
                    gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = defx;
                    gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = defy;

                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.Locked;
                }

            }
            else
            {
                GameObject.Find("System").transform.FindChild("Inventory").gameObject.SetActive(true);
                invOpen = true;
                gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

            }
        }
    

        RaycastHit hit;

        var camera = gameObject.transform.GetChild(0);

        Debug.DrawLine(camera.transform.position, camera.transform.position + camera.transform.forward , Color.red);
        //if (Physics.Linecast(camera.transform.position, camera.transform.position + camera.transform.forward * 3, out hit))
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 2f, interactive))
            {
                var resGO = hit.collider.gameObject;

            if (resGO.tag == "Document" && examining == false)
            {
                if (Input.GetMouseButton(0))
                {
                    for(int i = 0; i < 10; i++)
                    {
                        if (items[i] == null)
                        {
                            items[i] = resGO;
                            
                            print(items[i]);
                            resGO.SetActive(false);
                            break;
                        }
                    }                    
                }
            }




            if (resGO.tag == "Switch" && examining == false)
            {

                if (Input.GetMouseButton(0))
                {
                    //print(true);
                    //gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
                    //gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;

                    float rotY = Input.GetAxis("Mouse Y") * 8 * Mathf.Deg2Rad;
                    //float rotX = Input.GetAxis("Mouse X") * 5 * Mathf.Deg2Rad;
                    resGO.transform.RotateAroundLocal(new Vector3(1, 0, 0), -rotY);
                }
                if (Input.GetMouseButtonUp(0))
                {
                    gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = defx;
                    gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = defy;
                }
            }

        } 




        Blink();

		if (health <= 0 & !godmode)
        {
            Death();
        }
        if(blink == true)
        {
            StartCoroutine("BlinkScreen");
        }


    }

}
