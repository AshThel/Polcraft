using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelFarm : MonoBehaviour
{
	private GameObject currentBlockType;
	public GameObject[] blockTypes;

	public float amp = 10f;
	public float freq = 10f; 
	private Vector3 myPos;

    public Material leaf;
    public Material tree;

    void Start ()
    {
		generateTerrain ();
	}
	
	// Update is called once per frame
	void generateTerrain()
    {

		myPos = this.transform.position;
		int cols = 100;
		int rows = 100;
		for (int x = 0; x < cols; x++)
        {
			for(int z = 0; z <rows; z++)
            {
				float y = Mathf.PerlinNoise ((myPos.x + x)/freq, (myPos.z + z)/freq) * amp; 
				y = Mathf.Floor (y);
				if (y > amp / 2)
					currentBlockType =
						blockTypes [1];
				else
					currentBlockType =
						blockTypes [0];
				
				GameObject newBlock =
					GameObject.Instantiate (currentBlockType);
				newBlock.transform.position = 
					new Vector3 (myPos.x + x, y, myPos.z + z);

                //Now decide whether to create a tree!!
                if (Random.value * 100 < 1)
                {
                    float adjust = newBlock.transform.localScale.y / 2f;

                    GameObject treeBabe = GameObject.CreatePrimitive(PrimitiveType.Cube);

                    Vector3 tT = treeBabe.transform.localScale;
                    tT.y = Random.value * 24;
                    treeBabe.transform.localScale = tT;

                    adjust += treeBabe.transform.localScale.y / 2f;

                    treeBabe.GetComponent<MeshRenderer>().material = tree;

                    treeBabe.transform.position = new Vector3(myPos.x + x * currentBlockType.transform.localScale.x, myPos.y + y * currentBlockType.transform.localScale.y, myPos.z + z * currentBlockType.transform.localScale.z);

                }
                //head tree
                GameObject headTree = GameObject.CreatePrimitive(PrimitiveType.Cube);



            }
        }
	}
}
