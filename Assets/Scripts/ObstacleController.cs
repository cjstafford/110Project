using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleController : MonoBehaviour
{
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y == -1.85f)
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed * 1.5f * GlobalValuesScript.gameSpeedModifier;
        }
        else
        {
            gameObject.transform.position += Vector3.left * Time.deltaTime * speed * GlobalValuesScript.gameSpeedModifier;
        }
        if (gameObject.transform.position.x <= -10f)
        {
            Object.Destroy(gameObject);
        }
    }
}
