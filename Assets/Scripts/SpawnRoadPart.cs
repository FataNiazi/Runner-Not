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
    private Vector3 spawnPosition;
    private bool spawned;

    // Start is called before the first frame update
    void Awake()
    {
        ResetEndPoint();
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
        spawnPosition = new Vector3(roadSectionStart.GetComponent<Transform>().position.x, roadSectionStart.GetComponent<Transform>().position.y, lastEndPosition.z);
        GameObject lastSectionTransform = Instantiate(partToSpawn, spawnPosition, Quaternion.identity);
        //spawned = true;
        yield return null;
        //lastSectionTransform.GetComponent<LevelDestroy>().destroyable = true;
        lastEndPosition = lastSectionTransform.GetComponent<Transform>().Find("TheEndPoint").position;
        //spawned = false;
        yield return new WaitForSeconds(1f);

    }

    public void ResetEndPoint()
    {
        lastEndPosition = roadSectionStart.GetComponent<Transform>().Find("TheEndPoint").position;
    }
}
