using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemHittingController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GetComponentInParent<Golem>().OnHittingColiderActivated();
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<Golem>().OnHittingColiderDeactivated();
    }
}
