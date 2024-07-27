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

    // Start is called before the first frame update
    void Awake()
    {
        ResetEndPoint();
        //GetLastRoadSpawned.LastRoadSpawnedPos =
        //    roadSectionStart.GetComponent<Transform>().position;
        xToSpawn = roadSectionStart.GetComponent<Transform>().position.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.GetComponent<Transform>().position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART && spawned == false)
        {
            StartCoroutine(SpawnSection());
        }
    }

    IEnumerator SpawnSection()
    {
        spawnPosition = new Vector3(xToSpawn, yToSpawn, lastEndPosition.z);
        GameObject lastSection = Instantiate(partToSpawn, spawnPosition, Quaternion.identity);
        //lastSection.GetComponent<SpawnTraffic>().hasTraffic = false;

        //spawned = true;

        yield return null;
        //lastSectionTransform.GetComponent<LevelDestroy>().destroyable = true;
        lastEndPosition = lastSection.GetComponent<Transform>().Find("TheEndPoint").position;

        //spawned = false;
        yield return new WaitForSeconds(1f);

    }

    public void ResetEndPoint()
    {
        lastEndPosition = roadSectionStart.GetComponent<Transform>().Find("TheEndPoint").position;
    }
}
