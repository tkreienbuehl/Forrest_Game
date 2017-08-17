using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPanels : MonoBehaviour
{
    private Animator animator;

    private GameObject canvas;
    

	// Use this for initialization
	void Start ()
	{
	    canvas = GameObject.Find("PanelCanvas");
	}
	
	// Update is called once per frame
    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("MultipleDecisionsPanelAnimation"))
        {
            ShowPanel();
        }
        else
        {
            RemovePanel();
        }
    }


    void RemovePanel()
    {
        ReverseAnimation();
        animator.Play("MultipleDecisionsPanelAnimation");
    }

    void ShowPanel()
    {
        PlayAnimationNormal();
        animator.Play("MultipleDecisionsPanelAnimation");
    }

    void PlayAnimationNormal()
    {
        animator.SetFloat("Direction", 1);
    }

    void ReverseAnimation()
    {
        animator.SetFloat("Direction", -1);
    }
}
