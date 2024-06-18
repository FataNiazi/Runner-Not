using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float[] xPositionList = { 2.5f, 7.5f, 11.25f, 15f, 20f };
    [SerializeField]
    private int xPositionIndexInput = 0;
    [SerializeField]
    private float playerSpeed;
    private Vector3 targetPos;
    private Vector3 velocity = Vector3.zero;
    private bool isMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position += new Vector3(0f, 0f, Time.deltaTime * playerSpeed);

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (xPositionIndexInput > 0)
            {
                --xPositionIndexInput;
                isMoving = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (xPositionIndexInput < 4)
            {
                ++xPositionIndexInput;
                isMoving = true;
            }
        }

        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    _animator.ResetTrigger(JUMP);
        //    _animator.SetTrigger(JUMP);
        //}

        if (isMoving) {

            targetPos = new Vector3(xPositionList[xPositionIndexInput], transform.position.y, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 15 * Time.deltaTime);
        }

        if ((xPositionList[xPositionIndexInput] - 0.01f < transform.position.x) &&
            (transform.position.x  < xPositionList[xPositionIndexInput] + 0.01f))
        {
            transform.position = new Vector3(xPositionList[xPositionIndexInput], transform.position.y, transform.position.z);
            isMoving = false;
        }

        //if (transform.position.y > -3.21)
        //{
        //    transform.position = new Vector3(transform.position.x, -3.2f, transform.position.z);
        //}
    }
}
