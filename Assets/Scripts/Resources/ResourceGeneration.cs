using UnityEngine;
using System.Collections;

public class ResourceGeneration : MonoBehaviour {

    public GameObject resource;
    AudioSource source;
	
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
    public void GenerateResource() {
        int random = Random.Range(1, 3);
        if (random == 1) {
            source.Play();
            Instantiate(resource, transform.position + Vector3.up, Quaternion.identity);
        }
    }

	// Update is called once per frame
	void Update () {
        //GenerateResource();
	}
}
