using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    private Animator myAnimator;
    private CanvasGroup myGroup;

    public bool IsOpen
    {
        get { return myAnimator.GetBool("IsOpen"); }
        set { myAnimator.SetBool("IsOpen", value); }
    }

    public void Awake()
    {
        myAnimator = GetComponent<Animator>();
        myGroup = GetComponent<CanvasGroup>();

        //Our UI windows will be able to transition to the centre of the screen when we call for them.
        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
    }

    public void Update()
    {
        //Queries the animator controller for it's state and changes the interactability of our canvas group accordingly.
        if (!myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            myGroup.blocksRaycasts = myGroup.interactable = false;
        }
        else 
        {
            myGroup.blocksRaycasts = myGroup.interactable = true;
        }
    }
}
