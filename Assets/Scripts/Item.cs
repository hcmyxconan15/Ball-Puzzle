using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collider) 
    {
        Destroy(gameObject);
    }
}
