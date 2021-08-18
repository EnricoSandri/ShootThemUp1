using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectSpawner : MonoBehaviour
{

    [Header("Items Spawner List")]
    public List<GameObject> itemsToSpawn = new List<GameObject>();
    public float timeBetweenSpawns;
    Player player;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(ObjectSpawner());
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    IEnumerator ObjectSpawner()
    { 
        for (int j = 0; j < 100000000; j++)
        {
            for (int i = 0; i < itemsToSpawn.Count; i++)
            {
                Vector3 randomPos = new Vector3(Random.Range(player.xMin, player.xMax), player.yMax +12);//Random.Range(player.yMin + 20 , player.yMax), 0);///did so the asteroids will spawn only from top
                GameObject spawnedItem = Instantiate(itemsToSpawn[i], randomPos, Quaternion.identity);
                
                Destroy(spawnedItem, 60f);
                yield return new WaitForSeconds(timeBetweenSpawns);
            }

        }

    }
}
