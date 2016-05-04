using UnityEngine;
using System.Collections;
using UnityEngine.UI;


[RequireComponent(typeof(Button))]
public class ButtonSound : MonoBehaviour {

	public AudioClip mAudioClip;
	private Button mButton { get { return GetComponent<Button> (); } }
	private AudioSource mAudioSource { get { return GetComponent<AudioSource> (); } }

	// Use this for initialization
	void Start () {
		gameObject.AddComponent<AudioSource> ();
		mAudioSource.clip = mAudioClip;
		mAudioSource.playOnAwake = false;

		mButton.onClick.AddListener(()=> PlaySound());
	}

	void PlaySound() {
		mAudioSource.PlayOneShot (mAudioClip);
	}
}
