using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class receh : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag.Equals("Player")){
            print("coin diammbil");
            Destroy(gameObject);
        }
    }
}
