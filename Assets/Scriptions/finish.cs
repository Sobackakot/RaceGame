using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject textWin;
    private void Start()
    {
        Time.timeScale = 1f;
    }
    private void OnTriggerEnter(Collider other)
    {
        textWin.SetActive(true);
        Time.timeScale = 0f;
    }
}
