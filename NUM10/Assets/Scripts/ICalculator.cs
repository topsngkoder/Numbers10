using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICalculator
{
    int Sum(int a, int b);
    int Sub(int a, int b);
    int Mul(int a, int b);
    int? Div(int a, int b);


}
