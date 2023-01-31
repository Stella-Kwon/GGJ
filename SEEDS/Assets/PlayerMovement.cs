using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float moveSpeed = 5f;

	public Rigidbody2D rb;
	public Camera cam;

	Vector2 movement;
	Vector2 mousePosition;
	
	// Update is called once per frame
	//getting the input for our movement, so this is we will trigger movement.
	void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		//in the game sight, because of the camer direction?? character movesleft when press right.
			//float.x = Input.GetAxis("Horizontal");
			// if (x > 0) transform.localScale = new Vector3(-1,1,1);
			// else if(x < 0) transform.localScale = new Vector3(1,1,1);
			// transform.Translate(new Vector3(x,0,0) * Time.deltaTime);
		//returns promptly right afer pressing key and the value retrun will be among -1,0,1. left -1 right 1/bottom-1 up 1
		//GetAxis("string name") returns a range of -1.0f to 1.0f. Basically, use when it needs smooth movement.
		movement.y = Input.GetAxisRaw("Vertical");
		//from pixel coordinates to world units
		mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
	}
	
	//actual moving implement on player based on this input. kinda now here is aiming.
	void FixedUpdate()
	{
		rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // 위치값+ 축값 *속도변수값* 실행간격시간
		//Time.fixedDeltaTime is a function that delivers the same movement output on the screen.
		/*so it rearranges the time so that the output can be the same in any computer quality 
		which would affect the changes in speed performance in each frame*/
		Vector2 lookDir = mousePosition - rb.position;
		// vector math ; subtract two vetors will give you get a vector that points from one to another
		//player to mouseclicked position	
		float angle = Mathf.Atan2(lookDir.y,lookDir.x) * Mathf.Rad2Deg - 90f;
		rb.rotation = angle;
		/*use function atan2 = returns the angle between the x-axis and a 2d vector starting at 0, 
		 terminating at X,Y Coordinates. 2개의 축*근데 4개로 나눠지잖아 에서 x축 중심으로 90 도마다 각도를 알려줌 
		 but in the function u need to write atan2(y,x) even the vector is at (X,Y)
		 Also Atan2 give the radian value so need to change it into degrees */
		//to rotate we need angle to move. not only the direction
		//so we will use functions in Mathf again. Mathf.Rad2Deg
		//and need to offset 90 in order to get the right direction. ; -90f or +90f

	}


}
