using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour {
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        // Check if player is lower than threshold.
        if (transform.position.y <= -3)
        {
            SceneManager.LoadScene(0); // Load Menu scene if dead

        }
	
	}
}
