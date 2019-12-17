using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour {

    public AudioSource BGM;
    public Slider Volume;

	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
        BGM.volume = Volume.value;
    }

}
