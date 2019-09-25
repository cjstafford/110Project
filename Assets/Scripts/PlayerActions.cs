using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerActions : MonoBehaviour
{
    public GameObject obstacleManager;
    public bool canJump = true;
    public float force = 4.0f;
    public int health = 3;
    bool scored = false;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateScore", 1.0f, 1.0f);
    }

    void UpdateScore()
    {
        GlobalValuesScript.score++;
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 3 && GameObject.Find("Heart 3") != null)
        {
            GameObject.Find("Heart 3").GetComponent<SpriteRenderer>().enabled = false;
        }
        if(health < 2 && GameObject.Find("Heart 2") != null)
        {
            GameObject.Find("Heart 2").GetComponent<SpriteRenderer>().enabled = false;
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.J)) && canJump)
        {
            canJump = false;
            gameObject.GetComponent<Animator>().SetBool("jump", true);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, force), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //The boy ducks (makes himself smaller)
            transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
        }
        else
        {
            transform.localScale = Vector3.one;
        }

        if (gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("PostDeath"))
        {
            Object.Destroy(gameObject);
            Time.timeScale = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            canJump = true;
            gameObject.GetComponent<Animator>().SetBool("jump", false);
            scored = false;
            GlobalValuesScript.scoreText.color = Color.black;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the player collides with the enemy's circle collider (lined up with the enemy)
        if (collision.gameObject.tag == "Enemy" && collision is CircleCollider2D && scored == false && !(collision is BoxCollider2D))
        {
            health--;
            Object.Destroy(collision.gameObject);
            if (health <= 0)
            {
                gameObject.GetComponent<Animator>().SetBool("dead", true);
               
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Enemy"))
                {
                    Object.Destroy(obj);
                }
                GameObject.Find("Heart 1").GetComponent<SpriteRenderer>().enabled = false;
                GlobalValuesScript.scoreText.enabled = false;
                GlobalValuesScript.score = 0;
                GlobalValuesScript.gameSpeedModifier = 0;
                GlobalValuesScript.timeSinceLastSpeedUp = 0;
            }
        }
        //If the player jumps over the enemy and collides with the BoxCollider hovering over its head
        else if (collision.gameObject.tag == "Enemy" && collision is BoxCollider2D && !(collision is CircleCollider2D))
        {
            scored = true;
            GlobalValuesScript.score += 100;
            GlobalValuesScript.scoreText.color = Color.green;
        }
    }
}
