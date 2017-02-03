using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void Update()
    {
        if (gameObject.transform.FindChild("Switch").transform.FindChild("Switcher").GetComponent<Switch>().state2)
        {
            print(true);
            gameObject.GetComponent<Animator>().SetTrigger("Open");
        }
    }

    // Update is called once per frame
 
}
