using System;
using System.Collections.Generic;

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
                
                // var isContain = false;
                //
                // foreach (var taskList in taskOptionsList)
                // {
                //     if (taskList.IsEqual(elementsList))
                //     {
                //         isContain = true;
                //         break;
                //     }
                // }
                //
                // if (isContain)
                // continue;
            
            
                taskOptionsList.Add(elementsList);
                
            }
        
            //PrintTaskList(taskOptionsList);

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

            }
        }
    }
