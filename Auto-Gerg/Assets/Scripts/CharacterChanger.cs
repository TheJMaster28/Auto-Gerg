using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChanger : MonoBehaviour {
    public Image randomImage;
    // public Sprite s0;
    // public Sprite s1;
    // public Sprite s2;
    // public Sprite s3;
    public List<Sprite> images;

    public GameObject P1;
    public GameObject P2;

    public GameObject rm;

    public string imageName;

    void Start () {
        // images = new Sprite[4];
        // images[0] = s0;
        // images[1] = s1;
        // images[2] = s2;
        // images[3] = s3;
        changeImage ();
    }

    public void changeImage () {
        if (images.Count == 0) { return; }
        int num = UnityEngine.Random.Range (0, images.Count);
        randomImage.sprite = images[num];
        imageName = images[num].name;

    }

    private void Update () {

        // bool p1HasEnded = P1.GetComponent<PlayerManager> ().GetHasEnded ();
        // bool p2HasEnded = P2.GetComponent<PlayerManager> ().GetHasEnded ();
        // bool canRandom = rm.GetComponent<RoundManager> ().BattleActive;
        /*
         *NOT USING ATM
        //Player 1 hasGone Player 2 has not, switch to Player 2 Cam
        if (p1HasEnded == true && p2HasEnded == false)
        {
        //     changeImage();
        // }
        
        //  */

        // //Player 2 hasGone Player 1 has not, switch to Player 1 Cam
        // // if (p1HasEnded == false && p2HasEnded == true) {
        // //     changeImage ();
        // // }
        // // //Both players have ended their turn, switch to battle
        // // else if (p1HasEnded = true && p2HasEnded == true) {
        // //     changeImage ();
        // // }

        // if (canRandom) {
        //     changeImage ();
        //     // rm.GetComponent<RoundManager> ().randomI = false;
        // }

    }

}