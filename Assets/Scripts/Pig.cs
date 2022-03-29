using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pig : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private SpriteRenderer render;
    public float maxSpeed;
    public float minSpeed;
    public Sprite hurt;
    public GameObject boom;
    
    private void Awake()
    {
        render = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > maxSpeed)
        {
            Dead();
            
        }
        else if (collision.relativeVelocity.magnitude > minSpeed)
        {
            render.sprite = hurt;
        }
    }

    void Dead()
    {
        Destroy(gameObject);
        Instantiate(boom, transform.position, Quaternion.identity);
    }


    void func()
    {
        
    }

}
