using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{    
    public bool isMoving = false;
    public bool isAttacking = false;
    public bool isReloading = false;
    public float speed = 1f;

    private float turnAngle;
    private Vector2 nextPosition;
    private Vector2 positionOnScreen;
    private Vector2 mouseOnScreen;
    private Vector3 nextRotation;
        
    private Rigidbody2D rigid;
    private Animator animatorController;

    [SerializeField]
    private WeaponsManager weaponsManager;

    private void Awake()
    {        
        nextPosition = Vector2.zero;
        nextRotation = Vector3.zero;
        rigid = GetComponent<Rigidbody2D>();
        animatorController = GetComponent<Animator>();
    }
    	
	void Update ()
    {
        SwitchWeapons();
        Move();
        Turn();
        UpdateAnimator();
	}
    
    private void FixedUpdate()
    {
        Attack();
    }

    private void SwitchWeapons()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            weaponsManager.SwitchWeapons(animatorController);
        }        
    }

    private void Attack()
    {
        if (!isAttacking)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                weaponsManager.StartAttack();
                isAttacking = true;
            }
        }
        else
        {
            weaponsManager.StopAttack();
            isAttacking = false;
        }
    }

    private void UpdateAnimator()
    {
        animatorController.SetBool("IsMoving", isMoving);
        animatorController.SetBool("IsAttacking", isAttacking);
        animatorController.SetBool("IsReloading", isReloading);
    }

    private void Move()
    {
        Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    
    private void Move(float directionX, float directionY)
    {
        nextPosition.Set(directionX, directionY);
        rigid.velocity = nextPosition * speed;
        isMoving = rigid.velocity != Vector2.zero ? true : false;
    }

    private void Turn()
    {
        positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
        mouseOnScreen = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        turnAngle = Mathf.Atan2(mouseOnScreen.y - positionOnScreen.y, mouseOnScreen.x - positionOnScreen.x) * Mathf.Rad2Deg;
        Turn(turnAngle);
    }

    private void Turn(float angle)
    {
        nextRotation.z = angle;
        transform.rotation = Quaternion.Euler(nextRotation);
    }
}
