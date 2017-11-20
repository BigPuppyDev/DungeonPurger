using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1f;
    
    private Vector2 nextPosition;
    private Vector3 nextRotation;
    public bool isMoving = false;
    public bool isAttacking = false;
    private float turnAngle;
    private Rigidbody2D rigid;
    private Animator animatorController;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        nextPosition = Vector2.zero;
        animatorController = GetComponent<Animator>();
    }
    	
	void Update ()
    {   
        Move();
        Turn();
        Attack();
        UpdateAnimator();
	}

    private void Attack()
    {
        if (Input.GetKey(KeyCode.Mouse0) || Input.GetKeyUp(KeyCode.Mouse0) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
    }

    private void UpdateAnimator()
    {
        animatorController.SetBool("IsMoving", isMoving);
        animatorController.SetBool("IsAttacking", isAttacking);
    }

    private void Move()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    private void Turn()
    {
        //turnAngle = Mathf.Atan2(mouseOnScreen.y, mouseOnScreen.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(turnAngle, Vector3.forward);
        Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);

        //Get the Screen position of the mouse
        Vector2 mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        //Get the angle between the points
        float angle = AngleBetweenTwoPoints( mouseOnScreen, positionOnScreen);

        //Ta Daaa
        transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
    }

    private void Move(float directionX, float directionY)
    {
        nextPosition.Set(directionX, directionY);
        rigid.velocity = nextPosition * speed;
        isMoving = rigid.velocity != Vector2.zero ? true : false;
    }

    private float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
