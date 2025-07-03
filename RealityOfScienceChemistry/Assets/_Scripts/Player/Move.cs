using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speedwant=10f;
    public float gravity = 30f;
    public float crounchHeight=0.6f;
    public float jumpPower=10f;

    private Rigidbody rb;
    private Vector3 playerScale;
    private float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -gravity, 0);
        playerScale = transform.localScale;
        speed = speedwant;
    }
    void Update()
    {
        //Ziplama
        Ray ray = new Ray(transform.position,Vector3.down );//Karakterin oldugu konumdan 1 metre assagisina isin atiyoruz
        RaycastHit Hit;
        if (Physics.Raycast(ray, out Hit, 1.1f)) 
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Ziplama Calistirildi Ama Daha Yapilmadi");
            }
        }

        //Kosma
        speed = speedwant;
        if (Input.GetKey(KeyCode.LeftShift)) {speed *=2;}

        //Eðilme
        if (Input.GetKey(KeyCode.LeftControl)){speed /= 2;transform.localScale = new Vector3(playerScale.x, crounchHeight, playerScale.z);}
        else {transform.localScale = playerScale;} 
    }
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 hareket = transform.right * horizontal + transform.forward * vertical;

        float verticalVelocity = 0;
        hareket.y = verticalVelocity;

        rb.velocity = hareket * speed;
    }

}
