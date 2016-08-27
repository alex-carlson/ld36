using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {

    public GameObject explo;
    public GameObject glitter;

    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "Breakable")
        {
            Destroy(col.gameObject);
            LevelManager.score++;
        }

        if (col.transform.tag == "Hoop")
        {
            LevelManager.hoops++;
            Instantiate(glitter, transform.position, Quaternion.identity);
            Destroy(col.gameObject);
        }
        Instantiate(explo, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
}
