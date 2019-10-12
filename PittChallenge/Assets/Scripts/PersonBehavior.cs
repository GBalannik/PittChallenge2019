using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonBehavior : MonoBehaviour
{
    NavMeshAgent nma;
    public Transform destination;
    public Color objectColor;
    Material objectMaterial;
    Renderer rnd;

    public float sickness;
    public float infectivity;
    public float closeness;
    public int age;
 

    // Start is called before the first frame update
    void Start()
    {
        age = Random.Range(25, 65);
        infectivity = Random.Range(.1f, 1f);
        closeness = Random.Range(.1f, 1f);
        sickness = 0;


        nma = gameObject.GetComponentInChildren<NavMeshAgent>();
        nma.destination = destination.position;

        rnd = gameObject.GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, destination.position) <= 3.0f)
        { 
            // nma.destination = Director.pickDestination();
            Debug.Log("Destination Reached");
        }

        objectMaterial = new Material(Shader.Find("Diffuse"));
        objectMaterial.color = objectColor;
        rnd.material = objectMaterial;
    }
}
