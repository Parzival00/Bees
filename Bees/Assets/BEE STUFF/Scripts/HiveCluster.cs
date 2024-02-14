using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a cluster is one game object with a box collider to walk on top of it
public class HiveCluster : MonoBehaviour
{
    //Empty Game Objects of each individual cell slot in this cluster
    public HiveCell[] HiveCells;
    public bool playerReach;
    public void SetUPCells(float cappedPercent, float honeyPercent)
    {
        // Calculate the number of cells to set as capped and honeyInside
        int numCappedCells = Mathf.FloorToInt(HiveCells.Length * cappedPercent);
        int numHoneyCells = Mathf.FloorToInt(HiveCells.Length * honeyPercent);

        // Shuffle the HiveCells array
        ShuffleArray(HiveCells);

        // Reset all cells to empty state
        foreach (var cell in HiveCells)
        {
            cell.NewCellState(CellState.Empty);
        }

        // Set cells as capped
        for (int i = 0; i < numCappedCells; i++)
        {
            HiveCells[i].NewCellState(CellState.Capped);
        }

        // Set cells as honeyInside
        for (int i = numCappedCells; i < numCappedCells + numHoneyCells; i++)
        {
            HiveCells[i].NewCellState(CellState.HoneyInside);
        }
    }

    public void DisableAllCells()
    {
        foreach (var cell in HiveCells)
        {
            cell.GetComponent<Collider>().enabled = false;
            Destroy(cell);

        }
    }

    // Shuffle the array using Fisher-Yates algorithm
    private void ShuffleArray<T>(T[] array)
    {
        for (int i = array.Length - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            T temp = array[i];
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
    }
}
