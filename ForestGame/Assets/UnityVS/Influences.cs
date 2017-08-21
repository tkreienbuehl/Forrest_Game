public class Influences {

    private short industrialInfluence;
    private short environmentalInfluence;
    private short touristicInfluence;

    //added new part.
    private decimal Cost;
    private decimal Cost_Yearly;
    private decimal Income;

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
        industrialInfluence = influence;
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

    public void setCostInfluence(decimal influence) {
        Cost = influence;
    }

    public void setCostYearlyInfluence(decimal influence) {
        Cost_Yearly = influence;
    }

    public void setIncomeInfluence(decimal influence) {
        Income = influence;
    }

    public decimal getCostInfluence() {
        return Cost;
    }

    public decimal getCostYearlyInfluence() {
        return Cost_Yearly;
    }

    public decimal getIncomeInfluence() {
        return Income;
    }

}
