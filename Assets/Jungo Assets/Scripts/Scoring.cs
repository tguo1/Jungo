using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

    public Text scoreText;
    private static int score = 0;

    private float start = 0;

    private Transform playerTransform;

    private bool PlayerExist = false;

    void Awake()
    {
        PlayerExist = (GameObject.FindGameObjectWithTag("Player") != null);
        if (PlayerExist)
        {
            playerTransform = GameObject.Find("Player").transform;
            start = playerTransform.position.x;
        }
    }

    // Use this for initialization
    void Start ()
    {
        if (PlayerExist)
            scoreText.text = "Score: " + score;
        else
            scoreText.text = "" + score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Find where the player is and calculate score
        if (PlayerExist)
        {
            playerTransform = GameObject.Find("Player").transform;
            score = (int)(playerTransform.position.x - start);
            scoreText.text = "Score: " + score;
        }
    }
}
