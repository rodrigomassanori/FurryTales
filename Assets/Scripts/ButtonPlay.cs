using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonPlay : MonoBehaviour 
{
	ColorBlock BtnPlayColor;

	void Awake()
	{
		BtnPlayColor = GetComponent<Button>().colors;
	}

	public void OnClick()
	{
		StartCoroutine(Play());
	}

	public void ButtonTransitionColors()
	{
		BtnPlayColor.pressedColor = Color.magenta;
	}

	IEnumerator Play()
	{
		yield return new WaitForSeconds(20.0f);

		SceneManager.LoadScene("Narration");
	}
}