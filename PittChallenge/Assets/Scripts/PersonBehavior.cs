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
    BoxCollider cc;
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
        infectivity = Random.Range(.1f, 1f);
        closeness = Random.Range(.1f, 1f);
        sickness = Random.Range(.01f, .1f);


        nma = gameObject.GetComponentInChildren<NavMeshAgent>();
        destination = gm.getNextTarget();
        nma.destination = destination.position;

        rnd = gameObject.GetComponentInChildren<Renderer>();
        SetColor();

        cc = GetComponentInChildren<BoxCollider>();
    }

    void Update()
    {
        GameManager gm = GameManager.Instance;
        cc = GetComponentInChildren<BoxCollider>();
        if (nma.remainingDistance <= 3f)
        {
            Transform next = gm.getNextTarget();
            destination = next;
            nma.SetDestination(next.position);
            //Debug.Log("Next " + destination);
        }

        incrementSickness();

        SetColor();

        washHands();

        vaccine();

    }

    void SetColor()
    {
        objectMaterial = new Material(Shader.Find("Diffuse"));
        objectColor = Color.Lerp(Color.white, Color.red, sickness);
        objectMaterial.color = objectColor;
        rnd.material = objectMaterial;
    }

    void incrementSickness()
    {
        if(Random.value < .02)
        sickness += .0005f;
    }

    void washHands()
    {
        if (Random.value < .02)
            sickness -= .005f;
    }

    void vaccine()
    {
        if (Random.value < .00001)
            infectivity -= .5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameManager.Instance;
        if (other.gameObject.layer == 8)
        {
            
            //sickness += gm.interact(other.gameObject);

            if (Random.value < .5)
            sickness += .05f;
      

            /*
            PersonBehavior p2 = other.gameObject.GetComponent<PersonBehavior>();
            sickness += p2.sickness * p2.infectivity * p2.closeness;
            */

        }
    }
}
