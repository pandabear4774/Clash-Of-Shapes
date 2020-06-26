using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if(other.transform.tag == "SquareDown")
        {
            Destroy(other);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
