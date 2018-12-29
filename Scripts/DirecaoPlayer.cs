using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirecaoPlayer : MonoBehaviour {

    public bool face = true;
    public Transform playerT;

	void Start () {

        playerT = GetComponent<Transform> ();

	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetKey(KeyCode.D) && !face)
        {
            Flip();
        }

        else if (Input.GetKey(KeyCode.A) && face)
        {
            Flip();
        }

    }

    void Flip()
    {
        face = !face;

        Vector3 scala = playerT.localScale;
        scala.x *= -1;
        playerT.localScale = scala;
    }
}
