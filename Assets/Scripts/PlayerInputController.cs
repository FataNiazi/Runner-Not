using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputController : MonoBehaviour
{
    private static bool moveLeft = false;
    private static bool moveRight = false;

    public static bool MoveLeft { get { return moveLeft; } set {} }
    public static bool MoveRight { get { return moveRight; } set { } }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            moveLeft = true;
        }
        else
        {
            moveLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            moveRight = true;
        }
        else
        {
            moveRight = false;
        }

    }
}
