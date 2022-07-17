using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLines : MonoBehaviour
{

    [SerializeField] private double multiplier;
    private CheeseCollector cheeseCollector;
    public float finishLineHeight;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collector")
        {
            cheeseCollector = other.GetComponent<CheeseCollector>();
            cheeseCollector.cheeses = multiplier * cheeseCollector.cheeses;
            cheeseCollector.cheeseText.text = "Cheeses: " + cheeseCollector.cheeses;
        }
    }
}
