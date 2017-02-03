using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkMeter : MonoBehaviour {
    public int blinkProg;
    public Vector2 position;
    int progress;
    RectTransform gotransform;
	// Use this for initialization
	void Start () {
		
	}

    public void ResetMeter()
    {
        gotransform.anchoredPosition = new Vector2(0, 0);

    }
    public void Change()
    {
        progress = 20 - blinkProg;
        gotransform = (RectTransform)gameObject.transform;
        gotransform.anchoredPosition = gotransform.anchoredPosition - new Vector2(14f, 0);

    }

	// Update is called once per frame
	void Update () {

	}
}
