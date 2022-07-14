using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultDictionary<TKey,TValue> : Dictionary<TKey, TValue>
{
    private TValue DefaultValue;
    public DefaultDictionary(TValue defaultValue): base() { DefaultValue = defaultValue; }

    public new TValue this[TKey key]
    {
        get
        {
            return this.TryGetValue(key, out TValue val) ? val : DefaultValue;
        }
        set
        {
            this.Add(key,value);
        }
    }
}
