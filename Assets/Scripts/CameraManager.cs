using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform player;
    private Vector3 nextPosition;

	void Start ()
    {
        
	}
	
	
	void Update ()
    {
        nextPosition = transform.position;
        nextPosition.x = player.position.x;
        nextPosition.y = player.position.y;
        transform.position = nextPosition;
	}
}
