using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpowner : MonoBehaviour {
    public GameObject CellPrefab;

    void Start() {
        MazeGenerator generator = new MazeGenerator();
        MazeGeneratorCell[,] maze = generator.GeneratMaze();

        for (int x = 0; x < maze.GetLength(0); x++) {
            for (int y = 0; y < maze.GetLength(1); y++) {
                Cell c = Instantiate(CellPrefab, new Vector2(x*2,y*2), Quaternion.identity).GetComponent<Cell>();

                c.wallLeft.SetActive(maze[x, y].wallLeft);
                c.wallBot.SetActive(maze[x, y].wallBot);
            }            
        }
    }

    void Update() {
        
    }
}
