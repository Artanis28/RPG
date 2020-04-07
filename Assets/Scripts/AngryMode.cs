using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AngryMode : MonoBehaviour
{
    public GameObject m_Hero;
    RaycastHit hit;
    public float speed;
    Rigidbody rb;
    Collider coll;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        coll = m_Hero.GetComponent<Collider>();
        speed = 20f;
    }
    Vector3 MoveToHero;

    // Update is called once per frame
    void Update()
    {
        MoveToHero = new Vector3(m_Hero.transform.position.x, 6f, m_Hero.transform.position.z);
        float distance = Vector3.Distance(transform.position, MoveToHero);
        if(distance < 50f)
        {
                transform.position = Vector3.MoveTowards(transform.position, MoveToHero, speed * Time.deltaTime);
        }
    }
}
