using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private Rigidbody rgb;
    private float speed;
    public float MovingSpeed;
    public float SprintSpeed;
    public float JumpForce;
    public LayerMask ground;
    public Transform grounddetect;
    void Start()
    {
        rgb = GetComponent<Rigidbody>();

    }



    void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical);
        bool sprint = Input.GetKey(KeyCode.RightShift)|| Input.GetKey(KeyCode.LeftShift);
        speed = MovingSpeed;
        bool jump = Input.GetKey(KeyCode.Space);
        if(sprint &&!jump){
            speed = SprintSpeed;
        }
        Vector3 target_vel = transform.TransformDirection(direction) * speed * Time.deltaTime;
        target_vel.y = rgb.velocity.y;
        rgb.velocity = target_vel;
    }
    void Jump(){
        bool jump = Input.GetKey(KeyCode.Space);
        bool isGrounded = Physics.Raycast(grounddetect.position, Vector3.down, 1f, ground);
        if(jump && isGrounded){
            rgb.AddForce(Vector3.up * JumpForce);
        }
    }
}
