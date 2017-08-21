using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill : MonoBehaviour {

    public GameObject go;
    public Vector3[] pos;
    public GameObject treeFab;

    // Use this for initialization
    void Start () {
        Vector3[] pos = new Vector3[transform.childCount];
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = go.transform.GetChild(i).position;
        }

        foreach (Vector3 positions in pos)
        {
            GameObject gameObject = Instantiate(treeFab, positions, new Quaternion(0, 0, 0, 1));
             
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
