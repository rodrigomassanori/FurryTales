using UnityEngine;

public class CamBehaviour : MonoBehaviour 
{
	public Transform Target;

    public float OffsetY = 3;

    public float SmoothX, SmoothY;

	void Update()
	{
		transform.position = new Vector3
		(Mathf.Lerp(transform.position.x, target.transform.position.x, 
		smoothX * Time.deltaTime), Mathf.Lerp(transform.position.y, 
		target.transform.position.y, smoothY * Time.deltaTime), transform.position.z);
	}
}