using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Collections;
using Unity.Jobs;

public struct AddJob : IJob
{
    public float a;
    public float b;
    public NativeArray<float> result;

    public void Execute()
    {
        result[0] = a + b;
        Debug.LogFormat("wtf 执行第一个Job 得出结果 {0}",a+b);
    }
}

public struct MulResultJob : IJob
{
    public float value;
    public NativeArray<float> result;

    public void Execute()
    {
        result[0] = result[0] * value;
        Debug.LogFormat("wtf 执行第二个Job 得出结果 {0}",result[0]);
    }
}

public class JobDependencyTest : MonoBehaviour
{
    void Start()
    {
        //计算 (10 + 10) * 5
        NativeArray<float> result = new NativeArray<float>(1, Allocator.TempJob);

        AddJob jobData = new AddJob();
        jobData.a = 10;
        jobData.b = 10;
        jobData.result = result;

        JobHandle firstHandle = jobData.Schedule();
        MulResultJob mulJobData = new MulResultJob();
        mulJobData.value = 5;
        mulJobData.result = result;

        JobHandle secondHandle = mulJobData.Schedule(firstHandle);

        secondHandle.Complete();

        Debug.Log("Result:" + result[0]);

        result.Dispose();
    }

}
