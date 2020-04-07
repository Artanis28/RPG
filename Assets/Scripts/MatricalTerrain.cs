using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatricalTerrain : MonoBehaviour
{
    public Color headlineColor = new Color(0, 255, 0, 10);
    // Start is called before the first frame update
    public Renderer renderer;
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }
    public void OnMouseOver()
    {
        renderer.material.color = headlineColor;

    }
    public void OnMouseExit()
    {
        renderer.material.SetColor("_Color", Color.clear);  

    }
}
