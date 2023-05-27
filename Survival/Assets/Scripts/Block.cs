using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public GameObject pegPrefab;
    public List<GameObject> pegs = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        CreatePeg(new Vector3(0.5f, 0f, 0f), "X");
        CreatePeg(new Vector3(-0.5f, 0f, 0f), "-X");
        CreatePeg(new Vector3(0f, 0.5f, 0f), "Y");
        CreatePeg(new Vector3(0f, -0.5f, 0f), "-Y");
        CreatePeg(new Vector3(0f, 0f, 0.5f), "Z");
        CreatePeg(new Vector3(0f, 0f, -0.5f), "-Z");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePeg(Vector3 pos, string axis)
    {
        var peg = Instantiate(pegPrefab);
        peg.transform.parent = transform;
        peg.transform.localPosition = pos;
        peg.transform.rotation = Quaternion.identity;
        peg.name = "Peg "+ axis;
        pegs.Add(peg);
    }
}
