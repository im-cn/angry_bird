using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    public LineRenderer line_left;
    public LineRenderer line_right;
    public LineRenderer line_mine;
    private Vector3 lastPos;
    DanGong father;

    SpringJoint2D sp;
    Rigidbody2D rg;
    // Start is called before the first frame update
    void Start()
    {        

    }
    private void Awake()
    {
        father = transform.parent.GetComponent<DanGong>();
        rg = GetComponent<Rigidbody2D>();
    }

    private void OnMouseDown()
    {
        print("OnMouseDown");
    }

    private void OnMouseUp()
    {
        print("OnMouseUp");
    }
    // Update is called once per frame
    void Update()
    {
        if (checkHaveBird())
        {
            follwBird();
        }        
        
        PaintLine();
    }

    void PaintLine()
    {
        line_left.SetPosition(0, father.left_Pos.transform.position);
        line_left.SetPosition(1, transform.position);

        line_right.SetPosition(0, father.right_Pos.transform.position);
        line_right.SetPosition(1, transform.position);

        Vector2 left = father.left_Pos.transform.position - transform.position;
        Vector2 right = father.right_Pos.transform.position - transform.position;
        line_mine.SetPosition(0, left + right + (Vector2)transform.position);
        line_mine.SetPosition(1, transform.position);

        lastPos = transform.position;
    }

    bool checkHaveBird()
    {
        return father.isHaveBird;
    }

    void follwBird()
    {
        transform.position = father.bird.transform.position;
    }
    
    public void getVecAndDis(out Vector2 direct, out float lenght)
    {
        Vector2 left = father.left_Pos.transform.position - lastPos;
        Vector2 right = father.right_Pos.transform.position - lastPos;
        direct = (left + right).normalized;
        lenght = (left + right).magnitude;
    }

}
