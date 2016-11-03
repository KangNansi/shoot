using UnityEngine;
using System.Collections;

public class LightFollowMouse : MonoBehaviour {

	private Transform m_Transform;
	// Use this for initialization
	void Start () {
		m_Transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;
	  m_Transform.LookAt(mousePosition);
	}
}
