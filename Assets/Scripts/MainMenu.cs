using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public string seed;
    string seed1;

    public void StartPlayBTN()
    {
        GameObject.Find("Canvas").transform.FindChild("Panel").transform.FindChild("Slide").GetComponent<Animator>().SetBool("AnyButtonPressed", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").GetComponent<Animator>().SetBool("StartGameBtn", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").GetComponent<Animator>().SetBool("OnTheScreen", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("OnTheScreen", false);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("ExitBtn", false);

    }

    public void Awake()
    {  
        seed = Random.Range(133214, 99123993).ToString();
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").transform.FindChild("SeedInput").GetComponent<InputField>().text = seed;

    }

    public void SetSeed()
    {
        seed1 = GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").transform.FindChild("SeedInput").GetComponent<InputField>().text;
        seed = seed1;
    }

    public void OnStartPressed()
    {
        Seed.seedsave = seed;
        SceneManager.LoadScene("EE");
    }

    public void OnClickExit()
    {
        GameObject.Find("Canvas").transform.FindChild("Panel").transform.FindChild("Slide").GetComponent<Animator>().SetBool("AnyButtonPressed", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("ExitBtn", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("OnTheScreen", true);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").GetComponent<Animator>().SetBool("OnTheScreen", false);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("StartGame").GetComponent<Animator>().SetBool("StartGameBtn", false);

    }
public void ExitYes()
    {
        Application.Quit();
    }
    public void ExitNo()
    {
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("OnTheScreen", false);
        GameObject.Find("Canvas").transform.FindChild("RightMask").transform.FindChild("Exit").GetComponent<Animator>().SetBool("ExitBtn", false);
        GameObject.Find("Canvas").transform.FindChild("Panel").transform.FindChild("Slide").GetComponent<Animator>().SetBool("AnyButtonPressed", false);

    }

}
