using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public Image hpImage;

    float currentHP = 5;
    float maxHP = 5;

    float speed = 5.0f;
    float jumpPower = 5.0f;
    int jumpCount;

    public AudioClip jumpSound;
    public AudioClip pickUpSound;

    AudioSource audioSource;
    Animator animator;
	// Use this for initialization
	void Start () {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        animator = this.gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        Animation();
    }
    void Move(){
        if (Input.GetKey("right"))
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("left"))
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKeyDown("space"))
        {
            if (jumpCount <= 2)
            {
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
                jumpCount++;
                audioSource.clip = jumpSound;
                audioSource.Play();
            }
        }

    }

    void Animation(){
        if (Input.GetKeyDown("right"))
        {
            animator.SetBool("WallkRight", true);
        }
        if (Input.GetKeyUp("right"))
        {
            animator.SetBool("WallkRight", false);
        }
        if (Input.GetKeyDown("left"))
        {
            animator.SetBool("WallkLeft", true);
        }
        if (Input.GetKeyUp("left"))
        {
            animator.SetBool("WallkLeft", false);
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
            audioSource.clip = pickUpSound;
            audioSource.Play();
        }
        if(col.gameObject.tag == "Doragon"){
            currentHP -= 1;
            hpImage.fillAmount = currentHP / maxHP;
        }
    }
}
