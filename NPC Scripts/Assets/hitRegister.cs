using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hitRegister : MonoBehaviour {

    public Slider baraHP;
    private string playerCollider;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
        if (other.gameObject.tag != playerCollider) return;

        if (baraHP.value > 0) baraHP.value -= 20;
        else Debug.Log("AI MURIT");
    }

    // Use this for initialization
    void Start () {
        playerCollider = "Untagged";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
