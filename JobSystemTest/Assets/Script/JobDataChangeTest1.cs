using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct MyDataJob1 : IJob
{
    public float a;
    public float b;
    public float result;
    
    public void Execute()
    {
        result =  a+b;
        Debug.LogFormat("wtf 开始执行Ijob {0}",result);
    }
}

public class JobDataChangeTest1 : MonoBehaviour
{
    void Start()
    {
        //值类型 不能传回主线程，因为Job在计算时是复制Job结构体里面的数据进行计算的，相当于Job结构体已经是一个复制体了，跟之前的Job结构没有任何关联了。
        //出于线程安全，保证没有资源竞争
        MyDataJob1 jobData = new MyDataJob1();
        jobData.a = 10;
        jobData.b = 10;
        JobHandle handle = jobData.Schedule();                  
        handle.Complete();                                      

        Debug.LogFormat("wtf jobData result {0}",jobData.result);


    }

}
