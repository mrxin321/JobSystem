using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

[Unity.Burst.BurstCompile]
public struct MyParallelJob : IJobParallelFor
{
    public NativeArray<float> result;

    public void Execute(int i)
    {
        result[i] = Mathf.Sqrt(Mathf.Abs(Mathf.Sin(0.5f) * Mathf.Cos(0.4f)));   //执行了100万次
    }
}

public class ParallelForJobTest : MonoBehaviour
{
    public int calcSize = 1000000;
   
    public bool UseJobSystem = false;
    void Update()
    {
        if(UseJobSystem)ParallelCalc();
        if(!UseJobSystem)DirectCalc();
    }

    private void ParallelCalc()
    {
        float startTime = Time.realtimeSinceStartup;

        NativeArray<float> result = new NativeArray<float>(calcSize, Allocator.TempJob);

        MyParallelJob jobData = new MyParallelJob();
        jobData.result = result;

        JobHandle handle = jobData.Schedule(result.Length, 100);
        handle.Complete();

        float endTime = Time.realtimeSinceStartup;

        Debug.LogFormat("wtf 100万次计算时间 {0} 最后一个数据结果{1}",endTime - startTime,result[result.Length - 1]);

        result.Dispose();
    }

    private void DirectCalc()
    {
        List<float> result = new List<float>();
        float startTime = Time.realtimeSinceStartup;
        for (int i = 0; i < calcSize; i++)
        {
            result.Add(Mathf.Sqrt(Mathf.Abs(Mathf.Sin(0.5f) * Mathf.Cos(0.4f))));   //循环执行100万次
        }
        float endTime = Time.realtimeSinceStartup;
        Debug.LogFormat("wtf 100万次计算时间 {0} 最后一个数据结果{1}",endTime - startTime,result[result.Count - 1]);

    }
}
