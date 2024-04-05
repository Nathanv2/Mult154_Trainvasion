using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollider : MonoBehaviour
{

    public UIManager UIM;

    public void Start()
    {
        UIM = GameObject.Find("UI Manager").GetComponent<UIManager>();
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            UIM.StartCombat();
        }
    }
}
