using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gerak : MonoBehaviour
{
    Text infonyawa, infokoin;
    // Start is called before the first frame update
    public int kecepatan,kekuatanLompat;
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    public int nyawa;
    public int koin;
    
    Vector2 mulai;
    public bool ulang;

    public bool tombolKiri;
    public bool tombolKanan;

    public GameObject win, lose;

    void Start()
    {
        infonyawa = GameObject.Find("UInyawa").GetComponent<Text>();
        infokoin = GameObject.Find("UIkoin").GetComponent<Text>();
        lompat = GetComponent<Rigidbody2D> ();
        mulai = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        infonyawa.text = "Life : " + nyawa.ToString();
        infokoin.text = "Coin  : " + koin.ToString();
        if(ulang==true){
            transform.position = mulai;
            ulang = false;
        }
        if(nyawa<=0){
            Destroy(gameObject);
            lose.SetActive(true);
        }else if(koin>=12){
            win.SetActive(true);
        }
        tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkauan, targetlayer);

        if(Input.GetKey(KeyCode.D) || (tombolKanan==true)){
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah=-1;
        }else if(Input.GetKey(KeyCode.A) || (tombolKiri==true)){
            transform.Translate(Vector2.left * kecepatan * Time.deltaTime);
            pindah=1;
        }
        //if(tanah == true && (Input.GetKey (KeyCode.Mouse0))){
        //    lompat.AddForce(new Vector2(0,kekuatanLompat));
        //}
        if(pindah > 0 && !balik){
            balikbadan();
        }else if(pindah < 0 && balik){
            balikbadan();
        }
    }
    void balikbadan(){
        balik = !balik;
        Vector3 karakter = transform.localScale;
        karakter.x *= -1;
        transform.localScale = karakter;
    }
    public void klikkiri(){
        tombolKiri = true;
    }
    public void lepaskiri(){
        tombolKiri = false;
    }
    public void klikkanan(){
        tombolKanan = true;
    }
    public void lepaskanan(){
        tombolKanan = false;
    }
    public void jump(){
        if(tanah == true && (Input.GetKey (KeyCode.Mouse0))){
            lompat.AddForce(new Vector2(0,kekuatanLompat));
        }
    }
}
