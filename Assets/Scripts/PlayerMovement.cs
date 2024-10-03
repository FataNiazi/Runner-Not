using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private static float[] xPositionList = { 2.5f, 7.5f, 11.25f, 15f, 20f };
    public static float[] XPositionsList { get { return xPositionList; } }

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

        if (PlayerInputController.MoveLeft)
        {
            if (xPositionIndexInput > 0)
            {
                --xPositionIndexInput;
                isMoving = true;
            }
        }
    
        if (PlayerInputController.MoveRight)
        {
            if (xPositionIndexInput < 4)
            {
                ++xPositionIndexInput;
                isMoving = true;
            }
        }


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
