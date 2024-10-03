using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyRoadPart : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Transform closestEndPoint;
    private float endPointZ;
    private float playerZ;

    // Start is called before the first frame update
    void Start()
    {
        closestEndPoint = gameObject.transform.Find("TheEndPoint");
        endPointZ = closestEndPoint.GetComponent<Transform>().position.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < -50)
        {
            Destroy(gameObject);
        }
    }
}
