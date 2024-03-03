using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySpent : MonoBehaviour
{
    public int damage = 10;
    private object otherGameObject;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerEnergy = otherGameObject.GetComponent<PlayerController>();
        if(playerEnergy != null)
        {
            playerEnergy.TakeDamage(damage);
            Debug.Log("Enter");
        }
        
    }
}
