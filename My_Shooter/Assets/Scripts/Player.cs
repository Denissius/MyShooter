using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Joystick joystickLeft;
    public ControlType controlType;

    public enum ControlType {PC, Android};
    public bool faceRight = true;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        if(controlType == ControlType.PC) 
        {
            joystickLeft.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        PlayerControls();
        Reflect();
    }

    void PlayerControls() 
    {
        if(controlType == ControlType.PC) 
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else if(controlType == ControlType.Android) 
        {
            moveInput = new Vector2(joystickLeft.Horizontal, joystickLeft.Vertical);
        }
        moveVelocity = moveInput.normalized * speed;
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);

        if (moveInput.x == 0) 
        {
            anim.SetBool("IsRunning", false);
        }
        else 
        {
            anim.SetBool("IsRunning", true);
        }
    }

    void Reflect() 
    {
        if ((moveInput.x > 0 && !faceRight) || (moveInput.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight =!faceRight;
        }
    }
}
