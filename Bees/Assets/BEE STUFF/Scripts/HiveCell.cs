using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public enum CellState { Empty, HoneyInside, larveInside, Capped}
public class HiveCell : MonoBehaviour
{
    public CellState currCellState; 
    public GameObject cellCap;
    public GameObject HoneyInside;
    public GameObject larveInside;



    public List<BeeGame_Grab> HoneySpawns;

    private void OnCollisionEnter(Collision collision)
    {
        BeeGame_Grab InputItem = collision.gameObject.GetComponent<BeeGame_Grab>();
        if (InputItem != null)
        {
            Debug.Log("Collision detected");
            if(InputItem.being_Held)
            {
                if(HoneySpawns.Contains(InputItem)){
                    HoneySpawns.Remove(InputItem);
                    if(HoneySpawns.Count <= 0)
                    {
                        ItemEnteredIntoCombCell();
                    }
                }
                ItemEnteredIntoCombCell(InputItem);
            }
        }
    }


    public void ItemEnteredIntoCombCell(BeeGame_Grab item =null)
    {
        if(item == null)
        {
            NewCellState(CellState.Empty);
        }

        if (currCellState == CellState.HoneyInside && item.item_Name == GrabNames.Larvae)
        {
           
            // Iterate over the list and destroy associated game objects
            foreach (BeeGame_Grab honey in HoneySpawns)
            {
                Destroy(honey.gameObject);
            }

            // Clear the list of HoneySpawns
            HoneySpawns.Clear();
            Destroy(item.gameObject);
            NewCellState(CellState.larveInside);
        }

        //if player input is honey and state is LArve Inside, cap it and remove the script
        else if (currCellState == CellState.larveInside && item.item_Name == GrabNames.Honey)
        {
            //remove honey from player's hand
            Destroy(item.gameObject);
            NewCellState(CellState.Capped);
        }

        else if(currCellState == CellState.Empty && item.item_Name == GrabNames.Nectar)
        {
            Destroy(item.gameObject);
            NewCellState(CellState.HoneyInside);
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
