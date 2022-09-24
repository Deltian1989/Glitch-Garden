using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] List<Attacker> attackers;
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1;
    [SerializeField] float maxSpawnDelay = 5;

    GameObject[] spawnPoints;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        while (spawn)
        {
            var seconds = Random.Range(minSpawnDelay, maxSpawnDelay);

            yield return new WaitForSeconds(seconds);

            SpawnAttacker();
        }
    }

    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttacker()
    {
        var i = Random.Range(0, 5);

        var i2 = Random.Range(0, 2);

        var attacker = attackers[i2]; 

        var attackerInstance = Instantiate(attacker, spawnPoints[i].transform.position, Quaternion.identity);

        attackerInstance.transform.parent = spawnPoints[i].transform;

        attackerInstance.transform.position += attacker.spawnOffset;

    }
}
