using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getName : MonoBehaviour {
    string nameOfCharacter;

    // Update is called once per frame
    void Update () {
        nameOfCharacter = gameObject.transform.GetComponentInParent<CharacterChanger> ().imageName;
        GetComponent<Text> ().text = nameOfCharacter;
    }
}