using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fill : MonoBehaviour {

    public GameObject go;
    public Transform[] pos;
    public GameObject treeFab;
    public GameObject treeFabManaged;

    // Use this for initialization
    void Start () {
        Transform[] pos = new Transform[transform.childCount];
        for(int i = 0; i < pos.Length; i++)
        {
            pos[i] = go.transform.GetChild(i);
        }
        int differentTree = 0;

        foreach (Transform positions in pos)
        {
            GameObject gameObject;
            if (differentTree % 5 != 0)
            {
                gameObject = Instantiate(treeFab, positions.position, positions.rotation);
                gameObject.transform.SetParent(positions);
            }
            else
            {
                gameObject = Instantiate(treeFabManaged, positions.position, positions.rotation);
                gameObject.transform.SetParent(positions);
            }
            differentTree++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
