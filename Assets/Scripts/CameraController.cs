using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour
{
    Transform player;
    float dumping = 1.5f;
    // Vector2 offset = new Vector2(2f, 1f);
    // bool isRight, isLeft, isTop, isBot;
    // int lastX;
    // Vector3 pos;

    void Start() {
        // pos = transform.position;
        // playerPos = player.position;
        // offset = new Vector2(Mathf.Abs(offset.x), offset.y);
        FindPlayer();
    }

    void FindPlayer() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // lastX = Mathf.RoundToInt(player.position.x);

        // if (playerIsLeft) {
        //     transform.position = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
        // } else {
        //     transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
        // }
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    void Update() {
        if (player) {
            int currentX = Mathf.RoundToInt(player.position.x);

            // if (currentX > lastX) {
            //     isLeft = false;
            // } else if (currentX < lastX) {
            //     isLeft = true;
            // }

            // lastX = Mathf.RoundToInt(player.position.x);

            Vector3 target = new Vector3(player.position.x, player.position.y, transform.position.z);
            // if (isLeft) {
            //     target = new Vector3(player.position.x - offset.x, player.position.y - offset.y, transform.position.z);
            // } else {
            //     target = new Vector3(player.position.x + offset.x, player.position.y + offset.y, transform.position.z);
            // }

            Vector3 currentPosition = Vector3.Lerp(transform.position, target, dumping * Time.deltaTime);
            transform.position = currentPosition;
        }
    }
}
