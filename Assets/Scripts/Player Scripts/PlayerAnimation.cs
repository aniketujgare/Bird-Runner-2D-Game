using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacle")
            anim.Play("Idle");
    }
    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacle")
            anim.Play("Run");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
