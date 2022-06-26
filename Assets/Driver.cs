using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{

    public FixedJoystick Joystick;
    Vector2 move;
    Rigidbody2D rb;
    [SerializeField] float turnSpeed = 1;
    [SerializeField] float moveSpeed;
    [SerializeField] float slowSpeed = 3;
    [SerializeField] float fastSpeed = 8;

    public static bool PointerDown = false;
    private void OnCollisionEnter2D(Collision2D other){
            moveSpeed = slowSpeed;

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp") {
            Debug.Log("Should speed up");
            moveSpeed = fastSpeed;
        }
    }

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0,moveAmount,0);

        move.x = Joystick.Horizontal;
        move.y = Joystick.Vertical;

        float hor = move.x;
        float ver = move.y;
        float zAxis = Mathf.Atan2(hor,ver) * Mathf.Rad2Deg;
        if (Input.GetMouseButton(0)){

            transform.eulerAngles = new Vector3(0f,0f,-zAxis);
        }
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0,moveAmount,0);
    }

    private void FixedUpdate() {
        if (PointerDown){
            rb.velocity = Vector3.zero;
        }
        else{
            rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);    
        }
    }
}
