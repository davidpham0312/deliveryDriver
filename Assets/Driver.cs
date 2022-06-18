using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float turnSpeed = 1;
    [SerializeField] float moveSpeed = 0.08f;
    [SerializeField] float slowSpeed = 3;
    [SerializeField] float fastSpeed = 8;

    private void OnCollisionEnter2D(Collision2D other){
            moveSpeed = slowSpeed;
        

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "SpeedUp") {
            Debug.Log("Should speed up");
            moveSpeed = fastSpeed;
        }
    }
    // Update is called once per frame
    void Update()
    {
        float turnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -turnAmount);
        transform.Translate(0,moveAmount,0);
    }
}
