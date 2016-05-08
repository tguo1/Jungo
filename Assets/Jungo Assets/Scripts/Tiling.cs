using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour
{

    public int offsetX = 1;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    private float myScale = 0f;

    private string ground = "Ground";
    private string nextGround = "";
    private int randGround = 4;

    private string[] grounds;

    void Awake()
    {
        cam = Camera.main;
        myTransform = GameObject.Find("Ground1_Clone").transform;
        myScale = myTransform.localScale.x;

        grounds = new string[4];

        grounds[0] = "";
        grounds[1] = "";
        grounds[2] = "";
        grounds[3] = "";
    }
    

	// Use this for initialization
	void Start ()
    {
        SpriteRenderer sRenderer = myTransform.GetComponent<SpriteRenderer>();
        spriteWidth = sRenderer.sprite.bounds.size.x * myScale;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Select random ground
        randGround = Random.Range(1, 5);
        nextGround = ground + randGround;

        float camHorizExtend = cam.orthographicSize * Screen.width / Screen.height;

        float edgeVisiblePositionRight = (myTransform.position.x + spriteWidth / 2) - camHorizExtend;

        if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX)
        {
            Tile(nextGround);

            // Get new spriteWidth
            SpriteRenderer sRenderer = myTransform.GetComponent<SpriteRenderer>();
            spriteWidth = sRenderer.sprite.bounds.size.x * myScale;
        }
    }

    void Tile(string groundName)
    {
        Transform NextTransform = GameObject.Find(groundName).transform;
        Vector3 newPosition = new Vector3 (myTransform.position.x + spriteWidth, NextTransform.position.y, myTransform.position.z);
        Transform newTransform = (Transform) Instantiate(GameObject.Find(groundName).transform, newPosition, myTransform.rotation);

        newTransform.parent = myTransform.parent;

        myTransform = newTransform;
        myScale = myTransform.localScale.x;

        ClearGround(newTransform.name);
    }

    // Clear grounds that are not used.
    void ClearGround(string new_name)
    {
        // Remove oldest ground if it exists
        if (grounds[0].CompareTo("") != 0)
        {
            Destroy(GameObject.Find(grounds[0]));
        }

        // Move new grounds up
        for(int i = 1; i < grounds.Length; i ++)
        {
            grounds[i - 1] = grounds[i];
        }

        // Set new ground as newest member
        grounds[3] = new_name;

    }
}