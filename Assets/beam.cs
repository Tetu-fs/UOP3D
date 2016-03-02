using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {

    private GameObject Boss = null;
    // Use this for initialization
    void Start () {
        Boss = GameObject.FindGameObjectWithTag("Boss");
    }

    // Update is called once per frame
    void Update()
    {
        if (Boss == null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Vector2 beamPosition = transform.position;
            Vector2 bossPosition = Boss.transform.position;
            beamPosition.x = bossPosition.x;
            transform.position = beamPosition;
        }
    }
}
