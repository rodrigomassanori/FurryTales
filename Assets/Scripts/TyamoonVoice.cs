using UnityEngine;

public class TyamoonVoice : MonoBehaviour 
{
	AudioSource VoiceOfTyamoon;

	public DialoguePartner DPartner;

	void Awake()
	{
		VoiceOfTyamoon = GetComponent<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			DPartner.gameObject.SetActive(true);
			
			VoiceOfTyamoon.Play();
		}
	}
}