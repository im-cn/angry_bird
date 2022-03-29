using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isClick = false;
    private Rigidbody2D rg;

    void Start()
    {

    }

    private void Awake()
    {
        isClick = false;
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        print("OnMouseDown");
        isClick = true;
    }

    private void OnMouseUp()
    {
        print("OnMouseUp");
        isClick = false;
        LetBirdGo();
    }


    // Update is called once per frame
    void Update()
    {
        if (isClick)
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
        }
        else
        {
            
        }
    }

    public void LetBirdGo()
    {
        transform.parent.GetComponent<DanGong>().LetBirdGo();
    }

    public void Fly(Vector2 direct, float lenght)
    {
        rg.isKinematic = false;
        Vector2 force = direct * lenght * 200;
        print(force);
        rg.AddForce(force);
    }

}
