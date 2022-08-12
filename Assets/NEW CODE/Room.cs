using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Room : MonoBehaviour
{
    public int _Width;
    public int _Height;

    public GameObject _Unit;
    public Miner _MinerPrefab;

    
    private List<Miner> _Miners;
    private Vector3 _TopLeft;

    private bool[,] _Room;
    // Start is called before the first frame update
    void Start()
    {       
        _Miners = new List<Miner>();        
        _Miners.Add(new Miner());
        _Miners.Last().Start(new Vector3(Random.Range(0,100),5,Random.Range(0,100)));
        
        _Room = new bool[100,100];


        for (int i = 0; i < 30; i++)
        {
            var CM = _Miners.Last();
            while (CM.Dead() == false)
            {
                CM.Update();
                Debug.Log($"{CM.current.x}:{CM.current.z}");
                _Room[(int)CM.current.z,(int)CM.current.x] = true;
            }

            _Miners.Add(new Miner());
            _Miners.Last().Start(new Vector3(Random.Range(0,100),5,Random.Range(0,100)));
        }

        _Width = (int)transform.localScale.x;
        _Height = (int)transform.localScale.z;
 
        var buffer = 1.2f;
        _TopLeft = transform.position;
        _TopLeft.x -= _Width/2;
        _TopLeft.z -= _Height/2;
        
        for (int row = 0; row < 100; row++)
        {
            for (int col = 0; col < 100; col++)
            {               
                var existing = _Room[row,col];

                if (existing == false)
                {
                    //Creation of each wall
                    var unitPos = new Vector3(_TopLeft.x +col, _TopLeft.y+2,_TopLeft.z +row);                 
                    var wall = Instantiate<GameObject>(_Unit, unitPos, new Quaternion() );

                    //Change color based on position
                   // wall.GetComponentInChildren<Renderer>().material.color = new Color((1.0f/_Width)*col,Mathf.Sin(row/_Width)/2 + .5f ,(1.0f/_Height)*row);
                }
            }
        }       
    }

    // Update is called once per frame
    void Update()
    {    
      //  _Miners.ForEach(miner => miner.Draw());
    }
}
