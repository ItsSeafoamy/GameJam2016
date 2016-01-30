using UnityEngine;
using System.Collections;

public class ResourceGeneration : MonoBehaviour {

    public GameObject resource;
	
	void Start () {
	
	}
	
    void GenerateResource() {
        int random = Random.Range(1, 25);
        if (random == 1)
            Instantiate(resource, transform.position + Vector3.up, Quaternion.identity);
    }

	// Update is called once per frame
	void Update () {
        GenerateResource();
	}
}
