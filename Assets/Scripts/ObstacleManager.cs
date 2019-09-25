using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnFrequency = 2.0f;
    float spawnTimer;
    int numSpawned;

    void Start()
    {

    }

    void CreateObstacle()
    {
        bool isTop = System.Convert.ToBoolean(Random.Range(0, 2)); //I'm calling this line Exhibit A in my series of Fuck C#; C++ is better
        GameObject obj = Object.Instantiate(obstaclePrefab, transform);
        obj.GetComponent<CircleCollider2D>().offset = new Vector2(0.0f, 0.0f);
        if(isTop == false)
        {
            obj.transform.position = new Vector3(10.5f, -2.8f, -1.5f);
        }
        else
        {
            obj.transform.position = new Vector3(10.5f, -1.85f, -1.5f);
            BoxCollider2D jumpOverCheck = obj.AddComponent<BoxCollider2D>();
            jumpOverCheck.isTrigger = true;
            jumpOverCheck.offset = new Vector2(0.5f, 0.7f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
        }
        if(numSpawned >= 10)
        {
            if(spawnFrequency >= .5f)
            {
                spawnFrequency -= .1f;
                numSpawned = 0;
            }
        }

        //Spawn Shit
        if(spawnTimer <= spawnFrequency)
        {
            spawnTimer += Time.deltaTime;
        }
        else
        {
            CreateObstacle();
            numSpawned++;
            spawnTimer -= spawnFrequency;
        }
    }
}