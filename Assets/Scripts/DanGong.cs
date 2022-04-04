using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanGong : MonoBehaviour
{
    // Start is called before the first frame update
  
    Bird prefabs_bird;
    public bool isHaveBird { get; set; }

    public Transform right_Pos { get; set; }
    public Transform left_Pos { get; set; }
    public Transform right { get; set; }
    public Transform left { get; set; }
    public GameObject middle { get; set; }
    public Bird bird { get; set; }

    private void Awake()
    {
        isHaveBird = false;
        prefabs_bird = Resources.Load<Bird>("Prefabs/Birds");
        right_Pos = transform.Find("Right/Right_Pos");
        left_Pos = transform.Find("Left/Left_Pos");
        right = transform.Find("Right");
        left = transform.Find("Left");
        middle = GameObject.Find("Middle");
    }

    void Start()
    {
        MakeABird();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeABird()
    {
        bird = Instantiate(prefabs_bird);
        bird.transform.position = middle.transform.position;
        bird.transform.SetParent(transform);
        isHaveBird = true;
    }

    public void LetBirdGo()
    {
        Vector2 direct;
        float lenght;
        middle.GetComponent<Middle>().getVecAndDis(out direct, out lenght);
        isHaveBird = false;
        bird.Fly(direct, lenght);
        Invoke("MakeABird", 2);
    }
    
    public bool isHoldBird
    {
        get { return bird.isHoldBird; }        
    }
}
