using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    private Animator anim;
    float speed = 8.0f;
    float positionX, positionY;
    bool isWait, goRight, goLeft, goTop, goBot;

    void Start() {
        transform.position = new Vector2(-4.25f, 2.1f);
        anim = GetComponent<Animator>();
    }

    void Update() {
        // bool isWait = !Input.GetKey(KeyCode.UpArrow) & !Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.LeftArrow);

        // bool goRight = Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.UpArrow) & !Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.LeftArrow);        
        // bool goLeft = Input.GetKey(KeyCode.LeftArrow)  & !Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.UpArrow); 

        // bool goTop = Input.GetKey(KeyCode.UpArrow) & !Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.LeftArrow);
        // bool goBot = Input.GetKey(KeyCode.DownArrow) & !Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.RightArrow) & !Input.GetKey(KeyCode.LeftArrow);

        if (Input.GetKey(KeyCode.RightArrow) & !goLeft & !goTop & !goBot) {
            goRight = true;
        
            goLeft = false; 
            goTop = false;
            goBot = false;
        } else {
            goRight = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow) & !goRight & !goTop & !goBot) {
            goLeft = true;

            goRight = false;         
            goTop = false;
            goBot = false;
        } else {
            goLeft = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) & !goRight & !goLeft & !goBot) {
            goTop = true;

            goRight = false;        
            goLeft = false; 
            goBot = false;
        } else {
            goTop = false;
        }
        if (Input.GetKey(KeyCode.DownArrow) & !goRight & !goLeft & !goTop) {
            goBot = true;

            goRight = false;        
            goLeft = false; 
            goTop = false;
        } else {
            goBot = false;
        }

        isWait = !goRight & !goLeft & !goTop & !goBot;

        anim.SetBool("isWait", isWait);

        anim.SetBool("goRight", goRight);        
        anim.SetBool("goLeft", goLeft);

        anim.SetBool("goTop", goTop);
        anim.SetBool("goBot", goBot);

        if(goLeft || goRight){
            positionX = Input.GetAxis("Horizontal") * speed;
        }
        if(goTop || goBot){
            positionY = Input.GetAxis("Vertical") * speed;
        }
        
        positionX *= Time.deltaTime;
        positionY *= Time.deltaTime;        

        transform.Translate(positionX, positionY, 0);
    }

    // void OnTriggerEnter2D(Collider2D subject) {
    //     if (subject.tag == "Spider") {
    //         GameOver();
    //     }
    // }

    void GameOver() {
        SceneManager.LoadScene(0);
    }

    void OnCollisionEnter2D(Collision2D subject) {
        if (subject.gameObject.tag == "Spider") {
            GameOver();
        } else if (subject.gameObject.tag == "Wall") {
            // print(subject.gameObject.name);
        }
    }
}
