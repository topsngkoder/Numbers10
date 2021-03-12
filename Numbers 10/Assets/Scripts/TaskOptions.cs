using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

    public static class TaskOptions
    {
        public static List<TaskList> GenerateTaskOptions(int resolution)
        {
            var taskOptionsList = new List<TaskList>();
            
            for (var i = (int)Math.Pow(10,resolution-1); i < Math.Pow(10,resolution); i++)
            {
            
                var elementsList = new TaskList();
                
                var fullNumber = i;
                
                for (var j = 0; j < resolution; j++)
                {
                    elementsList.Add(fullNumber%10);
                    fullNumber /= 10;
                }

                elementsList.Sort();
                
                
                if (elementsList[0]==0)
                    continue;
                
                
                var isContain = false;
                
                foreach (var taskList in taskOptionsList)
                {
                    if (taskList.IsEqual(elementsList))
                    {
                        isContain = true;
                        break;
                    }
                    
                }

                if (isContain)
                continue;
            
            
                taskOptionsList.Add(elementsList);
                
            }
        
            PrintTaskList(taskOptionsList);

            return taskOptionsList;
        }

        private static void PrintTaskList(List<TaskList> taskList)
        {
            foreach (var el in taskList)
            {
                var str = "";
                foreach (var i1 in el)
                {
                    str += i1.ToString();
                }

                Debug.Log(str);
            }
        }
        
        
        
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
                return chek;
            }
        }
        
        
        
        
    }
