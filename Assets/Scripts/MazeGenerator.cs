using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGeneratorCell {
    public int X, Y;

    public bool wallLeft = true; 
    public bool wallBot = true;

    public bool visited = false;
    public int distanceFromStart;
}

public class MazeGenerator {
    int Width = 25;
    int Hight = 15;

    public MazeGeneratorCell[,] GeneratMaze() {
        MazeGeneratorCell[,] maze = new MazeGeneratorCell[Width, Hight];

        for (int x = 0; x < maze.GetLength(0); x++) {
            for (int y = 0; y < maze.GetLength(1); y++) {
                maze[x,y] = new MazeGeneratorCell{X=x, Y=y};
            }            
        }

        for (int x = 0; x < maze.GetLength(0); x++) {
            maze[x, Hight - 1].wallLeft = false;            
        }
        for (int y = 0; y < maze.GetLength(1); y++) {
            maze[Width - 1, y].wallBot = false;
        }        
        
        RemoweWallsWithBacktracker(maze);

        PlaceMazeExit(maze);
        
        return maze;
    }

    void RemoweWallsWithBacktracker(MazeGeneratorCell[,] maze) {
        MazeGeneratorCell current = maze[0,0];
        current.visited = true;
        current.distanceFromStart = 0;

        Stack<MazeGeneratorCell> stack  = new Stack<MazeGeneratorCell>();
        do {
            List<MazeGeneratorCell> unvisitedNeighbours = new List<MazeGeneratorCell>();

            int x = current.X;
            int y = current.Y;

            if (x > 0 && !maze[x - 1, y].visited) unvisitedNeighbours.Add(maze[x - 1, y]);
            if (y > 0 && !maze[x, y - 1].visited) unvisitedNeighbours.Add(maze[x, y - 1]);
            if (x < Width - 2 && !maze[x + 1, y].visited) unvisitedNeighbours.Add(maze[x + 1, y]);
            if (y < Hight - 2 && !maze[x, y + 1].visited) unvisitedNeighbours.Add(maze[x, y + 1]);

            if (unvisitedNeighbours.Count > 0){
                MazeGeneratorCell chosen = unvisitedNeighbours[UnityEngine.Random.Range(0, unvisitedNeighbours.Count)];
                RemoweWall(current, chosen);

                chosen.visited = true; 
                stack.Push(chosen);
                current = chosen;     
                chosen.distanceFromStart = stack.Count;           
            } else {
                current = stack.Pop();
            }
        } while (stack.Count > 0);
    }

    void RemoweWall(MazeGeneratorCell a, MazeGeneratorCell b) {
        if (a.X == b.X) {
            if (a.Y > b.Y) a.wallBot = false;
            else b.wallBot = false;
        } else {
            if (a.X > b.X) a.wallLeft = false;
            else b.wallLeft = false;
        }
    }

    void PlaceMazeExit(MazeGeneratorCell[,] maze) {
        MazeGeneratorCell furthest = maze[0,0];

        for (int x = 0; x < maze.GetLength(0); x++) {
            if (maze[x, Hight - 2].distanceFromStart > furthest.distanceFromStart) furthest = maze[x, Hight - 2];
            if (maze[x, 0].distanceFromStart > furthest.distanceFromStart) furthest = maze[x, 0];
        }

        for (int y = 0; y < maze.GetLength(1); y++) {
            if (maze[Width - 2, y].distanceFromStart > furthest.distanceFromStart) furthest = maze[Width - 2, y];
            if (maze[0, y].distanceFromStart > furthest.distanceFromStart) furthest = maze[0, y];
        } 

        if (furthest.X == 0) furthest.wallLeft = false;
        else if (furthest.Y == 0) furthest.wallBot = false;
        else if (furthest.X == Width - 2) maze[furthest.X+1, furthest.Y].wallLeft = false;
        else if (furthest.Y == Width - 2) maze[furthest.X, furthest.Y+1].wallBot = false;
    }
}
