using UnityEngine;

public class Partner : MonoBehaviour
{
	float Speed = 3.0f;

	Transform Player;

	void Awake()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);

		Vector3 Direction = Player.position - transform.position;

		float Angle = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg;

		transform.rotation = Quaternion.AngleAxis(Angle, Vector3.forward);
	}
}