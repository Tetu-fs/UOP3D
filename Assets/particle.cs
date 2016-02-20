using UnityEngine;
using System.Collections;

public class particle : MonoBehaviour {

    ParticleSystem exprosion;

    // Use this for initialization
    void Start () {
        exprosion = GetComponent<ParticleSystem>();

        exprosion.Play();
    }
	public void DeleteMe(int bye)
    {
        if(bye == 1)
        {
            Destroy(this.gameObject);
        }
    }
	// Update is called once per frame
	void Update () {


    }
}
