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
        MoveLeft();
        MoveRight();
        MoveUp();
        MoveDown();
        xPos = Mathf.Clamp(xPos, -xLimit, xLimit);
        Vector3 newPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + runningSpeed *Time.deltaTime);
        transform.position = newPosition;
    }
    void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(leftPos, 0f, 0f);
        }
 
    }
    void MoveRight() {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(rightPos, 0f, 0f);
        }
    }
    void MoveUp()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            transform.position += new Vector3(0f, 2f, 0f);
        }
    }
    void MoveDown()
    {
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0f, -2f, 0f);
        }
    
    }

}
