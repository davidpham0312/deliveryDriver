using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject thingToFollow;
    // Camera follows the car

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetMouseButton(0)){

            transform.position = thingToFollow.transform.position + new Vector3(0,0,-5);
            transform.rotation = thingToFollow.transform.rotation;
        }
        else {
            transform.position = new Vector3(2.97f, -5.67f, -14);
        }
    }
}
