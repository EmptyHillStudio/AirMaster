using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BagManager : MonoBehaviour
{
    public class Bag
    {
        public string username;
        Dictionary<int, int> planeBag = new Dictionary<int, int>();
        //�жϱ����Ƿ��и�id�ķɻ�
        public bool IsPlane(int id)
        {
            if (this.planeBag.ContainsKey(id))
                return true;
            else
                return false;
        }
        //��������и�id�ɻ�������
        public int GetNum(int id)
        {
            foreach(KeyValuePair<int, int> bag in this.planeBag )
            {
                if (bag.Key == id)
                    return bag.Value;
            }
            return 0;
        }
        public string getUsername()
        {
            return this.username;
        }
        //���������ӷɻ�
        public void AddPlane(int id,int num)
        {
            if (this.planeBag.ContainsKey(id))
            {
                this.planeBag[id] = this.planeBag[id] + num;
            }
            else
            {
                this.planeBag.Add(id, num);
            }
        }
        
    }
    public class BagsManager
    {
        List<Bag> Bags;
        public BagsManager()
        {
            this.Bags = new List<Bag>();
        }
        public Bag GetBagbyUsername(string username)
        {
            foreach(var b in Bags)
            {
                if(b.getUsername().Equals(username))
                {
                    return b;
                }
            }
            return null;
        }
        public void add (Bag b)
        {
            this.Bags.Add(b);
        }
    }
}
