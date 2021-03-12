using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

    public static class TaskOptions
    {
        public static List<List<int>> GenerateTaskOptions(int resolution)
        {
            var taskOptionsList = new List<List<int>>();
            
            for (var i = (int)Math.Pow(10,resolution-1); i < Math.Pow(10,resolution); i++)
            {
            
                var elementsList = new List<int>();
                
                var fullNumber = i;
                
                for (var j = 0; j < resolution; j++)
                {
                    elementsList.Add(fullNumber%10);
                    fullNumber /= 10;
                }

                elementsList.Sort();
                
                
                if (elementsList[0]==0)
                    continue;
                
            
            
                taskOptionsList.Add(elementsList);
            }
        
            PrintTaskList(taskOptionsList);

            return taskOptionsList;
        }

        private static void PrintTaskList(List<List<int>> taskList)
        {
            foreach (var all in taskList)
            {
                var str = "";
                foreach (var i1 in all)
                {
                    str += i1.ToString();
                }

                Console.WriteLine(str);
            }
        }
        
        public class TaskList: List, IComparable
        {
            private List<int> taskList=new List<int>();
            
            
            
            public int CompareTo(object taskListB)
            {
                var taskListA = taskListB as TaskList;
                
                
                
                
            }
        }
        
        
        
        
    }
