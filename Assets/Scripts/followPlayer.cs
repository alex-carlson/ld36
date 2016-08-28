using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float lerpTime = 5f;
	GameObject[] players;
	Vector3 avgPos;
	int playerCount;

    Rigidbody2D momentum;
    Camera m_cam;

	// Use this for initialization
	void Start () {
        momentum = target.GetComponent<Rigidbody2D>();
        m_cam = GetComponent<Camera>();
		players = GameObject.FindGameObjectsWithTag ("Player");
		playerCount = players.Length;
	}
	
	// Update is called once per frame
	void Update () {
        momentum = target.GetComponent<Rigidbody2D>();

		avgPos = Vector3.zero;
		float dist = Vector3.Distance (players [0].transform.position, players [1].transform.position);

		for(int i = 0; i < players.Length; i++){
			avgPos += players [i].transform.position;
		}

			
		Vector3 pos = Vector3.Lerp(transform.position, (avgPos / playerCount) + (-Vector3.forward * 10), lerpTime * Time.deltaTime);
        transform.position = pos;

		float size = Mathf.Lerp(m_cam.orthographicSize, 60 + (dist / 2), lerpTime * Time.deltaTime);
        m_cam.orthographicSize = size;
	}
}
