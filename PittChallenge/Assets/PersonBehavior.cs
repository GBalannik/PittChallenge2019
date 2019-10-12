using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
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
    }

    // Update is called once per frame
    void Update()
    {

    }
}
