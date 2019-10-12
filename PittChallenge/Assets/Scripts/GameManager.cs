using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    public Transform[] locations = new Transform[8];
    public GameObject[] people = new GameObject[10];

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }
 
    public Transform getNextTarget()
    {
        return locations[Random.Range(0, locations.Length)];
    }
}
