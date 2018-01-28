using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Rigidbody2D hook;        // A reference to the initial hook
    public GameObject linkPrefab;   // A reference for spawning the link prefabs
    public int links = 7;           // Default count for links in chain

    // Use this for initialization
    void Start()
    {
        GenerateRope();

    }

    void GenerateRope()
    {
        GameObject link = null;
        Rigidbody2D previousRB = hook.GetComponent<Rigidbody2D>();  // Set first previous body to the Hook
        for (int i = 0; i < links; i++)
        {
            link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;                       // Connect the new link to the previous body. First time will be hook, afterwards is below

            previousRB = link.GetComponent<Rigidbody2D>();          // Link we just made is new previous body
        }
    }
}
