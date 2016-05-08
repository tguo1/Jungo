using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scoring : MonoBehaviour {

    public Text[] scoreText;
    private static int[] highscores = { 0, 0, 0, 0, 0 }; 

    private float start = 0;

    private Transform playerTransform;

    private bool PlayerExist = false;

    void Awake()
    {
        // If player exist, we are in the game scene.
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
        // Only update high scores if we are not in game scene
        if (PlayerExist)
            scoreText[0].text = "Score: " + Global.score;
        else
        {
            UpdateHighScores(Global.score);
            for (int i = 0; i < highscores.Length; i ++)
            {
                scoreText[i].text = "" + highscores[i];
            }
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Find where the player is and calculate score
        if (PlayerExist)
        {
            playerTransform = GameObject.Find("Player").transform;
            //Global.UpdateScore(playerTransform.position.x - start);
            scoreText[0].text = "Score: " + Global.score;
        }
    }

    // Place score in high score list
    void UpdateHighScores(int score)
    {
        int i, temp1 = 0, temp2 = 0;

        for (i = 0; i < highscores.Length; i ++)
        {
            if (score > highscores[i])
            {
                temp1 = highscores[i];
                highscores[i] = score;
                break;
            }
        }

        // Shift rest of scores down
        for (i = i + 1; i < highscores.Length; i ++)
        {
            temp2 = highscores[i];
            highscores[i] = temp1;
            temp1 = temp2;
        }
    }
}
