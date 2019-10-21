using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow2DPlatformer : MonoBehaviour
{

    //what the camera follows
    public Transform target;

    //dampens how quickly the camera starts/eases following
    public float smoothing;

    //distance between character and camera
    Vector3 offset;

    //lowest point that our camera can go
    float lowY;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - target.position;

        lowY = transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //where camera wants to be located
        Vector3 targetCamPos = target.position + offset;

        //lerp allows for smooth motion
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing*Time.deltaTime);//deltatime is difference in time since last frame

        if(transform.position.y < lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
