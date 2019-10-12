using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PersonBehavior : MonoBehaviour
{
    NavMeshAgent nma;
    Transform destination;
    public Color objectColor;
    Material objectMaterial;
    Renderer rnd;
    GameManager gm;

    [Range(0, 1)]
    public float sickness;
    public float infectivity;
    public float closeness;
    public int age;
 

    // Start is called before the first frame update
    void Start()
    {
        GameManager gm = GameManager.Instance;
        age = Random.Range(25, 65);
        infectivity = Random.Range(.1f, 1f);
        closeness = Random.Range(.1f, 1f);
        sickness = 0;


        nma = gameObject.GetComponentInChildren<NavMeshAgent>();
        destination = gm.getNextTarget();
        nma.destination = destination.position;

        rnd = gameObject.GetComponentInChildren<Renderer>();
        SetColor();
    }

    void Update()
    {
        GameManager gm = GameManager.Instance;
        if (nma.remainingDistance <= 3f)
        {
            Transform next = gm.getNextTarget();
            destination = next;
            nma.SetDestination(next.position);
            Debug.Log("Next " + destination);
        }

        if(sickness < 1)
        sickness += .0005f;

        SetColor();

    }

    void SetColor()
    {
        objectMaterial = new Material(Shader.Find("Diffuse"));
        objectColor = Color.Lerp(Color.white, Color.red, sickness);
        objectMaterial.color = objectColor;
        rnd.material = objectMaterial;
    }

    void SetSickness()
    {

    }
}
