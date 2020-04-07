using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour
{
    Vector3 direction;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetMouseButtonDown(0))
        // {
            MoveToMousePos();
       // }
    }
    private void MoveToMousePos()
    {
       transform.position = Vector3.MoveTowards(gameObject.transform.position,
                                                Input.mousePosition, speed * Time.deltaTime);
    }
}
