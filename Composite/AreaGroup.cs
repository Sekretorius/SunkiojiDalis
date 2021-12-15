using SignalRWebPack.Characters;
using System;
using System.Collections.Generic;

namespace SignalRWebPack
{

    public interface Grouped
    {
        public bool IsCharacter();
        public void Add(Grouped group);
        public void Remove(Grouped group);
        public void SetBehavior(MoveAlgorithm behavior);
    }

    public class Group : Grouped
    {
        public string name;
        public List<Grouped> children = new List<Grouped>();
       
        public Group(string name)
        {
            this.name = name;
        }

        public void Add(Grouped component)
        {
            children.Add(component);
        }

        public void Remove(Grouped component)
        {
            children.Remove(component);
        }

        public void SetBehavior(MoveAlgorithm behavior)
        {

            // Recursively display child nodes
            foreach (Grouped component in children)
            {
                component.SetBehavior(behavior);
            }
        }

        public bool IsCharacter()
        {
            return false;
        }

        public void AddGroup(string parentName, string childName)
        {
            if (parentName == name)
            {
                Add(new Group(childName));
                return;
            }
            foreach(Grouped grouped in children)
            {
                if (!grouped.IsCharacter())
                    AddGroup(parentName, childName);
            }
        }

        public Group GetGroup(string parentName)
        {
            if (parentName == name)
                return this;
            
            foreach (Grouped grouped in children)
            {
                Group target;
                if (!grouped.IsCharacter())
                    if ((target = (grouped as Group).GetGroup(parentName)) != null)
                        return target;
            }
            return null;
        }
    }

}