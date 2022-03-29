using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;


namespace Trigger
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =true)]
    public class TriggerModeAttribute : Attribute
    {
        public TriggerMode Mode;
        public string[] pars;
        public TriggerModeAttribute(TriggerMode mode, params string[] pars) //ʱ�䴥��,������
        {
            this.Mode = mode;
            this.pars = pars;
        }
    }

}


public enum TriggerMode
{
    DATE
}
