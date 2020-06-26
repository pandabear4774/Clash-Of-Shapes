using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    public ParticleSystem particleStuff;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(particleStuff, transform.position, transform.rotation);
        particleStuff.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
