using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonInteraction : MonoBehaviour
{
    public void interact(GameObject firstPerson, GameObject secondPerson)
    {
        PersonBehavior p1 = firstPerson.getComponent<PersonBehavior>();
        PersonBehavior p2 = secondPerson.getComponent<PersonBehavior>();

        p1.sickness += \\Some Equation for sicknesss
        p2.sickness +=
    }
}
