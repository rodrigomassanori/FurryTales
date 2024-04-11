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

			TyamoonDialogue.text = "Rápido Kaitlyn, temos que fechar as três valvulas no porão do reator";
		}
	}

	void OnCollisionExit2D(Collision2D other)
	{
		TyamoonDialogue.enabled = false;

		TyamoonDialogue.gameObject.SetActive(false);

		VoiceOfTyamoon.Stop();
	}
}