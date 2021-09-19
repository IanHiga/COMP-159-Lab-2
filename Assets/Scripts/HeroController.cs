using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{
    private Rigidbody2D body;
    private Transform myTransform;
    private float yAccel;
    [SerializeField] private float maxVerticalAccel = 10f;
    [SerializeField] private float maxHorizAccel = 2f;
    private bool facingLeft = true;
    private Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        yAccel += .025f;
        float hInput = Input.GetAxis("Horizontal");
        anim.SetFloat("flapSpeed", hInput);
        body.AddForce(new Vector2(hInput * maxHorizAccel, Mathf.Abs(hInput * maxVerticalAccel)));
        if((facingLeft && (hInput > 0)) || (!facingLeft && (hInput < 0)))
        {
            FlipImage();
            Debug.Log(facingLeft);
        }
    }

    // Flip the Bird
    void FlipImage()
    {
        Vector3 flippedScale = myTransform.localScale;
        flippedScale.x *= -1;
        facingLeft = !facingLeft;
        myTransform.localScale = flippedScale;
    }
}
