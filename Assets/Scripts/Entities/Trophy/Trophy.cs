using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Defender
{
    //public Transform starSpawnPoint;
    //public Star starPrefab;

    public void AddStars(int amount)
    {
        //var starInstance = Object.Instantiate(starPrefab, starSpawnPoint.position, Quaternion.identity);

        //Destroy(starInstance.gameObject, 1);

        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
