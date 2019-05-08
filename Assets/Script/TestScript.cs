using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

    public GameObject obj;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.anyKeyDown)
        {
            clickObj();
        }
	}
    public void clickObj()
    {
        obj.GetComponent<Rigidbody>().AddForce(-transform.right * 500);
        Debug.Log("ClickObj");
        
    }
}
