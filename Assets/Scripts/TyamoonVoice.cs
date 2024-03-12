using UnityEngine;

public class TyamoonVoice : MonoBehaviour 
{
	AudioSource VoiceOfTyamoon;

	void Awake()
	{
		VoiceOfTyamoon = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player01")
		{	
			VoiceOfTyamoon.Play();
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		VoiceOfTyamoon.Stop();
	}
}