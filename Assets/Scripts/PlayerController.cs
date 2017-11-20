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
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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

    private void Move(float directionX, float directionY)
    {
        nextPosition.Set(directionX, directionY);
        nextRotation.Set(directionX, directionY, 0f);
        rigid.velocity = nextPosition * speed;
        if (nextPosition != Vector2.zero)
        {
            float angle = Mathf.Atan2(nextPosition.y, nextPosition.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
      //  transform.position = transform.position + speed * new Vector3(nextPosition.x, nextPosition.y, 0);
    }
}
