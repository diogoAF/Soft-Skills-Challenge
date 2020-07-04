using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Question {
    public string text;
    public Answer a;
    public Answer b;
    public Question(string text, Answer a, Answer b){
        this.text = text;
        this.a = a;
        this.b = b;
    }
}