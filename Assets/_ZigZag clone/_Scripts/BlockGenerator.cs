using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BlockGenerator : MonoBehaviour
{

    [SerializeField] 
    private GameObject blockPrefab;

    public static List<GameObject> blocks;
    public GameObject currentBlock;

    private static BlockGenerator _instance;
    public static BlockGenerator Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BlockGenerator>();
                DontDestroyOnLoad(_instance.gameObject);
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Start ()
	{
	    blocks = ObjectPool.Instance.Create(blockPrefab, 25);
        for (int i = 0; i < blocks.Count; i++)
	    {
	        Spawn();
	    }
	}

    public void Spawn()
    {
        int rnd = Random.Range(0, 2);
        GameObject temp = ObjectPool.Instance.Spawn(blocks, currentBlock.transform.GetChild(rnd).position,
            Quaternion.identity);
        currentBlock = temp ?? currentBlock;
    }
}
