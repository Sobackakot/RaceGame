using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class RoutePoint : MonoBehaviour
{
    [SerializeField] private UnityEvent eventScore;

    private void OnTriggerEnter(Collider other)
    { 
        if (!other.CompareTag("Player")) return;

        eventScore.Invoke();
        gameObject.SetActive(false);
    }
}
