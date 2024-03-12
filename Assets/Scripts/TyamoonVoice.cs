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
			TyamoonDialogue.enabled = true;

			TyamoonDialogue.gameObject.SetActive(true);
			
			VoiceOfTyamoon.Play();

			TyamoonDialogue.text = "Hurry up Kaitlyn, we need to turn off all three gears in reactor basement";
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		TyamoonDialogue.enabled = false;

		TyamoonDialogue.gameObject.SetActive(false);

		VoiceOfTyamoon.Stop();
	}
}