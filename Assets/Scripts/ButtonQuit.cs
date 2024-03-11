using UnityEngine;
using UnityEngine.UI;

public class ButtonQuit : MonoBehaviour 
{
	Button BtnQuit;

	readonly KeyCode E = KeyCode.E;

	void Awake()
	{
		BtnQuit = GetComponent<Button>();
	}

	public void OnClick() 
	{
		if (Input.GetKeyDown(E))
		{
			Application.Quit();
		}
	}
}