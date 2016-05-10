using UnityEngine;
using System.Collections;

public class Tiling : MonoBehaviour
{

    public int offsetX = 1;

    private float spriteWidth = 0f;
    private Camera cam;
    private Transform myTransform;

    private float myScale = 0f;

    private float x_pos;
    private float y_pos;

    private const int MAX_TILES = 50;
    private int num_tiles;

    private bool garbage_collect;
    private bool prev_ground;

    void Awake()
    {
        cam = Camera.main;
        myTransform = GameObject.Find("Tile1").transform;
        myScale = myTransform.localScale.x;

        x_pos = myTransform.position.x;
        y_pos = myTransform.position.y;
        num_tiles = 1;

        garbage_collect = false; // Flag set to true when we need to clear old tiles
        prev_ground = true; // This flag set to true if we created a tile. Used to determine if we need to add hole
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
        float camHorizExtend = cam.orthographicSize * Screen.width / Screen.height;

        float edgeVisiblePositionRight = (x_pos + spriteWidth / 2) - camHorizExtend;

        if (cam.transform.position.x >= edgeVisiblePositionRight - offsetX)
        {
            // Determine if we need to place a tile
            int random_tile = Random.Range(1, 20);
            // Determine if we need to raise or lower ground
            int random_direction = Random.Range(1, 20);

            int direction = 0;
            switch(random_direction)
            {
                case 1:
                    direction = -1;
                    break;
                case 2:
                    direction = 1;
                    break;
                default:
                    direction = 0;
                    break;
            }

            if (random_tile < 18 || !prev_ground)
            {
                prev_ground = true;
                Tile("Tile" + num_tiles, direction);
            }
            else
            {
                prev_ground = false;
                Tile("", direction);
            }

            // Get new spriteWidth
            SpriteRenderer sRenderer = myTransform.GetComponent<SpriteRenderer>();
            spriteWidth = sRenderer.sprite.bounds.size.x * myScale;
        }
    }

    void Tile(string groundName, int direction)
    {
        // If no ground name, no ground will be generated
        if (groundName.Length > 0)
        {
            x_pos += spriteWidth;
            y_pos += spriteWidth * direction;

            // If ground too low, raise the ground
            if (y_pos < -1.4)
            {
                y_pos -= 2 * spriteWidth * direction;
            }
            else if(y_pos > 20)
            {
                y_pos -= 2 * spriteWidth * direction;
            }

            Vector3 newPosition = new Vector3(x_pos, y_pos, myTransform.position.z);
            Transform newTransform = (Transform)Instantiate(GameObject.Find(groundName).transform, newPosition, myTransform.rotation);

            // Check if we will spawn a coin
            int create_coin = Random.Range(1, 10);
            if (create_coin < 2)
            {
                Vector3 coin_pos = new Vector3(x_pos, y_pos + 2* spriteWidth, myTransform.position.z);
                Transform coin_transform = (Transform)Instantiate(GameObject.Find("Coin").transform, coin_pos, myTransform.rotation);
            }

            newTransform.parent = myTransform.parent;

            myTransform = newTransform;
            myScale = myTransform.localScale.x;

            num_tiles++;

            if (num_tiles > MAX_TILES)
            {
                num_tiles -= MAX_TILES;
                garbage_collect = true;
            }

            if (garbage_collect)
                Destroy(GameObject.Find("Tile" + num_tiles));

            newTransform.name = "Tile" + num_tiles;
        }
        else
        {
            x_pos += 2*spriteWidth;
        }
    }
}