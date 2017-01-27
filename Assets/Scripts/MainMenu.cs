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
}
