using UnityEngine;
using System.Collections;

public class bullet : MonoBehaviour {

    public int shotSpeed = 10;
    // Use this for initialization


    void Start () {
        GetComponent<Rigidbody2D>().velocity = transform.up.normalized * shotSpeed;
    }
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    // Update is called once per frame
    void Update () {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("Enemy1")
            || other.gameObject.CompareTag("Enemy2")
            || other.gameObject.CompareTag("Enemy4") 
            || other.gameObject.CompareTag("bulletEmit")) 
        {
            Destroy(this.gameObject);
        }

    }
}