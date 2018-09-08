using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

    /*passable states:
     *  0 - All units
     *  1 - Players
     *  2 - Monsters
     *  3 - None
     */
    public int passable = 0;
    public bool active_unit = false;
    public bool target_tile = false;
    public bool selectable_tile = false;

    public List<Tile> adj_tiles = new List<Tile>();

    //BFS variables
    public bool visited = false;
    public Tile parent = null;
    public int distance = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (active_unit)
        {
            GetComponent<Renderer>().material.color = Color.yellow;
        }
        else if (target_tile)
        {
            GetComponent<Renderer>().material.color = Color.blue;
        }
        else if (selectable_tile)
        {
            GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }


    public void Reset()
    {
        passable = 0;
        active_unit = false;
        target_tile = false;
        selectable_tile = false;

        adj_tiles = new List<Tile>();

        //BFS variables
        visited = false;
        parent = null;
        distance = 0;
    }

    public void Find_Neighbors()
    {
        Reset();

        CheckTiles(Vector3.forward);
        CheckTiles(Vector3.back);
        CheckTiles(Vector3.left);
        CheckTiles(Vector3.right);
       

    }

    public void CheckTiles(Vector3 direction)
    {
        Vector3 half_extents = new Vector3(0.25f, 0.25f, 0);
        Collider[] colliders = Physics.OverlapBox(transform.position + direction, half_extents);

        foreach (Collider c in colliders)
        {
            Tile t = c.GetComponent<Tile>();
            if (t != null && t.passable < 3)
            {
                RaycastHit hit;

                if(Physics.Raycast(t.transform.position, Vector3.up, out hit))
                {
                    adj_tiles.Add(t);
                }
            }
        }
    }
}
