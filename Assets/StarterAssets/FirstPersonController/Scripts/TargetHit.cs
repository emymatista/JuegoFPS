using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHit : MonoBehaviour
{
    
    //public Text targetNumber;
    private int contador;
    
    /*
    void Start()
    {
        contador = 0;
        //setTextoContador();
    }
    */

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Target"))
        {
            Debug.Log("You've hit a Target");
            other.gameObject.SetActive(false); 
            contador++;
            //setTextoContador();
            if(contador >= 5){
                Debug.Log("Juego Terminado");
            }
        }
    }
    
    /*
    void setTextoContador()
    {
        targetNumber.text = "" + contador.ToString();
        if(contador >= 5){
            Debug.Log("Juego Terminado");
        }
    }  
    */  
}
