using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManagerScript : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && (GameObject.FindGameObjectWithTag("Player") == null))
        {
            Time.timeScale = 1;
            GlobalValuesScript.gameSpeedModifier = 1.0f;
            GameObject.Instantiate(Player);
            Player.GetComponent<Animator>().SetBool("dead", false);
            GlobalValuesScript.scoreText.enabled = true;
            GameObject.Find("Heart 1").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Heart 2").GetComponent<SpriteRenderer>().enabled = true;
            GameObject.Find("Heart 3").GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
