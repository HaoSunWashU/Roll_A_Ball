using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	private Rigidbody rb;
	public Text countText;
	public Text winText;
	public float speed;
	private int count;
	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetCountText ();
		winText.text = "";
	}
		
	//update and fixedUpdate change the object each frame
	//update() is called before rendering a frame
	void Update()
	{

	}

	//FixedUpdate() is called just before performing any physics caluculations
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		//access other components in this object
		rb.AddForce(movement * speed);
	}

	void OnTriggerEnter(Collider other) 
	{
//		Destroy(other.gameObject);
//		if (other.gameObject.CompareTag("Player"))
//		gameObject.SetActive(false);
		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
		}

	}

	void SetCountText()
	{	
		countText.text = "Count: " + count.ToString();
		if (count >= 13)
		{
			winText.text = "You WIN !!!";
		}
	}

}
