using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoadPart : MonoBehaviour
{
    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 90;

    [SerializeField] private GameObject roadSectionStart;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject partToSpawn;

    private Vector3 lastEndPosition;
    private bool spawned;
    private float xToSpawn;
    private float yToSpawn;


    //Last end position and its getter method
    private Vector3 spawnPosition;
    public object LastSpawnedRoadPart { get { return lastEndPosition; }}

    private void Start()
    {
        xToSpawn = roadSectionStart.GetComponent<Transform>().position.x;
        yToSpawn = roadSectionStart.GetComponent<Transform>().position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * -15);

        if (spawned == false && transform.position.z < -10)
        {
            spawnPosition = new Vector3(xToSpawn, yToSpawn, 35);
            GameObject lastSection = Instantiate(partToSpawn, spawnPosition, Quaternion.identity);

            lastEndPosition = lastSection.GetComponent<Transform>().Find("TheEndPoint").position;

            spawned = true;
        }
    }

    public void ResetEndPoint()
    {
        lastEndPosition = this.GetComponent<Transform>().Find("TheEndPoint").position;
    }

}
