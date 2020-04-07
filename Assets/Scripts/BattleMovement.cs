using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleMovement : MonoBehaviour
{
    float speed;
    public GameObject[] plane;
    public GameObject onePlane;
    public MatricalTerrain script_MatricalTerrain;
    public GameObject sphere;
    public GameObject cylinder;
    public GameObject minotaur;
    int movement_Cube;
    int movement_Sphere;
    int movement_Cylinder;
    int movement_Minotaur;
    int hp_cube = 40;
    int hp_sphere = 30;
    int hp_cylinder = 60;
    int hp_minotaur = 100;


    // public List<GameObject> planes = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        plane = GameObject.FindGameObjectsWithTag("BattlePlanes");
        script_MatricalTerrain = plane[0].GetComponent<MatricalTerrain>();
        GameObject courrentColor = GameObject.Find("MatricalTerrain");
        speed = 2f;
        movement_Cube = 3;
        movement_Sphere = 0;
        movement_Cylinder = 0;
        movement_Minotaur = 0;

        
    }
    void Update()
    {
        
        
        
        


        if((movement_Cube == 3) && (gameObject != null))
        {
            ChangeTurnToCube();
        }
        else if((movement_Sphere == 5) && (sphere != null))
        {
            ChangeTurnToSphere();
        }
        else if((movement_Cylinder == 2) && (cylinder != null))
        {
            ChangeTurnToCylinder();
        }
        else if((movement_Minotaur == 4) && (minotaur != null))
        {
            ChangeTurnToMinotaur();
        }
        else if((gameObject == null) && (sphere != null))
        {
         ChangeTurnToSphere();
        }
        else if((gameObject == null) && (sphere == null) && (cylinder != null))
        {
            ChangeTurnToCylinder();
        }
        else if((sphere == null) && (cylinder != null) && (gameObject != null))
        { 
        ChangeTurnToCylinder();
        }
        else if((minotaur != null) && (cylinder == null))
        {
            ChangeTurnToMinotaur();
        }
        else if((minotaur != null) && (gameObject != null))
        {
        ChangeTurnToCube();
        }
        if(minotaur == null)
        {
            SceneManager.LoadScene("Win");
        }
        if((hp_cube <= 0) && (hp_cylinder <= 0) && (hp_sphere <= 0))
        {
            SceneManager.LoadScene("Dead");
        }
    }

    // Update is called once per frame
    void ChangeTurnToCube()
    {
        foreach(GameObject simple_Plane in plane)
        {
            MatricalTerrain scr = simple_Plane.GetComponent<MatricalTerrain>();
            Renderer rend = scr.GetComponent<Renderer>();
            Vector3 s = new Vector3(simple_Plane.transform.position.x, simple_Plane.transform.position.y + 13.4f, simple_Plane.transform.position.z);


            if(rend.material.color == new Color(0, 255, 0, 10))
            {

            if(movement_Cube == 3)
                {
                if(Input.GetMouseButtonDown(0))
                {
                
                   if((s != sphere.transform.position) &&
                    (s != cylinder.transform.position) &&
                    (s != transform.position) &&
                    (s != minotaur.transform.position))
                   {
                       if((Mathf.Abs((Mathf.Abs(gameObject.transform.position.x) - (Mathf.Abs(simple_Plane.transform.position.x)))) < movement_Cube * 50) &&
                          (Mathf.Abs((Mathf.Abs(gameObject.transform.position.z) - (Mathf.Abs(simple_Plane.transform.position.z)))) < movement_Cube * 50))
                       {
                    do
                    { 
                    transform.position = Vector3.MoveTowards(transform.position, s, speed * Time.deltaTime);


                                               
                                               
                    }
                    while(transform.position != s);
                       }
                    movement_Cube = 0;
                       movement_Sphere = 5;
                      
                }
                else if(minotaur.transform.position == s)
                {
                    if((Mathf.Abs((Mathf.Abs(gameObject.transform.position.x) - (Mathf.Abs(simple_Plane.transform.position.x)))) < movement_Cube * 50) &&
                          (Mathf.Abs((Mathf.Abs(gameObject.transform.position.z) - (Mathf.Abs(simple_Plane.transform.position.z)))) < movement_Cube * 50))
                       {
       
 

                                    
                        //if(Input.GetMouseButtonDown(0))
                               // {
                            foreach(GameObject simple_Plane_Cube in plane)
                            {
                            Vector3 s_Min = new Vector3(simple_Plane_Cube.transform.position.x, simple_Plane_Cube.transform.position.y + 13.4f, simple_Plane_Cube.transform.position.z);                 
                            Vector3 distance = s_Min - s;
                            Vector3 ss = new Vector3(minotaur.transform.position.x, minotaur.transform.position.y, minotaur.transform.position.z + 50f);
                            if(Mathf.Abs(distance.magnitude) <= 72f)
                            {
                                MatricalTerrain scr1 = simple_Plane_Cube.GetComponent<MatricalTerrain>(); 
                                Renderer rend1 = scr1.GetComponent<Renderer>();
                                rend1.material.color = Color.yellow;
                                                        if(Input.GetMouseButtonDown(0))
                                {
                                    if(Mathf.Abs((minotaur.transform.position - transform.position).magnitude) == 50f)
                                    {
                         if(Input.GetMouseButtonDown(0))
                         {           
                    do
                    { 
                    transform.position = Vector3.MoveTowards(transform.position, ss, speed * Time.deltaTime);
                                
                    }
                    while(transform.position != ss);
                                   movement_Cube = 0;
                                   movement_Sphere = 5;     
                                    }    
                                }

                                }
                             if(hp_cube <= 0)
                             {
                                 Destroy(gameObject);
                                 ChangeTurnToSphere();
                             }                            
                                               
                    }
                            }
                            hp_cube = hp_cube - 8;
                            hp_minotaur = hp_minotaur - 30;
                            Debug.Log("Cube: -8hp; Minotaur: - 30hp");
                            if(hp_minotaur <= 0)
                            {
                                SceneManager.LoadScene("Win");
                            }
                               // }
                                    

                            }
                        }
                       
                           
                }  
            
                }
                   
                }
                
            }
            
        }
        
    






    void ChangeTurnToSphere()
    {
       foreach(GameObject simple_Plane1 in plane)
        {
            MatricalTerrain scr1 = simple_Plane1.GetComponent<MatricalTerrain>();
            Renderer rend = scr1.GetComponent<Renderer>();
            Vector3 s1 = new Vector3(simple_Plane1.transform.position.x, simple_Plane1.transform.position.y + 13.4f, simple_Plane1.transform.position.z);
            
            if(rend.material.color == new Color(0, 255, 0, 10))
            {

            if(movement_Sphere == 5)
                {
                if(Input.GetMouseButtonDown(0))
                {
                
                   if((s1 != transform.position) &&
                    (s1 != cylinder.transform.position) &&
                    (s1 != sphere.transform.position) &&
                    (s1 != minotaur.transform.position))
                   {
                       if((Mathf.Abs(((Mathf.Abs(sphere.transform.position.x)) - (Mathf.Abs(simple_Plane1.transform.position.x)))) < movement_Sphere * 50) &&
                          (Mathf.Abs(((Mathf.Abs(sphere.transform.position.z)) - (Mathf.Abs(simple_Plane1.transform.position.z)))) < movement_Sphere * 50))
                       {
                    do
                    { 
                    sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, s1, speed * Time.deltaTime);
                    

                    
                            
                    
                    }
                    while(sphere.transform.position != s1);
                       }
                       //ChangeTurnToCylinder();
                       movement_Cylinder = 2;
                       movement_Sphere = 0;
            
                       
                }  
                else if(minotaur.transform.position == s1)
                {
                    if((Mathf.Abs((Mathf.Abs(sphere.transform.position.x) - (Mathf.Abs(simple_Plane1.transform.position.x)))) < movement_Sphere * 50) &&
                          (Mathf.Abs((Mathf.Abs(sphere.transform.position.z) - (Mathf.Abs(simple_Plane1.transform.position.z)))) < movement_Sphere * 50))
                       {
       
 

                                    
                        if(Input.GetMouseButtonDown(0))
                                {
                            foreach(GameObject simple_Plane_Sphere in plane)
                            {
                            Vector3 s_Min = new Vector3(simple_Plane_Sphere.transform.position.x, simple_Plane_Sphere.transform.position.y + 13.4f, simple_Plane_Sphere.transform.position.z);   
                            Vector3 distance = s_Min - s1;
                            if(Mathf.Abs(distance.magnitude) <= 72f)
                            {
                                MatricalTerrain scr2 = simple_Plane_Sphere.GetComponent<MatricalTerrain>();
                                Renderer rend2 = scr2.GetComponent<Renderer>();
                                rend2.material.color = Color.yellow;
                                if(Input.GetMouseButtonDown(0))
                                {
                                    if(Mathf.Abs((minotaur.transform.position - sphere.transform.position).magnitude) <= 72f)
                                    {

                    do
                    { 
                    sphere.transform.position = Vector3.MoveTowards(sphere.transform.position, s_Min, speed * Time.deltaTime);
                    
                    
                    }
                    while(sphere.transform.position != s_Min);
                                movement_Sphere = 0;
                                movement_Cylinder = 2; 
                                }
                                                         
                                               
                    }
                      

                      if(hp_sphere <= 0)
                             {
                                 Destroy(sphere);
                                 ChangeTurnToCylinder();
                             }  
                       }
                                }
                                hp_sphere = hp_sphere - 8;
                                hp_minotaur = hp_minotaur - 25;
                                Debug.Log("Sphere: -8hp; Minotaur: -25hp");   
                                if(hp_minotaur <= 0)
                            {
                                SceneManager.LoadScene("Win");
                            }
                            }
                        }
                }
                
                }
                
            }
        }
        //ChangeTurnToCylinder();
    }
    }

    void ChangeTurnToCylinder()
    {
        foreach(GameObject simple_Plane2 in plane)
        {
            MatricalTerrain scr = simple_Plane2.GetComponent<MatricalTerrain>();
            Renderer rend = scr.GetComponent<Renderer>();
            Vector3 s = new Vector3(simple_Plane2.transform.position.x, simple_Plane2.transform.position.y + 13.4f, simple_Plane2.transform.position.z);
            Vector3 s_Min = new Vector3(simple_Plane2.transform.position.x, simple_Plane2.transform.position.y + 13.4f, simple_Plane2.transform.position.z + 50f);
            
            if(rend.material.color == new Color(0, 255, 0, 10))
            {

            if(movement_Cylinder == 2)
                {
                if(Input.GetMouseButtonDown(0))
                {
                
                   if((s != transform.position) &&
                    (s != cylinder.transform.position) &&
                    (s != sphere.transform.position) &&
                    (s != minotaur.transform.position))
                   {
                       if((Mathf.Abs((Mathf.Abs(cylinder.transform.position.x) - (Mathf.Abs(simple_Plane2.transform.position.x)))) < movement_Cylinder * 50) &&
                          (Mathf.Abs((Mathf.Abs(cylinder.transform.position.z) - (Mathf.Abs(simple_Plane2.transform.position.z)))) < movement_Cylinder * 50))
                       {
                    do
                    { 
                    cylinder.transform.position = Vector3.MoveTowards(cylinder.transform.position, s, speed * Time.deltaTime);
                    
                    
                    }
                    while(cylinder.transform.position != s);
                       }
                       //ChangeTurnToMinotaur();
                       movement_Cylinder = 0;
                    
                            movement_Minotaur = 4;
                }  
                else if(minotaur.transform.position == s)
                {
                    if((Mathf.Abs((Mathf.Abs(cylinder.transform.position.x) - (Mathf.Abs(simple_Plane2.transform.position.x)))) < movement_Cylinder * 50) &&
                          (Mathf.Abs((Mathf.Abs(cylinder.transform.position.z) - (Mathf.Abs(simple_Plane2.transform.position.z)))) < movement_Cylinder * 50))

                       if(Input.GetMouseButtonDown(0))
                                {
                            foreach(GameObject simple_Plane_Cylinder in plane)
                            {
                            Vector3 s_Min1 = new Vector3(simple_Plane_Cylinder.transform.position.x, simple_Plane_Cylinder.transform.position.y + 13.4f, simple_Plane_Cylinder.transform.position.z);   
                            Vector3 distance = s_Min - s;
                            if(Mathf.Abs(distance.magnitude) <= 72f)
                            {
                                MatricalTerrain scr2 = simple_Plane_Cylinder.GetComponent<MatricalTerrain>();
                                Renderer rend2 = scr2.GetComponent<Renderer>();
                                rend2.material.color = Color.yellow;
                                if(Input.GetMouseButtonDown(0))
                                {
                                    if(Mathf.Abs((minotaur.transform.position - cylinder.transform.position).magnitude) <= 72f)
                                    {

                    do
                    { 
                    cylinder.transform.position = Vector3.MoveTowards(cylinder.transform.position, s_Min1, speed * Time.deltaTime);
                    
                    
                    }
                    while(cylinder.transform.position != s_Min1);
                    movement_Cylinder = 0;
                    movement_Minotaur = 4;
                                }
                                                         
                                               
                    }
                       

                      if(hp_cylinder <= 0)
                             {
                                 Destroy(cylinder);
                                 ChangeTurnToMinotaur();
                             }  
                       }
                                }
                                hp_cylinder = hp_cylinder - 8;
                                hp_minotaur = hp_minotaur - 20;
                                Debug.Log("Cylinder: -8hp; Minotaur: -20hp");
                                if(hp_minotaur <= 0)
                            {
                                SceneManager.LoadScene("Win");
                            }
                            }
                }
                }
                
                }
                
            }
            
        }
        
    }
    void ChangeTurnToMinotaur()
    {
       foreach(GameObject simple_Plane3 in plane)
        {
            //MatricalTerrain scr = simple_Plane3.GetComponent<MatricalTerrain>();
            //Renderer rend = scr.GetComponent<Renderer>();
            Vector3 s4 = new Vector3(simple_Plane3.transform.position.x, simple_Plane3.transform.position.y + 13.4f, simple_Plane3.transform.position.z);
            Vector3 s_Min = new Vector3(transform.position.x, transform.position.y, transform.position.z + 50f);
            Vector3 s_Min1 = new Vector3(sphere.transform.position.x, sphere.transform.position.y, sphere.transform.position.z + 50f);
            Vector3 s_Min2 = new Vector3(cylinder.transform.position.x, cylinder.transform.position.y, cylinder.transform.position.z + 50f);
            RaycastHit hit;
            
            // if(rend.material.color == new Color(0, 255, 0, 10))
            // {

            if(movement_Minotaur == 4)
                {

                // if(Input.GetMouseButtonDown(0))
                // {
                    
                   if((Physics.Raycast(minotaur.transform.position, transform.position, out hit, movement_Minotaur * 50f)) && (gameObject != null))                            
                            {
                                
                           // if((Mathf.Abs((Mathf.Abs(minotaur.transform.position.x) - (Mathf.Abs(simple_Plane3.transform.position.x)))) < movement_Minotaur * 50) &&
                           //     (Mathf.Abs((Mathf.Abs(minotaur.transform.position.z) - (Mathf.Abs(simple_Plane3.transform.position.z)))) < movement_Minotaur * 50))
                            //    {
                                    
                                     
                                            do{  
                                             minotaur.transform.position = Vector3.MoveTowards(minotaur.transform.position, s_Min, speed * Time.deltaTime);
                                             
                                            } 
                                            while(minotaur.transform.position != s_Min);
                                            movement_Minotaur = 0;
                                             movement_Cube = 3;
                                //}
                                         
                                }   
                                else if((Physics.Raycast(minotaur.transform.position, sphere.transform.position, out hit, movement_Minotaur * 50f)) && (sphere != null))
                                {
                    do
                    { 
                    minotaur.transform.position = Vector3.MoveTowards(minotaur.transform.position, s_Min1, speed * Time.deltaTime);
                    
                    }
                    while(minotaur.transform.position != s_Min1);
                    movement_Minotaur = 0; 
                    movement_Cube = 3;
                       
                   }
                    else if((Physics.Raycast(minotaur.transform.position, cylinder.transform.position, out hit, movement_Minotaur * 50f)) && (cylinder != null))
                                {
                    do
                    { 
                    minotaur.transform.position = Vector3.MoveTowards(minotaur.transform.position, s_Min2, speed * Time.deltaTime);
                    
                    }
                    while(minotaur.transform.position != s_Min2);
                    movement_Minotaur = 0; 
                    movement_Cube = 3;
                       
                   }
                   else
                   {
                    //    if((Mathf.Abs((Mathf.Abs(minotaur.transform.position.x) - (Mathf.Abs(simple_Plane3.transform.position.x)))) < movement_Minotaur * 50) &&
                    //             (Mathf.Abs((Mathf.Abs(minotaur.transform.position.z) - (Mathf.Abs(simple_Plane3.transform.position.z)))) < movement_Minotaur * 50))
                    //             {
                                    
                                     
                                            do{  
                                             minotaur.transform.position = Vector3.MoveTowards(minotaur.transform.position, s_Min, speed * Time.deltaTime);
                                            } 
                                            while(minotaur.transform.position != s_Min);
                                            movement_Minotaur = 0;
                                             movement_Cube = 3;
                     //           }
                   }  
            
                }
                
                }
                
            }
            
        } 
    


