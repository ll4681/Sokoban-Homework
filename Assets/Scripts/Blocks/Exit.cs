using UnityEngine;



//THIS IS A COMMENT FOR CLASS


public class Exit : Block
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // HERE IS A COMMENT IN THE START FUNCTION
    }

    // Update is called once per frame
    void Update()
    {
        //check the currennt position of the player and see if it's the same as the position of this block on the grid

        //check what is standing in the exit's cell
        GameObject standingHere = gridManager.gridList[gridPos.x][gridPos.y].GetComponent<Cell>().ContainObj;
        if (standingHere != null && standingHere.tag.Equals("Player"))
        {
            //load a new scene
        }
    }
}
