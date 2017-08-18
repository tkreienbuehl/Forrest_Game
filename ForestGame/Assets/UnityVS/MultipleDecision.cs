﻿using System.Collections;

public class MultipleDecision : IMultipleDecision{

    private int decisionID;
    private string decisionRequest;
    private ArrayList influences;
    private ArrayList answers;
    private short factionID;


    public MultipleDecision(int decisionID) {
        this.decisionID = decisionID;
        answers = new ArrayList();
    }

    public string[] getAnswers() {
        return (string[])answers.ToArray();
    }

    public int getDecisionID() {
        return decisionID;
    }

    public void addAnswer(string answer) {
        answers.Add(answer);
    }

    public void setRequestText(string text) {
        decisionRequest = text;
    }

    public void addInfluences(Influences influences) {
        this.influences.Add(influences);
    }

    public short getFactionID() {
        throw new System.NotImplementedException();
    }

    public Influences getInfluences(int nrOfAnswer = 0) {
        Influences[] arry = (Influences[])influences.ToArray();
        return arry[nrOfAnswer];
    }

    public string getRequestText() {
        return decisionRequest;
    }
}