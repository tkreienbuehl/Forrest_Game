using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecisionPanelContent : MonoBehaviour
{
    private GameObject canvas;
    private IDecisionPool iDecisionPool;

    GameObject panelRightGameObject;
    Text textRight;
    Image imageRight;
    int decisionIDRight;
    int factionIDRight;

    GameObject panelLeftGameObject;
    Text textLeft;
    Image imageLeft;
    int decisionIDLeft;
    int factionIDLeft;


    // Use this for initialization
    void Start ()
    {
        canvas = GameObject.Find("PanelCanvas");
        iDecisionPool = new DecisionPool();
	}
	
	// Update is called once per frame
	void Update () {


    }

    public void FillSinglePanelContent()
    {
        panelRightGameObject = canvas.transform.Find("SingleDecisionPanel").gameObject;
        textRight = panelRightGameObject.transform.Find("Panel").transform.Find("DecisionDescription").GetComponent<Text>();

        RequestText(textRight);
        RequestFactionID(factionIDRight);
        RequestImage(imageRight);
        RequestDecisionID(decisionIDRight);
    }

    public void FillMultiPanelContent()
    {
        panelRightGameObject = canvas.transform.Find("RightPanel").gameObject;
        textRight = panelRightGameObject.transform.Find("Panel").transform.Find("DecisionDescription").GetComponent<Text>();
        RequestText(textRight);
        RequestFactionID(factionIDRight);
        RequestImage(imageRight);
        RequestDecisionID(decisionIDRight);



        panelLeftGameObject = canvas.transform.Find("LeftPanel").gameObject;
        textLeft = panelRightGameObject.transform.Find("DecisionDescription").GetComponent<Text>();
        RequestText(textLeft);
        RequestFactionID(factionIDLeft);
        RequestImage(imageLeft);
        RequestDecisionID(decisionIDLeft);
    }

    void RequestText(Text text)
    {
        text.text = iDecisionPool.getDecision().getRequestText();
        text.text = "it works";
    }

    void RequestFactionID(int id)
    {
        id = iDecisionPool.getDecision().getFactionID();
        id = 1;
    }

    void RequestImage(Image image)
    {
        //image =iDecisionPool.getDecision().getImage();
    }

    void RequestDecisionID(int id)
    {
        id = iDecisionPool.getDecision().getDecisionID();
        id = 1;
    }

    void RequestMultiText(Text textRight, Text textLeft)
    {
        textRight.text = iDecisionPool.getDecisionPair().getKey().getRequestText();
        textLeft.text = iDecisionPool.getDecisionPair().getKey().getRequestText();
    }

    void RequestMultiFactionID(int idRight, int idLeft)
    {
        idRight = iDecisionPool.getDecisionPair().getKey().getFactionID();
        idLeft = iDecisionPool.getDecisionPair().getKey().getFactionID();
    }

    void RequestMultiImage(Image imageRight, Image imageLeft)
    {
        //imageRight = iDecisionPool.getDecisionPair().getKey().getImage();
        //imageLeft = iDecisionPool.getDecisionPair().getKey().getImage();
    }

    void RequestMultiDecisionID(int idRight, int idLeft)
    {
        idRight = iDecisionPool.getDecisionPair().getKey().getDecisionID();
        idLeft = iDecisionPool.getDecisionPair().getKey().getDecisionID();
    }
}
