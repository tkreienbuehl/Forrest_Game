using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForest : MonoBehaviour {

    public GameObject treeFab;
    public GameObject treeFabManaged;
    public float timer;

    // Use this for initialization
    void Start () {
        timer = 5.0f;
    }

    // Update is called once per frame
    void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            ChangeForestOverTime(gameObject);
        }
    }

    public void ChangeForestOverTime(GameObject go)
    {
        if (transform.tag != "Old Forest")
        {
            GameObject gameObject;

            if (go.transform.tag == "Selective Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFab, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(go.transform);
                go.transform.tag = "Old Forest";
                timer = 6.0f;

            }

            else if (go.transform.tag == "Clear Cut Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFabManaged, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(go.transform);
                go.transform.tag = "Managed Forest";
                timer = 5.0f;

            }

            else if (go.transform.tag == "Managed Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFab, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(transform);
                go.transform.tag = "Old Forest";
                timer = 10.0f;

            }
        }
        timer = 2.0f;
    }
}
