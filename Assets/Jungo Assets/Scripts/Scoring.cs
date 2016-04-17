using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

    public Text scoreText;
    private int score = 0;

    private float start = 0;

    private Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
        start = playerTransform.position.x;
    }

    // Use this for initialization
    void Start ()
    {
        scoreText.text = "Score: " + score;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Find where the player is and calculate score
        playerTransform = GameObject.Find("Player").transform;
        score = (int) (playerTransform.position.x - start);

        scoreText.text = "Score: " + score;
    }
}
