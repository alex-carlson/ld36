using UnityEngine;
using System.Collections;

public class bulletBehavior : MonoBehaviour {

    public GameObject explo;
    public GameObject glitter;
	public int playerId;

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

			if (col.transform.name == "Hoop"+this.transform.name) {

				Instantiate(glitter, transform.position, Quaternion.identity);

				if (this.name == "1") {
					LevelManager.blueHoops++;
				} else {
					LevelManager.redHoops++;
				}
			}
            //Destroy(col.gameObject);
        }
        Instantiate(explo, transform.position, Quaternion.identity);
        Destroy(this.gameObject, 0.1f);
    }
}
