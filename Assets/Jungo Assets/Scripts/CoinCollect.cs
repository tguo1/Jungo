using UnityEngine;
using System.Collections;

public class CoinCollect : MonoBehaviour {

    public AudioClip coinSound;
    private AudioSource audio;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            audio.PlayOneShot(coinSound, 1f);
            Global.UpdateScore(10);

            Destroy(this.gameObject);
        }
    }
}
