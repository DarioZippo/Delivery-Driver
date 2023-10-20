using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);

    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = noPackageColor;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Package" && hasPackage == false) {
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }

        if(other.tag == "Costumer" && hasPackage == true) {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package Delivered!");
        }
    }
}
