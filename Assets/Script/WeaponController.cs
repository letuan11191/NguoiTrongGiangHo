using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    Animator EnemyAnim;
	// Use this for initialization
	void Start () {
        EnemyAnim = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D obj)
    {
        if(obj.transform.tag == "Enemy")
        {
            Debug.Log("ChemTrung");
            //EnemyAnim.SetTrigger("ToInjured");
        }
    }
}
