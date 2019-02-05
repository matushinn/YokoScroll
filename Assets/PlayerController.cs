using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

    float speed = 5.0f;
    float jumpPower = 5.0f;
    int jumpCount;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKey("right")){
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("up") && jumpCount < 2)
        {
            this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount++;
        }

       
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground"){
            jumpCount = 0;
        }
        if (col.gameObject.tag == "Coin")
        {
            Destroy(col.gameObject);
        }
    }
}
