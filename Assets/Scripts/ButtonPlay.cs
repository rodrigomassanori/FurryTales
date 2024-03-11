using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonPlay : MonoBehaviour 
{
	readonly KeyCode E = KeyCode.E;

	Button Plbtn;

	ColorBlock BtnPlayColor;

	void Awake()
	{
		Plbtn = GetComponent<Button>();

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
		if (Input.GetKeyDown(E))
		{
			yield return new WaitForSeconds(20.0f);

			SceneManager.LoadScene("Narration");
		}
	}
}