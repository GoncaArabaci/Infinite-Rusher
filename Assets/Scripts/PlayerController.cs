using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    float xPos = 0;
    public float xSpeed;
    public float xLimit;
    float rightPos = 2f;
    float leftPos = -2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.position += new Vector3(leftPos, 0f, 0f);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            transform.position += new Vector3(rightPos, 0f, 0f);
        }

        xPos = transform.position.x * xSpeed * Time.deltaTime;
        xPos = Mathf.Clamp(xPos, -xLimit, xLimit);

        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed *Time.deltaTime);
        transform.position = newPosition;
    }
}
