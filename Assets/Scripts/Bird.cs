using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isClick = false;
    private Rigidbody2D rg;
    public float maxDis = 1;
    DanGong father;    

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
        father = transform.parent.GetComponent<DanGong>();
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
            Vector2 left = Camera.main.ScreenToWorldPoint(Input.mousePosition) - father.left_Pos.transform.position;
            Vector2 right = Camera.main.ScreenToWorldPoint(Input.mousePosition) - father.right_Pos.transform.position;
            float len = (left + right).magnitude / 2 > maxDis ? maxDis : (left + right).magnitude / 2;
            Vector2 beginPos = (father.left_Pos.transform.position + father.right_Pos.transform.position) / 2;
            transform.position = beginPos + (left + right).normalized * len;
             
            //transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position += new Vector3(0, 0, -Camera.main.transform.position.z);
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
        Vector2 force = direct * lenght * 300;
        rg.AddForce(force);
    } 

    public bool isHoldBird
    {
        get { return isClick; }
    }

}
