using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public Transform subRoom;
    public float mapWidthMin;
    public float mapWidthMax;
    public bool inSubRoom;
    public float cameraHeight;

    private void Update()
    {
        if(target.position.x > mapWidthMin && target.position.x < mapWidthMax && inSubRoom == false)
        {
            transform.position = new Vector3(target.position.x, cameraHeight, transform.position.z);
        }
        else if(inSubRoom == true)
        {
            transform.position = subRoom.position;
        }
    }
}
