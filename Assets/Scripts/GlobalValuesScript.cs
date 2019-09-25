using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlobalValuesScript : MonoBehaviour
{
    public Text disText;
    public static Text scoreText;
    public static int score = 0;
    public static float gameSpeedModifier = 1.0f;
    public static float timeSinceLastSpeedUp = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        scoreText = disText;
    }

    // Update is called once per frame
    void Update()
    {
        float targetTimeSinceLastSpeeedUp = 10.0f;
        if (timeSinceLastSpeedUp <= targetTimeSinceLastSpeeedUp)
        {
            timeSinceLastSpeedUp += Time.deltaTime;
        }
        else
        {
            gameSpeedModifier += .25f;
            timeSinceLastSpeedUp -= targetTimeSinceLastSpeeedUp;
        }
        scoreText.text = "Score: " + score;
    }
}
