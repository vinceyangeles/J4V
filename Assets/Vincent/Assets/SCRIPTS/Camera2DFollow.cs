using UnityEngine;
using System.Collections;

public class Camera2DFollow : MonoBehaviour {
	
    //Player
	public Transform player;

    //Speed in which the camera follows the Player
	public float followSpeed;

    //The amount of vision/space is shown in front of the player
	public float lookForwardSpace;

    //The speed in which it returns to the center of the player
	public float lookForwardSpeed;

    //Camera Offset X axis
	public float xPositionCameraOffset;

    //Camera Offset Y axis
	public float yPositionCameraOffset;
	
	float offsetZ;

	Vector3 targetPosition;
	Vector3 currentVelocity;
	Vector3 lookForwardPosition;

	float nextTimeToSearch = 0;
	
	void Start () {
		targetPosition = player.position;
		offsetZ = (transform.position - player.position).z;
		transform.parent = null;
	}
	
	void Update () {

		if (player == null) {
			return;
		}

		float xMovement = (player.position - targetPosition).x;

	    bool updateLookAheadTarget = Mathf.Abs(xMovement) > xPositionCameraOffset;

		if (updateLookAheadTarget) {
			lookForwardPosition = lookForwardSpace * Vector3.right * Mathf.Sign(xMovement);
		} else {
			lookForwardPosition = Vector3.MoveTowards(lookForwardPosition, Vector3.zero, Time.deltaTime * lookForwardSpeed);	
		}
		
		Vector3 aheadTargetPos = player.position + lookForwardPosition + Vector3.forward * offsetZ;
		Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, followSpeed);

		newPos = new Vector3 (newPos.x, Mathf.Clamp (newPos.y, yPositionCameraOffset, Mathf.Infinity), newPos.z);

		transform.position = newPos;
		
		targetPosition = player.position;		
	}

}
