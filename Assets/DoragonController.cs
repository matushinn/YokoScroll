using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DoragonController : MonoBehaviour {
    float speed = 5.0f;

    Animator animator;
	// Use this for initialization
	void Start () {

        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Animation();
    }
    void Move(){
            this.transform.position += this.transform.forward * speed * Time.deltaTime;
    }

    void Animation(){
        animator.SetBool("DoragonWallkRight", true);
    }
    
}
