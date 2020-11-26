using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	


	public float speed = 6f;

	private Vector3 movement;
	private Animator anim;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float camRayLength = 100f;

	public float h;
	public float v;
	public float r;

	[SerializeField]
	public int playerIndex;
	
	public ParticleSystem dust;

	void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (playerIndex == 0)
		{
			h = Input.GetAxisRaw("Horizontal0");
			v = Input.GetAxisRaw("Vertical0");
			r = Input.GetAxisRaw("Rotation0");
		}
		else 
		{
			h = Input.GetAxisRaw("Horizontal1");
			v = Input.GetAxisRaw("Vertical1");
			
		}
		Move(h, v);
		Turning(r,playerIndex);
		Animating(h, v);
	}

	void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		
		playerRigidbody.MovePosition(transform.position + movement);
		
	}

	public string getIndex()
	{
		return playerIndex.ToString();
	}





	void Turning(float r, int i)
	{
		if (playerIndex == 1)
		{

			Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit floorHit;
			if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask)) {
				Vector3 playerToMouse = floorHit.point - transform.position;
				playerToMouse.y = 0f;

				Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
				playerRigidbody.MoveRotation(newRotation);

			}
		}
		else
		{
			playerRigidbody.transform.Rotate(Vector3.up * speed * -r);
		}
			

	}

	void Animating(float h, float v)
	{
		bool walking = h != 0f || v != 0f;

		anim.SetBool("IsWalking", walking);
		if(walking)
		{
			createDust();
		}
	}


	void createDust()
	{
		dust.Play();
	}



}
