using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct MyJob : IJob
{
    public float a;
    public float b;

    public void Execute()
    {
        Debug.LogFormat("wtf 开始执行Ijob {0}",a+b);
    }
}

public class CreateJobTest : MonoBehaviour
{
    void Start()
    {
        MyJob jobData = new MyJob();
        jobData.a = 10;
        jobData.b = 10;
        JobHandle handle = jobData.Schedule();                  //调度，决定job放到哪些工人线程去执行。
        handle.Complete();                                      //真正执行job里面的代码。
    }
}
