using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergySource : MonoBehaviour
{
    public GameObject energybarCanvas;
    public Slider energybarSlider;


    private void Update()
    {
        energybarCanvas = GameObject.Find("EnergyBarCanvas");
        if (energybarSlider == null)
        {
            energybarSlider = energybarCanvas.GetComponent<Slider>();
        }     
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            energybarSlider.value += 10;
            Destroy(gameObject);
            Debug.Log("Added 10 energy!");
        }
    }
}
