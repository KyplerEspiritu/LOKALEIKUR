using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script sem spilar lag þegar þú byrjar leikinn

public class AudioController : MonoBehaviour {

	public AudioClip MusicClip;
	public AudioSource MusicSource;

	// Use this for initialization
	void Start () {
		MusicSource.clip = MusicClip;
		if (true)
			MusicSource.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}