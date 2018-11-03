using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

    [SerializeField] private float secondsBetweenRowSpawns = 4f;
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private int numBlocksPerRow = 9;
    [SerializeField] private int maxNumBlocksToRemove = 3;

    private bool enableWaveSpawn = true;

    private IEnumerator Start() {
        // start spawing waves until we're told to stop
        do {
            yield return StartCoroutine(SpawnRow());
        }
        while (enableWaveSpawn);
    }


    IEnumerator SpawnRow() {
        Vector3 spawnLocationVector = transform.position;

        List<GameObject> blocks = new List<GameObject>();

        for (int i = 0; i < numBlocksPerRow; i++) {
            var instance = Instantiate(blockPrefab, spawnLocationVector, Quaternion.identity) as GameObject;
            blocks.Add(instance);
            spawnLocationVector = new Vector3(spawnLocationVector.x + 1, spawnLocationVector.y, spawnLocationVector.z);
        }

        // Destroy between 1 and 3 blocks so the player can fall down
        int numBlocksToRemove = Random.Range(1, maxNumBlocksToRemove);
        for (int i = 0; i < numBlocksToRemove; i++) {
            // pick a random index and destroy it
            int indexToDestroy = Random.Range(0, blocks.Count - 1);
            Destroy(blocks[indexToDestroy]);
            blocks.Remove(blocks[indexToDestroy]);
        }

        yield return new WaitForSeconds(secondsBetweenRowSpawns);
    }

}
