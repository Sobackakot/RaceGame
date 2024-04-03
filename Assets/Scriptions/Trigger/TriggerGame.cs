using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGame : MonoBehaviour
{
    public GameObject over;
    public GameObject win;
    public void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.tag == "Player")
        {
            win.SetActive(true);
            Time.timeScale = 0f;
        }
            
        else if(other.gameObject.tag == "NPS")
        {
            over.SetActive(true);
            Time.timeScale = 0f;
        }        
    }
}
