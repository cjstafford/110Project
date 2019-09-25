using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float m_speed = -5f;
    public GameObject otherBackground;
    public int m_bg1Percent = 25;
    public int m_bg2Percent = 25;
    public int m_bg3Percent = 25;
    public int m_bg4Percent = 25;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            otherBackground.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            otherBackground.GetComponent<SpriteRenderer>().enabled = true;
        }
        //transform.position += Vector3.right * m_speed * Time.deltaTime * GlobalValuesScript.gameSpeedModifier;
        transform.position += new Vector3(m_speed * Time.deltaTime * GlobalValuesScript.gameSpeedModifier, 0, 0);
    }
    private void LateUpdate()
    {
        if (transform.position.x <= -20)
        {
            ChangeBackgroundArt();
            float otherHalfWidth = otherBackground.GetComponent<SpriteRenderer>().bounds.extents.x;
            float myHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
            float xPos = otherBackground.transform.position.x + otherHalfWidth + myHalfWidth;
            xPos -= 0.25f;
            transform.position = new Vector3(xPos, otherBackground.transform.position.y, 6);
        }
    }

    void ChangeBackgroundArt()
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum < m_bg1Percent)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Winter");
        }
        else if (randomNum < m_bg1Percent + m_bg2Percent)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fall");
        }
        else if (randomNum < m_bg1Percent + m_bg2Percent + m_bg3Percent)
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Fall");
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Winter");
        }
    }
}