using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public enum CellState { Empty, HoneyInside, larveInside, Capped}
public class HiveCell : MonoBehaviour
{
    public CellState currCellState; 
    public GameObject cellCap;
    public GameObject HoneyInside;
    public GameObject larveInside;

    public void ON_Vr_Interact(string playerInput = "Empty")
    {
        //if player is empty handed, and state is Honey Inside, put honey in player's hand
        if (currCellState == CellState.HoneyInside && playerInput == "Empty")
        {
            // spawn a honey drop above the cell
            NewCellState(CellState.Empty);
        }


        else if (currCellState == CellState.HoneyInside && playerInput == "Larvae")
        {
            //remove the larve from the player's hand
            NewCellState(CellState.larveInside);
        }
        //if player input is honey and state is LArve Inside, cap it and remove the script
        else if (currCellState == CellState.larveInside && playerInput == "Honey")
        {
            //remove honey from player's hand
            NewCellState(CellState.Capped);
        }
    }
    public void NewCellState(CellState cellState)
    {
        Debug.Log("Setting Cell State"+ cellState);
        currCellState = cellState;
        if (currCellState == CellState.Empty)
        {

            cellCap.SetActive(false);
            HoneyInside.SetActive(false);
            larveInside.SetActive(false);

        }
        else if (currCellState == CellState.HoneyInside)
        {

            cellCap.SetActive(false);
            HoneyInside.SetActive(true);
            larveInside.SetActive(false);
        }
        else if(currCellState == CellState.larveInside)
        {

            cellCap.SetActive(false);
            HoneyInside.SetActive(true);
            larveInside.SetActive(true);
        }
        else if (currCellState == CellState.Capped)
        {

            cellCap.SetActive(true);
            HoneyInside.SetActive(false);
            larveInside.SetActive(false);
            Destroy(this);
        }
    }
}
