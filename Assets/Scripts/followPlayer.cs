using UnityEngine;
using System.Collections;

public class followPlayer : MonoBehaviour {

    public Transform target;
    public Vector3 offset;
    public float lerpTime = 5f;

    Rigidbody2D momentum;
    Camera m_cam;

	// Use this for initialization
	void Start () {
        momentum = target.GetComponent<Rigidbody2D>();
        m_cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        momentum = target.GetComponent<Rigidbody2D>();
        Vector3 pos = Vector3.Lerp(transform.position, target.position + offset + (Vector3.right * (momentum.velocity.x * 0.05f)), lerpTime * Time.deltaTime);
        transform.position = pos;

        float size = Mathf.Lerp(m_cam.orthographicSize, 60 + (momentum.velocity.magnitude * 0.2f), lerpTime * Time.deltaTime);
        m_cam.orthographicSize = size;
	}
}
