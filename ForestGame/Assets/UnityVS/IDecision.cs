﻿public interface IDecision {

    Influences getInfluences(int nrOfAnswer = 0);

    int getDecisionID();

    short getFactionID();

    string getRequestText();

    short getActionID();

    short getNrOfAffectedFields();

    bool getIsBribe();

}
