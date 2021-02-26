﻿using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour 
{
	public float upForce;                   //Upward force of the "flap".
	public float maxHeight = 2f;
	private bool isDead = false;			//Has the player collided with a wall?

	private Animator anim;					//Reference to the Animator component.
	private Rigidbody2D rb2d;               //Holds a reference to the Rigidbody2D component of the bird.
	public AudioSource source;
	public AudioClip Flap;

	void Start()
	{
		//Get reference to the Animator component attached to this GameObject.
		anim = GetComponent<Animator> ();
		//Get and store a reference to the Rigidbody2D attached to this GameObject.
		rb2d = GetComponent<Rigidbody2D>();
		//Get the audioSource from the scene
		source = GameObject.FindGameObjectWithTag("AudioSource").GetComponent<AudioSource>();

		rb2d.isKinematic = true;
	}

	void Update()
	{
		//Don't allow control if the bird has died.
		if (isDead == false && gameObject.transform.position.y <= maxHeight) 
		{
			//Look for input to trigger a "flap".
			if (Input.GetMouseButtonDown(0) && GameControl.instance.scrollStarted) 
			{
				//...tell the animator about it and then...
				anim.SetTrigger("Flap");
				source.PlayOneShot(Flap);
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//	new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}else if (Input.GetMouseButtonDown(0) && !GameControl.instance.scrollStarted)
			{
				rb2d.isKinematic = false;
				GameControl.instance.StartScroll();

				anim.SetTrigger("Flap");
				source.PlayOneShot(Flap);
				//...zero out the birds current y velocity before...
				rb2d.velocity = Vector2.zero;
				//	new Vector2(rb2d.velocity.x, 0);
				//..giving the bird some upward force.
				rb2d.AddForce(new Vector2(0, upForce));
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Zero out the bird's velocity
		rb2d.velocity = Vector2.zero;
		// If the bird collides with something set it to dead...
		isDead = true;
		//...tell the Animator about it...
		anim.SetTrigger ("Die");
		//...and tell the game control about it.
		GameControl.instance.BirdDied ();
	}
}
