using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct MyDataJob2 : IJob
{
    public float a;
    public float b;
    public List<float> result;
    
    public void Execute()
    {
        Debug.LogFormat("wtf 开始执行Ijob {0}",a+b);
        result.Add( a+b);
    }
}

public class JobDataChangeTest2 : MonoBehaviour
{
    void Start()
    {
        //很遗憾 这个是有报错的 MyDataJob2.result is not a value type. Job structs may not contain any reference types.
        var list = new List<float>();
        MyDataJob2 jobData = new MyDataJob2();
        jobData.a = 10;
        jobData.b = 10;
        jobData.result = list;
        JobHandle handle = jobData.Schedule();                 
        handle.Complete();                                     

        Debug.LogFormat("wtf jobData result {0}",jobData.result[0]);
    }

}
