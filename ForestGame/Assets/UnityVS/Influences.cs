public class Influences {

    private short industrialInfluence;
    private short environmentalInfluence;
    private short touristicInfluence;

    //added new part.
    private double Cost;
    private double Cost_Yearly;
    private double Income;

    public Influences() {
        industrialInfluence     = 0;
        environmentalInfluence  = 0;
        touristicInfluence      = 0;
        Cost                    = 0;
        Cost_Yearly             = 0;
        Income                  = 0;
    }

    public void setIndustrialInfluence(short influence) {
        industrialInfluence = influence;
    }

    public short getIndustrialInfluence() {
        return industrialInfluence;
    }

    public void setEnvironmentalInfluence(short influence) {
        environmentalInfluence = influence;
    }

    public short getEnvironmentalInfluence() {
        return environmentalInfluence;
    }

    public void setTouristicalInfluence(short influence) {
        touristicInfluence = influence;
    }

    public short getTouristicalInfluence() {
        return touristicInfluence;
    }

    public void setCostInfluence(double influence) {
        Cost = influence;
    }

    public void setCostYearlyInfluence(double influence) {
        Cost_Yearly = influence;
    }

    public void setIncomeInfluence(double influence) {
        Income = influence;
    }

    public double getCostInfluence() {
        return Cost;
    }

    public double getCostYearlyInfluence() {
        return Cost_Yearly;
    }

    public double getIncomeInfluence() {
        return Income;
    }

}
