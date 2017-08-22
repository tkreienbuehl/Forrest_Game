public class Influences {

    private short industrialInfluence;
    private short environmentalInfluence;
    private short touristicInfluence;

    //added new part.
    private short nrOfFields;
    private short actionID;
    private decimal costYearly;
    private decimal income;

    public Influences() {
        industrialInfluence     = 0;
        environmentalInfluence  = 0;
        touristicInfluence      = 0;
        costYearly              = 0;
        income                  = 0;
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

    public void setCostYearlyInfluence(decimal influence) {
        costYearly = influence;
    }

    public void setIncomeInfluence(decimal influence) {
        income = influence;
    }

    public decimal getCostYearlyInfluence() {
        return costYearly;
    }

    public decimal getIncomeInfluence() {
        return income;
    }

}
