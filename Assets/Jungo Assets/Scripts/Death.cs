using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {

    public float DeathThreshold = -1.5f;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Check if player is lower than threshold.
        if (transform.position.y <= DeathThreshold)
        {
            SceneManager.LoadScene(3); // Load Menu scene if dead

        }
	
	}
}
