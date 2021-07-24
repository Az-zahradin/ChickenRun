using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class koin : MonoBehaviour
{
    gerak KomponenGerak;
    // Start is called before the first frame update
    void Start()
    {
        KomponenGerak = GameObject.Find("ayam").GetComponent<gerak>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.transform.tag == "Player"){
            KomponenGerak.koin++;
            Destroy(gameObject);
        }
    }
}
