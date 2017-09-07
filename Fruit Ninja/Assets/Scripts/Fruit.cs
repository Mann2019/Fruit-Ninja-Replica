using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour {

    public GameObject fruitPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Blade"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            Instantiate(fruitPrefab, transform.position, rotation);
            Destroy(gameObject);
        }
    }
}
