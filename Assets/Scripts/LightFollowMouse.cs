using UnityEngine;
using System.Collections;

public class LightFollowMouse : MonoBehaviour {

	private Transform m_Transform;
	public float lightZ;
	// Use this for initialization
	void Start () {
		m_Transform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = lightZ;
	  m_Transform.LookAt(GetWorldPositionOnPlane(Input.mousePosition, lightZ));
	}

	public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) {
     Ray ray = Camera.main.ScreenPointToRay(screenPosition);
     Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
     float distance;
     xy.Raycast(ray, out distance);
     return ray.GetPoint(distance);
 }
}
