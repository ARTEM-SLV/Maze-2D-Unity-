using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
    Animator anim;
    float speed = 6.0f;
    // float lastPositionX, lastPositionY;
    bool goRight, goLeft, goTop, goBot;
    GameObject player;
    Vector3 pos;

    void Start() {
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("Player");

        goRight = false;
        goLeft = false;
        goTop = false;
        goBot = false;

        // pos = transform.position;
    }

    void Update() {
        // lastPositionX = pos.x;
        // lastPositionY = pos.y;
        pos = transform.position;

        float directionX = player.transform.position.x - pos.x;
        float directionY = player.transform.position.y - pos.y;
 
        if (Mathf.Abs(directionX) < 5 && Mathf.Abs(directionY) < 5) {    
            if (Mathf.Abs(directionX) > Mathf.Abs(directionY)) {
                pos.x += Mathf.Sign(directionX) * speed * Time.deltaTime;
                // transform.position = pos;
                if (directionX > 0) {
                    transform.Translate(Vector3.right * speed * Time.deltaTime);
                    goRight = true;
                    goLeft = false;
                } else {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                    goRight = false;
                    goLeft = true;
                }               
                // goRight = pos.x > lastPositionX;
                // goLeft = pos.x < lastPositionX;

                goTop = false;
                goBot = false;
            } else {
                pos.y += Mathf.Sign(directionY) * speed * Time.deltaTime;
                // transform.position = pos;   
                if (directionY > 0) {
                    transform.Translate(Vector3.up * speed * Time.deltaTime);
                    goTop = true;
                    goBot = false;
                } else {
                    transform.Translate(Vector3.down * speed * Time.deltaTime);
                    goTop = false;
                    goBot = true;
                }            

                // goTop = pos.y > lastPositionY;
                // goBot = pos.y < lastPositionY;

                goRight = false;
                goLeft = false;
            }
        } else{
            goRight = false;
            goLeft = false;
            goTop = false;
            goBot = false;
        }              

        bool isWait = !goRight & !goLeft & !goTop & !goBot;       

        anim.SetBool("isWait", isWait);

        anim.SetBool("goTop", goTop);
        anim.SetBool("goRight", goRight);
        anim.SetBool("goBot", goBot);
        anim.SetBool("goLeft", goLeft);
    }

    void OnCollisionEnter2D(Collision2D subject) {
        if (subject.gameObject.tag == "Wall") {
            print(subject.gameObject.name);
        }
    }
}
