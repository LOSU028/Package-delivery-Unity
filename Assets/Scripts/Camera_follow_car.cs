using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_follow_car : MonoBehaviour
{
    [SerializeField] GameObject carToFollow;
    private int zOffSet = -10;
    //Here we want the camera to have the same changing position as our car, meaning that i want it to follow it 
    // Update is called once per frame
    void LateUpdate()
    {
        // we want to access our camera's position 
        /*i use LateUpdate so that Unity has no conflicts between moving the camera or the car first, 
            since we need to know where the car is first it makes only sense to move the camera slightly later*/
        transform.position = carToFollow.transform.position + new Vector3(0,0,zOffSet);
    }
}
