using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
	public static PlayerController instance;

	public PlayerAction inputAction;

	public int health = 3;
	public Text healthText;
	public Text scoreText;

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

	// Start is called before the first frame update
	void Start()
	{
		if(!instance)
		{
			instance = this;
		}

		inputAction = PlayerInputController.controller.inputAction;

		inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
		inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

		inputAction.Player.Look.performed += cntxt => rotation = cntxt.ReadValue<Vector2>();
		inputAction.Player.Look.canceled += cntxt => rotation = Vector2.zero;

		inputAction.Player.Jump.performed += cntxt => Jump();

		inputAction.Player.Shoot.performed += cntxt => Shoot();

		rb = GetComponent<Rigidbody>();
		playerAnim = GetComponent<Animator>();
		playerCamera = GetComponentInChildren<Camera>();

		distanceToGround = GetComponent<Collider>().bounds.extents.y;
		cameraRotation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z);
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
		if (EditorManager.instance.editorMode == false)
		{
			//Rigidbody bulletRb = Instantiate(bullet, bulletPos.position, Quaternion.identity).GetComponent<Rigidbody>();
			Rigidbody bulletRb = ObjectPooler.instance.SpawnFromPool("Bullet", bulletPos.position, Quaternion.identity).GetComponent<Rigidbody>();
			bulletRb.AddForce(transform.forward * 320f, ForceMode.Impulse);
			bulletRb.AddForce(transform.up, ForceMode.Impulse);
		}
	}
	// Update is called once per frame
	void Update()
	{
		cameraRotation = new Vector3(cameraRotation.x + rotation.y, cameraRotation.y + rotation.x, cameraRotation.z);

		if (EditorManager.instance.editorMode == false)
		{
			playerCamera.transform.rotation = Quaternion.Euler(cameraRotation);
			transform.eulerAngles = new Vector3(transform.rotation.x, cameraRotation.y, transform.rotation.z);
		}

		transform.Translate(Vector3.forward * move.y * Time.deltaTime * speed, Space.Self);
		transform.Translate(Vector3.right * move.x * Time.deltaTime * speed, Space.Self);

		isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToGround);

		Vector3 m = new Vector3(move.x, 0, move.y);
		AnimateRun(m);

		healthText.text = health.ToString();
		scoreText.text = ScoreManager.instance.score.ToString();

		if (health <= 0)
			Destroy(gameObject);
	}
	void AnimateRun(Vector3 m)
	{
		isWalking = (m.x > 0.1f || m.x < -0.1f) || (m.z > 0.1f || m.z < -0.1f) ? true : false;
		playerAnim.SetBool("isWalking", isWalking);
	}
}
