using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour {
    private Transform playerTransform;

    // Use this for initialization
    void Start () {
        playerTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        // Check if player is lower than threshold.
        if (playerTransform.position.y <= -1.5)
        {
            Application.Quit();
        }
	
	}
}
