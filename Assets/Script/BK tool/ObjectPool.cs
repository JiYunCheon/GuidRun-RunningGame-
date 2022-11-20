using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : MonoBehaviour
{
    Queue<T> m_pool = null;

    public int Pool_Max_Size { get; set; } = 50;
    

    T tObj = null;

    protected ObjectPool()
    {
        m_pool = new Queue<T>();
    }

    abstract public T CreatePool();

    public T Get()
    {
        if(tObj == null)
        {
            tObj = CreatePool();
        }
        if (m_pool.Count == 0)
        {
            T inst = Instantiate<T>(tObj);
            m_pool.Enqueue(inst);
            m_pool.Peek().gameObject.SetActive(false);
        }
        
        m_pool.Peek().gameObject.SetActive(true);
        return m_pool.Dequeue();
    }

    public void Release(T recObj)
    {
        if(m_pool.Count == Pool_Max_Size)
        {
            Destroy(recObj);
        }
        else
        {
            recObj.gameObject.SetActive(false);
            m_pool.Enqueue(recObj);
        }
    }

    public void DestroyPool()
    {
        for(int i = 0; i < m_pool.Count; i++)
        {
            Destroy(m_pool.Dequeue());
        }
    }
}
