using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	private Rigidbody2D m_Rigidbody2D;
	private float m_MaxSpeed;
	// Use this for initialization
	void Start () {
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		m_MaxSpeed = 5f;
	}

	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis("Horizontal");
		float ver = Input.GetAxis("Vertical");

		m_Rigidbody2D.velocity = new Vector2(hor*m_MaxSpeed, ver*m_MaxSpeed);
	}
}
