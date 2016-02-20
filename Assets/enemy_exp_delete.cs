using UnityEngine;
using System.Collections;

public class enemy_exp_delete : MonoBehaviour
{
    public AudioSource broken;
    // Use this for initialization
    void Start()
    {
        broken.Play();
    }
    public void DeleteMe(int bye)
    {
        if (bye == 1)
        {
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {


    }
}
