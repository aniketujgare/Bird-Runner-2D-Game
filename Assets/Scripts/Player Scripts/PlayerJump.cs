using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private AudioClip jumpClip;
    private float jumpForce = 12f, forwardForce = 0f;
    private bool canJump;
    private Rigidbody2D myBody;
    private Button jumpBtn;
    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();

        jumpBtn = GameObject.Find("Jump Button").GetComponent<Button>();
        jumpBtn.onClick.AddListener(() => jump());
    }

    public void jump()
    {

        
        if (canJump)
        {
            canJump = false;
            if (transform.position.x < 0)
                forwardForce = 1.5f;
            else
                forwardForce = 0f;
            AudioSource.PlayClipAtPoint(jumpClip, transform.position);
            myBody.velocity = new Vector2(forwardForce, jumpForce);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(myBody.velocity.y) == 0)
        {
            canJump = true;
            
            
        }
       else if (myBody.transform.position.y < -1f)
        {
            canJump = true;
        }

    }
}
