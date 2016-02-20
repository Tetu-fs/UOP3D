using UnityEngine;
using System.Collections;

public class backScroll : MonoBehaviour {
    private Renderer rend;
    private float Speed = 0f;
    public float Xscroll = 0;
    public float Yscroll = -5;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();

    }

    // Update is called once per frame
    void Update () {

        rend.material.SetTextureOffset("_MainTex", new Vector2(Speed += Xscroll * Time.deltaTime, Speed += Yscroll * Time.deltaTime));

    }
}
