using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public PlayerAction inputAction;

	//Player Camera
	private Camera playerCamera;
	Vector3 cameraRotation;

	//Movement variables
	Vector2 move;
	Vector2 rotation;
	private float speed = 5f;

	//Jumping variables
	private Rigidbody rb;
	private float distanceToGround;
	public bool isGrounded = true;
	private float jumpForce = 8f;

	//Player Animations
	private Animator playerAnim;
	private bool isWalking = false;

	//Bullets
	public GameObject bullet;
	public Transform bulletPos;

	private void OnEnable()
	{
		inputAction.Player.Enable();
	}
	private void OnDisable()
	{
		inputAction.Player.Disable();
	}
	// Start is called before the first frame update
	void Awake()
	{
		if(!instance)
		{
			instance = this;
		}

		inputAction = new PlayerAction();
		inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
		inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

		inputAction.Player.Jump.performed += cntxt => Jump();

		inputAction.Player.Shoot.performed += cntxt => Shoot();

		rb = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
		playerCamera = GetComponentInChildren<Camera>();

		distanceToGround = GetComponent<Collider>().bounds.extents.y;
	}
	
	private void Jump()
	{
		if(isGrounded)
		{
			rb.velocity = new Vector2(rb.velocity.x, jumpForce);
			isGrounded = false;
		}
	}
	private void Shoot()
	{
		Rigidbody bulletRb = Instantiate(bullet, bulletPos.position ,Quaternion.identity).GetComponent<Rigidbody>();
		bulletRb.AddForce(transform.forward * 320f, ForceMode.Impulse);
		bulletRb.AddForce(transform.up, ForceMode.Impulse);
	}
	// Update is called once per frame
	void Update()
	{
		transform.Translate(Vector3.forward * move.y * Time.deltaTime * speed, Space.Self);
		transform.Translate(Vector3.right * move.x * Time.deltaTime * speed, Space.Self);

		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);
	}
}
