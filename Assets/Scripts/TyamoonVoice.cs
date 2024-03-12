using UnityEngine;
using TMPro;

public class TyamoonVoice : MonoBehaviour 
{
	AudioSource VoiceOfTyamoon;
	
	public TextMeshProUGUI TyamoonDialogue;

	void Awake()
	{
		VoiceOfTyamoon = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player01")
		{	
			VoiceOfTyamoon.Play();

			TyamoonDialogue.text = "Hurry up Kaitlyn, we need to turn off all three gears in reactor basement";
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		VoiceOfTyamoon.Stop();
	}
}