using UnityEngine;

public class CamBehaviour : MonoBehaviour 
{
	public Transform Target;

    public float OffsetY = 3;

    public float SmoothX, SmoothY;

	void Update()
	{
		transform.position = new Vector3
		(Mathf.Lerp(transform.position.x, Target.transform.position.x, 
		SmoothX * Time.deltaTime), Mathf.Lerp(transform.position.y, 
		Target.transform.position.y, SmoothY * Time.deltaTime), transform.position.z);
	}
}