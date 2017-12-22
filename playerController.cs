using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

	static Animator anim;
	public float speed = 10.0F;
	public float rotationSpeed = 100.0F;
	public int counter = 1;
	public Text Message;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animator>();
		Message.text = "";
	}


	// Update is called once per frame
	void Update () {


		if (Input.GetButtonDown ("Jump") && counter == 0) {
			anim.SetBool ("push", true);
			counter += 1;
		} 
		else if (Input.GetButtonDown ("Jump") && counter == 1) {
			anim.SetBool ("push", false);
			counter = 0;
		}

		float translation = Input.GetAxis("Vertical") * speed;
		float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
		translation *= Time.deltaTime;
		rotation *= Time.deltaTime;
		transform.Translate(0, 0, translation);
		transform.Rotate(0, rotation, 0);
		if ((transform.localPosition.y) < -100) {
			Message.text = "from here to infinity";
			print ("dead");
		}

		if(translation != 0)
		{
			anim.SetBool("Walking",true);
		}
		else
		{
			anim.SetBool("Walking",false);
		}
	}

	void OnTriggerEnter(Collider other) {

		if (other.gameObject.CompareTag ("ball")) {
			print ("hit ball and hopefully push");
		}
	}
}
