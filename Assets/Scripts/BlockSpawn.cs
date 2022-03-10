using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawn : MonoBehaviour
{
    [SerializeField]private Block blockPrefeb;
    public List<Block> blocksSpawn = new List<Block>(); 
    private int rowCount = 7;
    private float distanceBeTweenBlock = 0.7f;
    private int rowSpawn = 0;

    private void OnEnable() {
        for(int i = 0; i < 1; i ++)
        {
            SpawnRowOfBlocks();
        }
    }
    // cần chỉnh sửa
    public void SpawnRowOfBlocks() //Tạo ra các hàng block mới
    {
        foreach(var block in blocksSpawn )
        {
            if(block != null)
            {
                block.transform.position += Vector3.down*distanceBeTweenBlock; //khoảng cách trên cùng một cột của 2 block
            }
        }
        for (int i = 0; i < rowCount; i++)
        {
            if(UnityEngine.Random.Range(0,100) <= 50)
            {
                var block = Instantiate(blockPrefeb, Getpositon(i), Quaternion.identity);
                int hits = UnityEngine.Random.Range(1,2) + rowSpawn; // hp của block sau mỗi round
                block.SetHit(hits);
                blocksSpawn.Add(block);
            } 
        }
        rowSpawn++;
    }
    private Vector3 Getpositon(int i ) // vị trí của block mới được tạo ra 
    {
        Vector3 positon = transform.position;
        positon += Vector3.right * i * distanceBeTweenBlock;
        return positon;
    }
    
}
