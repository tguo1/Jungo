using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public float DeathThreshold = -1.5f;
    private float player_pos;
    // Use this for initialization
    void Start () {
        player_pos = 0;
    }
	
	// Update is called once per frame
	void Update () {
        // Check if player is lower than threshold
        if (transform.position.y <= DeathThreshold)
        {
            SceneManager.LoadScene(3); // Load Death scene if dead
        }
    }
}
