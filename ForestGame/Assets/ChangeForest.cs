using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeForest : MonoBehaviour {

    public GameObject treeFab;
    public GameObject treeFabManaged;
    public GameObject treeFabSelective;
    public float timer;
    public float selectiveTime = 12.0f, managedTime = 20.0f, clearCutTime = 10.0f, burnedTimer = 8f;

    // Use this for initialization
    void Start () {
        if(transform.tag == "Selective Forest")
        {
            timer = selectiveTime;
        }
        else if (transform.tag == "Managed Forest")
        {
            timer = managedTime;

        }
        else if (transform.tag == "Clear Cut Forest")
        {
            timer = clearCutTime;
        }
        else if (transform.tag == "Burned Forest")
        {
            timer = burnedTimer;
        }
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
                timer = selectiveTime;

            }

            else if (go.transform.tag == "Clear Cut Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFabManaged, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(go.transform);
                go.transform.tag = "Managed Forest";
                timer = clearCutTime;

            }

            else if (go.transform.tag == "Managed Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFab, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(transform);
                go.transform.tag = "Old Forest";
                timer = managedTime;

            }

            else if (go.transform.tag == "Burned Forest")
            {
                Destroy(go.transform.GetChild(0).gameObject);
                gameObject = Instantiate(treeFabSelective, go.transform.position, go.transform.rotation);
                gameObject.transform.SetParent(transform);
                go.transform.tag = "Selective Forest";
                timer = selectiveTime;

            }
        }
        else
        {
            timer = clearCutTime;
        }
    }
}
