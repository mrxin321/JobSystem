using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine.Jobs;

public class Test1 : MonoBehaviour
{

	// struct CustomA{
 //        public int a;
 //        public float b;

 //        public CustomA(int a,float b)
 //        {
 //            this.a = a;
 //            this.b = b;  
 //        }
 //    }

 //    struct Job1:IJob{
 //        public NativeArray<CustomA> list;

 //        public void Execute()
 //        {
 //            list.Add(new CustomA(1,2));
 //        }
 //    }
 //    // Start is called before the first frame update
 //    void Start()
 //    {
        
 //    }

 //    // Update is called once per frame
 //    void Update()
 //    {
 //        NativeArray<CustomA> ca = new NativeArray<CustomA>(Allocator.TempJob);
 //        for(int i=0;i<10;i++)
 //            ca.Add(new CustomA(i,i*0.5f));

 //        Job1 j1 = new Job1();
 //        j1.list = ca;

 //        j1.Scedule().Complete();
 //        Debug.Log(ca[0].b);
 //        ca.dispose();
 //    }
}
