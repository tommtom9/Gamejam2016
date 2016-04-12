using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour 
{

	public float playerSpeed = 10f;
	public float maxJumpTimeOut = 2f;
	public float playerJumpForce;
	private float moveX = 5f;
	private float jumpTimeOut = 0.0f;
	private bool playerCanJump;
	private bool playerOnGround;
	private Rigidbody2D _rigid;


	// Use this for initialization
	void Start ()
	{
		//Get RigidBody Element & Zet TimeOut op Max
		_rigid = GetComponent<Rigidbody2D> ();
		jumpTimeOut = maxJumpTimeOut;
	}
	// Update is called once per frame
	void Update() {
		//Decrease Player Jump TimeOut
		if (!playerCanJump)
		{
			jumpTimeOut -= Time.deltaTime;

		}
		//Als de Player Jump TimeOut 0 is
		if (jumpTimeOut <= 0)
		{
			playerCanJump = true;
			jumpTimeOut = maxJumpTimeOut;
		}
	}

	void FixedUpdate ()
	{
		//Horizontal beweging Speler
		//Geef Speler Velocity
		moveX = Input.GetAxis ("Horizontal");
		_rigid.velocity = new Vector2 (moveX * playerSpeed, _rigid.velocity.y);

		//Jump

		Vector2 playerFacingX = _rigid.velocity.normalized;
		//Als W ingedrukt & Speler KAN springen
		if (Input.GetButton ("Fire1") && playerCanJump && playerOnGround)
		{
			//Schop de speler omhoog, Kan Niet nogmaals springen & TimeOut op Max & Not on Ground
			//_rigid.AddForce (new Vector2 (_rigid.velocity.x, playerJumpForce * playerSpeed));
			_rigid.AddForce(10.0f * playerFacingX + new Vector2 (0,20), ForceMode2D.Impulse);
			playerCanJump = false;
			playerOnGround = false;
			jumpTimeOut = maxJumpTimeOut;
		}
	}
	void OnTriggerEnter2D (Collider2D other)
	{
		if (other.gameObject.tag == "Ground") 
		{
			playerOnGround = true;
		}
	}
}