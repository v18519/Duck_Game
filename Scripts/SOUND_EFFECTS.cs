using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using UnityEngine;

public class SOUND_EFFECTS : MonoBehaviour {
    public AudioSource audio;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="owl")
        {
            Debug.Log("enter sound effect");
            audio.Play();
        }
    }
}
