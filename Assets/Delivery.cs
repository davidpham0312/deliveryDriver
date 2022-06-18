using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
    }
    bool hasPackage;
    [SerializeField] float destroyDelay = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Package" && !hasPackage) {
            Debug.Log("Package picked up");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        
        if (other.tag == "Customer") {
            if (hasPackage){
                Debug.Log("Package delivered");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else {
                Debug.Log("No package picked up");
            }
        }
    }
}
