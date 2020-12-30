using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {
    public float scrollSpeed;

    void Update() {
        Vector2 pos = this.transform.position;
        pos.y += Time.deltaTime * this.scrollSpeed;
        if (pos.y >= Constants.BACKGROUND_HEIGHT) {
            pos.y -= Constants.BACKGROUND_HEIGHT;
        }
        else if (pos.y <= -Constants.BACKGROUND_HEIGHT) {
            pos.y += Constants.BACKGROUND_HEIGHT;
        }
        this.transform.position = pos;
    }
}
