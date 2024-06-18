using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float zOffset;
    private float xVal;
    private float yVal;
    // Start is called before the first frame update
    void Start()
    {
        xVal = transform.position.x;
        yVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(xVal, yVal, player.position.z + zOffset);
    }
}
