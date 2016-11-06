using UnityEngine;
using System.Collections;

public class SpriteShadow : MonoBehaviour {

	public bool castShadows;
	public bool receiveShadows;
	private Renderer renderer;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<Renderer>();
		renderer.receiveShadows = receiveShadows;

	}

	// Update is called once per frame
	void Update () {

	}
}
