using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpTrigger : MonoBehaviour
{

    private Animator jumpAnimator;
    private bool animating;

    // Start is called before the first frame update
    void Start()
    {
        jumpAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInputController.MoveJump)
        {
            jumpAnimator.SetTrigger("JumpTrigger");
        }
    }
}
