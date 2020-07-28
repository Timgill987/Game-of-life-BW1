using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grid {

    private int width;
    private int height;
    private int[,] gridarray;

   public grid(int width, int height) {
        this.width = width;
        this.height = height;

        gridarray = new int[width, height];

        for (int x = 0; x < gridarray.GetLength(0); x++) {
            for (int y = 0; y < gridarray.GetLength(1); y++) {

            }
        }
    }
}
