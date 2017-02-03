using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class Inventory : MonoBehaviour {

    GameObject[] items;
    Vector3 center;
    public bool examining;
    IEnumerator Examining(GameObject item)
    {
        center = new Vector3(Screen.width / 2, Screen.height / 2, 0.5f);

        GameObject.Find("FPSController").gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = GameObject.Find("FPSController").gameObject.GetComponent<Character>().defx;
        GameObject.Find("FPSController").gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = GameObject.Find("FPSController").gameObject.GetComponent<Character>().defy;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        while (!Input.GetMouseButton(1))
        {
            //item.transform.position = Vector3.MoveTowards(item.transform.position, Camera.main.ScreenToWorldPoint(center), 4f*Time.deltaTime);
            item.transform.position = Camera.main.ScreenToWorldPoint(center);
            item.transform.LookAt(Camera.main.transform);
            item.transform.Rotate(90, 0, 0);
            item.transform.localScale = item.transform.localScale - new Vector3(0.01f*Input.GetAxis("Mouse ScrollWheel"), 0, 0.014142f * Input.GetAxis( "Mouse ScrollWheel"));

            yield return new WaitForEndOfFrame();
        }
        print(true);
        GameObject.Find("FPSController").gameObject.GetComponent<FirstPersonController>().m_MouseLook.XSensitivity = 0;
        GameObject.Find("FPSController").gameObject.GetComponent<FirstPersonController>().m_MouseLook.YSensitivity = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        gameObject.GetComponent<Canvas>().enabled = true;
        GameObject.Destroy(item);
        examining = false;
        StopCoroutine("Examining");
    }



    void Start () {
    }

    // Update is called once per frame
    void Update () {

        for (int i = 0; i < 10; i++)
        {
            if (GameObject.Find("FPSController").GetComponent<Character>().items[i] != null)
            {
                var text = GameObject.Find("FPSController").GetComponent<Character>().items[i].name;
                gameObject.transform.GetChild(i).gameObject.GetComponentInChildren<Text>().text = text;
            }
        }


	}

    public void Examine(int index)
    {
        if(GameObject.Find("FPSController").GetComponent<Character>().items[index].tag == "Document")
        {
            var item = Instantiate(GameObject.Find("FPSController").GetComponent<Character>().items[index], Camera.main.ScreenToWorldPoint(center), Quaternion.identity);
            item.SetActive(true);
            item.GetComponent<Rigidbody>().useGravity = false;
            //item.GetComponent<BoxCollider>().enabled = false;

            item.transform.LookAt(Camera.main.transform);
            gameObject.GetComponent<Canvas>().enabled = false;
            StartCoroutine("Examining", item);
            examining = true;
        }
    }
}
