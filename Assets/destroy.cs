using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//link this to the coin to make it dissapear.
public class Destroy : MonoBehaviour
{
 private void OnCollisionEnter2D(Collision2D collision){
    if(collision.gameObject.CompareTag("Player")){
        Destroy(this.gameObject);
    }
 }

}
