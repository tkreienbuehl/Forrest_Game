using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManagerPanels : MonoBehaviour
{
    private Animator animator;

    private GameObject canvas;
    public GameObject eventPanel;
    

	// Use this for initialization
	void Start ()
	{
	    canvas = GameObject.Find("PanelCanvas");
	    animator = canvas.GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {
    }

    public void RemovePanel(string animationType)
    {
        ReverseAnimation();
        animator.Play(animationType, 0, 1f);
    }

    public void ShowPanel(string animationType)
    {
        PlayAnimationNormal();
        animator.Play(animationType, 0, 0f);
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
