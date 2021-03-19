using System;
using System.Collections.Generic;
using UnityEngine;


public class TaskList: List<int>
    {
        private TaskList Copy()
        {
            var listCopy = new TaskList();
            foreach (var element in this)
            {
                listCopy.Add(element);
            }
            return listCopy;
        }

        
            
            
            
        public bool IsEqual(TaskList anotherTaskList)
        {
            Debug.Log(DateTime.Now + "start EQUAL test");
            var chek = true;
                
            if (Count != anotherTaskList.Count)
                return false;

            var originalTaskList = Copy();
            var chekTaskList = anotherTaskList.Copy();
                
            originalTaskList.Sort();
            chekTaskList.Sort();

            for (var i = 0; i < originalTaskList.Count; i++)
            {
                if (originalTaskList[i]!=chekTaskList[i])
                {
                    chek = false;
                    break;
                }
            }
            Debug.Log(DateTime.Now + "stop EQUAL test");
            return chek;
        }
    }
