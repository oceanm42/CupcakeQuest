using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyPipes : MonoBehaviour {

    public int pipeIndex;
    public Transform[] pipeSpawns;
    private CameraFollow cameraFollow;

    private void Start()
    {
        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Cupcake")
        {
            if (Input.GetKey(KeyCode.S) && pipeIndex != 3 || Input.GetKey(KeyCode.D) && pipeIndex == 3)
            {
                if(pipeIndex == 1 || pipeIndex == 2)
                {
                    cameraFollow.inSubRoom = true;
                }
                else
                {
                    cameraFollow.inSubRoom = false;
                }
                Vector3 teleportTo = pipeSpawns[pipeIndex].position;
                collision.transform.position = teleportTo;
            }
        }
    }
}
