using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    private Animator anim;
    private bool accept_input = true;

    public AnimationClip crouch;
    public AnimationClip walking;
    public AnimationClip dancing;
    void Start()
    {
        anim = this.GetComponent<Animator>();

        if(crouch != null) 
        {
            AddInputEndEvent(crouch);
            AddInputEndEvent(walking);
            AddInputEndEvent(dancing);
        }
    }

    void AnimationDone()
    {
        accept_input = true;
    }
    private void AddInputEndEvent(AnimationClip clip)
    {
        AnimationEvent animDoneEvent = new AnimationEvent();
        animDoneEvent.time = clip.length;
        animDoneEvent.functionName = "AnimationDone";
        clip.AddEvent(animDoneEvent);
    }
    void Update()
    {
        
        if (accept_input)
        {
            HandleInput();
        }
    }
    private void HandleInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        /*if (!Input.anyKey)
        {
            
        }*/
        anim.SetBool("Crouch", Input.GetKey(KeyCode.LeftControl));
        if (accept_input)
        {
            anim.SetFloat("Blend", horizontal);
        }
/*        if(Input.GetKey(KeyCode.Space))
        {
            anim.SetTrigger("Jumping");
        }*/
        if(Input.GetKey(KeyCode.C)) 
        {
            anim.SetTrigger("Dancing");
            anim.SetFloat("Blend", 0);
            accept_input = false;
        }
    }
}
