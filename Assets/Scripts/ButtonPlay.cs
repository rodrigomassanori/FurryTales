using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonPlay : MonoBehaviour 
{
	KeyCode E = KeyCode.E;

	Button Plbtn;

	ColorBlock BtnColor;

	void Awake()
	{
		Plbtn = GetComponent<Button>();

		BtnColor = GetComponent<Button>().colors;
	}

	void Update()
	{
		StartGame();
	}

    void StartGame()
    {
        StartCoroutine(Play());
    }

	IEnumerator Play()
	{
		if (Input.GetKeyDown(E))
		{
			yield return new WaitForSeconds(30.0f);

			BtnColor.pressedColor = Color.magenta;

			yield return new WaitForSeconds(20.0f);

			SceneManager.LoadScene("Narration");
		}
	}
}