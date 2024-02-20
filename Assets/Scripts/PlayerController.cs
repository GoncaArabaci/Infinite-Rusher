using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float xPos = 0;
    public float xLimit;
    float rightPos = 2f;
    float leftPos = -2f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(leftPos, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(rightPos, 0f, 0f);
        }

        xPos = Mathf.Clamp(xPos, -xLimit, xLimit);

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed *Time.deltaTime);
        transform.position = newPosition;
    }
}
