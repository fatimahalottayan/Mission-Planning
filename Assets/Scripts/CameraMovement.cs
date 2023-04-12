using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector2 turn;
    int horizontal;
    int vertical;

 
    void Update()
    {
        MoveCamera();
    }

    private void MoveCamera()
    {
        horizontal = Mathf.RoundToInt(Input.GetAxis("Horizontal"));
        vertical = Mathf.RoundToInt(Input.GetAxis("Vertical"));

        transform.Translate(Vector3.right * horizontal * 50f * Time.deltaTime);

        transform.Translate(Vector3.up * vertical * 50f * Time.deltaTime);

        transform.Translate(Vector3.forward * Input.mouseScrollDelta.y * 10f);


        if (Input.GetMouseButton(1))
        {
            turn.y += Input.GetAxis("Mouse Y");
            turn.x += Input.GetAxis("Mouse X");
            transform.localRotation = Quaternion.Euler(-turn.y, turn.x, 0);
        }
        CheckPosition();

    }

  
    private void CheckPosition()
    {
        if (transform.position.y < 105)
        {
            transform.position = new Vector3(transform.position.x, 105, transform.position.z);
        }
        if (transform.position.y > 400)
        {
            transform.position = new Vector3(transform.position.x, 400, transform.position.z);
        }

        if (transform.position.x > 1100)
        {
            transform.position = new Vector3(1100, transform.position.y, transform.position.z);

        }

        if (transform.position.x < 200)
        {
            transform.position = new Vector3(200, transform.position.y, transform.position.z);

        }

        if (transform.position.z < -90)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -90);

        }

        if (transform.position.z > 900)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 900);

        }
    }

}

